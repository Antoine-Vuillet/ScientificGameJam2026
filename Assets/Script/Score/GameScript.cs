using System;
using UnityEngine;


public struct stats
{
    public int autonomy;
    public int competence;
    public int social;
}
public class GameScript : MonoBehaviour
{
    private stats gameStats;
    private int patternCount = 0;
    public int maxMoney = 10;
    public int usedMoney;


    private void Start()
    {
        Reset();
    }

    public void Reset()
    {
        gameStats.autonomy = 0;
        gameStats.competence = 0;
        gameStats.social = 0;
    }

    public void SetGameStats(int autonomy, int competence, int social)
    {
        gameStats.autonomy += autonomy;
        gameStats.competence += competence;
        gameStats.social += social;
    }

    public int GetPatternCount()
    {
        return patternCount;
    }

    public stats GetGameStats()
    {
        return gameStats;
    }
}
