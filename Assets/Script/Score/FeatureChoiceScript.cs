using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FeatureChoiceScript : MonoBehaviour
{
    [SerializeField] private GameScript ourGame;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField]private Slider competenceSlider;
    [SerializeField]private Slider autonomySlider;
    [SerializeField]private Slider socialSlider;
    private List<Toggle> toggles = new List<Toggle>();
    private bool genreChosen;


    public void Reset()
    {
        for (int i = toggles.Count; i > 0; i--)
        {
            toggles[i-1].isOn = false;
        }
        competenceSlider.value = 0;
        autonomySlider.value = 0;
        socialSlider.value = 0;
    }


    public void OnToggleValueChanged(bool value, Toggle toggle, bool isGenre)
    {
        if (value)
        {
            if ((ourGame.usedMoney+toggle.GetComponent<FeatureScript>().feature.cost > ourGame.maxMoney) || (genreChosen && isGenre))
            {
                toggle.isOn = false;
            }
            else
            {
                if (isGenre)
                {
                    genreChosen = true;
                }
                ourGame.usedMoney+=toggle.GetComponent<FeatureScript>().feature.cost;
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
                }
                ourGame.usedMoney-=toggle.GetComponent<FeatureScript>().feature.cost;
            }
        }
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
        ourGame.SetGameStats(autonomy,competence,social);
    }
}
