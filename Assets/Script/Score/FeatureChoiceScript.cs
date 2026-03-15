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
    
    public void OnToggleValueChanged(bool value, Toggle toggle)
    {
        if (value)
        {
            toggles.Add(toggle);
        }
        else
        {
            toggles.Remove(toggle);
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
        foreach (var toggle in toggles)
        {
            competence += toggle.GetComponent<FeatureScript>().feature.competence;
            autonomy += toggle.GetComponent<FeatureScript>().feature.autonomy;
            social += toggle.GetComponent<FeatureScript>().feature.social;
        }
        autonomySlider.value = autonomy;
        competenceSlider.value = competence;
        socialSlider.value = social;
        ourGame.SetGameStats(autonomy,competence,social);
    }
}
