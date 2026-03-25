using System;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int financialScore;
    private int moralScore;
    [SerializeField] public List<jeuSO> dailyGames;
    public int currentDay;
    [SerializeField] private RsController reseauController;
    [SerializeField] private gameplayController _gameplayController;
    [SerializeField] private ComportementController _comportementController;
    [SerializeField] private FeatureChoiceScript _featureChoiceScript;
    [SerializeField] private GameEventSO _gameEventSo;
    [SerializeField] private CinemachineSwitcher _cinemachineSwitcher;
    

    [SerializeField] private Canvas EndingPA;
    [SerializeField] private Canvas EndingPM;
    [SerializeField] private Canvas EndingRA;
    [SerializeField] private Canvas EndingRM;

    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


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
        print("Financial score: " + financialScore);
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

        _audioManager.PlaySFX(_audioManager.notifMail);
        _audioManager.PlayClic();
        jeuSO currentGame = dailyGames[currentDay];
        int value = CalcValue(currentGame.autonomy, ourGame.GetGameStats().autonomy);
        value += CalcValue(currentGame.competence, ourGame.GetGameStats().competence);
        value += CalcValue(currentGame.social, ourGame.GetGameStats().social);
        AddFinancialScore(value);
        AddMoralScore(ourGame.GetPatternCount());
        if (currentDay < 2)
        {
            _cinemachineSwitcher.LeaveScreen1();
            GetComponent<KnowledgeManager>().ResetKnowledge();
            reseauController.NextGame();
            _gameplayController.NextGame();
            _comportementController.NextGame();
            _featureChoiceScript.Reset();
            ourGame.Reset();
            _gameEventSo.Raise(this, EventArgs.Empty);
            
            NextDay();
        }
        else
        {
            print(financialScore);
            _audioManager.StopMusic();
    
            _audioManager.PlayMusic(_audioManager.MusicEndGame);
            if (moralScore>=3)
            {
                if (financialScore >=8)
                {
                    EndingRA.enabled = true;
                }

                if (financialScore < 8)
                {
                    EndingPA.enabled = true;
                }
            }
            else
            {
                if (financialScore >=8)
                {
                    EndingRM.enabled = true;
                }

                if (financialScore < 8)
                {
                    EndingPM.enabled = true;
                }
            }
        }
    }
}
