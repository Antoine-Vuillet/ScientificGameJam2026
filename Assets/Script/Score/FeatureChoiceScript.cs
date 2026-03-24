using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class FeatureChoiceScript : MonoBehaviour
{
    [SerializeField] private GameScript ourGame;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private Slider competenceSlider;
    [SerializeField] private Slider autonomySlider;
    [SerializeField] private Slider socialSlider;
    [SerializeField] private GameEventSO budgetUpdateEvent;
    private List<Toggle> toggles = new List<Toggle>();
    private List<Toggle> genreToggles = new List<Toggle>();
    private List<TextMeshProUGUI> genreTexts = new List<TextMeshProUGUI>();
    private List<Toggle> allToggles = new List<Toggle>();
    private List<TextMeshProUGUI> allTexts = new List<TextMeshProUGUI>();
    private bool genreChosen;
    private Toggle selectedGenreToggle;


    public void Reset()
    {
        for (int i = toggles.Count; i > 0; i--)
        {
            toggles[i - 1].isOn = false;
        }
        competenceSlider.value = 0;
        autonomySlider.value = 0;
        socialSlider.value = 0;
        UpdateGenreTextColors();
        UpdateAllToggleColors();
    }

    void Start()
    {
        Toggle[] t_allToggles = GetComponentsInChildren<Toggle>();
        foreach (var toggle in t_allToggles)
        {
            if (toggle.CompareTag("Genre"))
            {
                genreToggles.Add(toggle);
            }
            else
            {
                allToggles.Add(toggle);
            }
        }

        TextMeshProUGUI[] t_allTexts = GetComponentsInChildren<TextMeshProUGUI>();
        foreach (var text in t_allTexts)
        {
            if (text.CompareTag("Genre"))
            {
                genreTexts.Add(text);
            }
            else if (text.CompareTag("Feature"))
            {
                allTexts.Add(text);
            }
        }
    }

    public void UpdateGenreTextColors()
    {
        if (genreChosen && selectedGenreToggle != null)
        {
            for (int i = 0; i < genreToggles.Count; i++)
            {
                if (genreToggles[i] == selectedGenreToggle)
                {
                    genreTexts[i].color = Color.black;
                }
                else
                {
                    genreTexts[i].color = new Color(0.8235f, 0.8235f, 0.8235f, 1f);
                }
            }
        }
        else
        {
            foreach (var text in genreTexts)
            {
                text.color = Color.black;
            }
        }
    }

    public void UpdateAllToggleColors()
    {
        for (int i = 0; i < allToggles.Count; i++)
        {
            int cost = allToggles[i].GetComponent<FeatureScript>().feature.cost;

            if (!allToggles[i].isOn && ourGame.usedMoney + cost > ourGame.maxMoney)
            {
                allTexts[i].color = new Color(0.8235f, 0.8235f, 0.8235f, 1f);
            }
            else
            {
                allTexts[i].color = Color.black;
            }
        }
    }

    public void OnToggleValueChanged(bool value, Toggle toggle, bool isGenre)
    {
        if (value)
        {
            if ((ourGame.usedMoney + toggle.GetComponent<FeatureScript>().feature.cost > ourGame.maxMoney) || (genreChosen && isGenre))
            {
                toggle.isOn = false;
            }
            else
            {
                if (isGenre)
                {
                    genreChosen = true;
                    selectedGenreToggle = toggle;
                }
                ourGame.usedMoney += toggle.GetComponent<FeatureScript>().feature.cost;
                toggles.Add(toggle);
            }
        }
        else
        {
            if (toggles.Remove(toggle))
            {
                if (isGenre)
                {
                    genreChosen = false;
                    selectedGenreToggle = null;
                }
                ourGame.usedMoney -= toggle.GetComponent<FeatureScript>().feature.cost;
            }
        }
        budgetUpdateEvent.Raise(this, EventArgs.Empty);
        UpdateGenreTextColors();
        UpdateAllToggleColors();
        CalculateStats();
    }

    public void OnConfirmChoices()
    {
        scoreManager.FinishDay(ourGame);
    }

    public void CalculateStats()
    {
        int competence = 0;
        int autonomy = 0;
        int social = 0;
        int moralscore = 0;
        foreach (var toggle in toggles)
        {
            competence += toggle.GetComponent<FeatureScript>().feature.competence;
            autonomy += toggle.GetComponent<FeatureScript>().feature.autonomy;
            social += toggle.GetComponent<FeatureScript>().feature.social;
            if (toggle.GetComponent<FeatureScript>().feature.isDark)
            {
                moralscore++;
            }
        }
        ourGame.SetPatternCount(moralscore);
        autonomySlider.value = autonomy;
        competenceSlider.value = competence;
        socialSlider.value = social;
        ourGame.SetGameStats(autonomy, competence, social);
    }
}
