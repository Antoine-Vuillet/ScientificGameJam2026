using System;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;


public class KnowledgeManager : MonoBehaviour
{
    [SerializeField]
    private ScoreManager scoreManager;
    [SerializeField] private Slider autoMin;
    [SerializeField] private Slider autoMax;
    [SerializeField] private Slider compMin;
    [SerializeField] private Slider compMax;
    [SerializeField] private Slider socialMin;
    [SerializeField] private Slider socialMax;

    private int autoVal = 0;
    private int compVal = 0;
    private int socialVal = 0;
    
    private Random rnd = new Random();

    private void Start()
    {
        ResetKnowledge();
    }

    public void ResetKnowledge()
    {
        autoMax.value = 10;
        autoMin.value = 1;
        compMax.value = 10;
        compMin.value = 1;
        socialMax.value = 10;
        socialMin.value = 1;
        autoVal = 0;
        compVal = 0;
        socialVal = 0;
    }

    public void setKnowledge(bool auto, bool comp, bool social)
    {
        print("yoyoyo");
        int upperChange;
        int lowerchange;
        if (auto)
        {
            int autoTarget = scoreManager.dailyGames[scoreManager.currentDay].autonomy;
            if (autoVal == 0)
            {
                upperChange = rnd.Next(0, 5);
                lowerchange = (int)(4 - upperChange);
                if (autoTarget + upperChange > 10)
                {
                    lowerchange = lowerchange + ((autoTarget + upperChange) - 10);
                    upperChange = upperChange - ((autoTarget+upperChange) -10);
                }
                else if (autoTarget - lowerchange < 1)
                {
                    upperChange = upperChange + Mathf.Abs(autoTarget - (lowerchange+1));
                    lowerchange = lowerchange - Mathf.Abs(autoTarget - (lowerchange+1));
                }
                autoVal++;
            }
            else if (autoVal == 1)
            {
                upperChange = rnd.Next(0, 3);
                lowerchange = (int)(2 - upperChange);
                if (autoTarget + upperChange > 10)
                {
                    lowerchange = lowerchange + ((autoTarget + upperChange) - 10);
                    upperChange = upperChange - ((autoTarget+upperChange) -10);
                }
                else if (autoTarget - lowerchange < 1)
                {
                    upperChange = upperChange + Mathf.Abs(autoTarget - (lowerchange+1));
                    lowerchange = lowerchange - Mathf.Abs(autoTarget - (lowerchange+1));
                }
                autoVal++;
            }
            else
            {
                upperChange = 0;
                lowerchange = 0;
            }
            autoMin.value = autoTarget - lowerchange;
            autoMax.value = autoTarget + upperChange;
        }

        if (comp)
        {
            int compTarget = scoreManager.dailyGames[scoreManager.currentDay].competence;
            if (compVal == 0)
            {
                upperChange = rnd.Next(0, 5);
                lowerchange = (int)(4 - upperChange);
                if (compTarget + upperChange > 10)
                {
                    lowerchange = lowerchange + ((compTarget + upperChange) - 10);
                    upperChange = upperChange - ((compTarget+upperChange) -10);
                }
                else if (compTarget - lowerchange < 1)
                {
                    upperChange = upperChange + Mathf.Abs(compTarget - (lowerchange+1));
                    lowerchange = lowerchange - Mathf.Abs(compTarget - (lowerchange+1));
                }
                compVal++;
            }
            else if (compVal == 1)
            {
                upperChange = rnd.Next(0, 3);
                lowerchange = (int)(2 - upperChange);
                if (compTarget + upperChange > 10)
                {
                    lowerchange = lowerchange + ((compTarget + upperChange) - 10);
                    upperChange = upperChange - ((compTarget+upperChange) -10);
                }
                else if (compTarget - lowerchange < 1)
                {
                    upperChange = upperChange + Mathf.Abs(compTarget - (lowerchange+1));
                    lowerchange = lowerchange - Mathf.Abs(compTarget - (lowerchange+1));
                }
                compVal++;
            }
            else
            {
                upperChange = 0;
                lowerchange = 0;
            }
            compMin.value = compTarget - lowerchange;
            compMax.value = compTarget + upperChange;
        }

        if (social)
        {
            int socialTarget = scoreManager.dailyGames[scoreManager.currentDay].social;
            if (socialVal == 0)
            {
                upperChange = rnd.Next(0, 5);
                lowerchange = (int)(4 - upperChange);
                if (socialTarget + upperChange > 10)
                {
                    lowerchange = lowerchange + ((socialTarget + upperChange) - 10);
                    upperChange = upperChange - ((socialTarget+upperChange) -10);
                }
                else if (socialTarget - lowerchange < 1)
                {
                    upperChange = upperChange + Mathf.Abs(socialTarget - (lowerchange+1));
                    lowerchange = lowerchange - Mathf.Abs(socialTarget - (lowerchange+1));
                }
                socialVal++;
            }
            else if (socialVal == 1)
            {
                upperChange = rnd.Next(0, 3);
                lowerchange = (int)(2 - upperChange);
                if (socialTarget + upperChange > 10)
                {
                    lowerchange = lowerchange + ((socialTarget + upperChange) - 10);
                    upperChange = upperChange - ((socialTarget+upperChange) -10);
                }
                else if (socialTarget - lowerchange < 1)
                {
                    upperChange = upperChange + Mathf.Abs(socialTarget - (lowerchange+1));
                    lowerchange = lowerchange - Mathf.Abs(socialTarget - (lowerchange+1));
                }
                socialVal++;
            }
            else
            {
                upperChange = 0;
                lowerchange = 0;
            }
            socialMin.value = socialTarget - lowerchange;
            socialMax.value = socialTarget + upperChange;
        }
    }
    
    
}
