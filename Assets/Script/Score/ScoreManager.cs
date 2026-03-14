using System;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int financialScore;
    private int moralScore;
    [SerializeField] private List<jeuSO> dailyGames;
    private int currentDay;

    private void Start()
    {
        currentDay = 0;
    }

    private void NextDay()
    {
        currentDay += 1;
    }

    public int GetMoralScore()
    {
        return moralScore;
    }

    public int GetFinancialScore()
    {
        return financialScore;
    }

    public void AddMoralScore(int value)
    {
        moralScore += value;
    }

    public void AddFinancialScore(int value)
    {
        financialScore += value;
    }

    private int CalcValue(int ourGameVal, int wishedGameVal)
    {
        if (ourGameVal == wishedGameVal)
        {
            return 3;
        }
        else if((ourGameVal - wishedGameVal) == 1)
        {
            return 2;
        }
        else if ((ourGameVal-5)*(wishedGameVal-5)>1)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }

    public void FinishDay(GameScript ourGame)
    {
        jeuSO currentGame = dailyGames[currentDay];
        int value = CalcValue(currentGame.autonomy, ourGame.GetGameStats().autonomy);
        value += CalcValue(currentGame.competence, ourGame.GetGameStats().competence);
        value += CalcValue(currentGame.social, ourGame.GetGameStats().social);
        AddFinancialScore(value);
        AddMoralScore(ourGame.GetPatternCount());
    }
}
