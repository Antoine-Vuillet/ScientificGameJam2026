using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;
using EasyChart;
using EasyChart.UGUI;

[Serializable]
public class gameplayGame
{
    public List<ChartProfile> infos;
    public List<treatDataSO> treatButtonsInfo;
}

public class gameplayController : MonoBehaviour
{
    [SerializeField] private List<gameplayGame> GameList;
    [SerializeField] private List<GameObject> infos;
    [SerializeField] private List<GameObject> treat;
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private KnowledgeManager knowledgeManager;
    [SerializeField] private GameScript gameManager;
    [SerializeField] private GameEventSO budgetUpdateEvent;
    private int currentGameIndex = 0;
    private bool isBtn1Clicked = false;
    private bool isBtn2Clicked = false;
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    void Start()
    {
        updateInfos(currentGameIndex);
        updateBtns();
    }

    // Update is called once per frame
    void Update()
    {

    }

    [Button("Next Game")]
    public void NextGame()
    {
        currentGameIndex++;
        if (currentGameIndex < GameList.Count)
        {
            updateInfos(currentGameIndex);
            isBtn1Clicked = false;
            isBtn2Clicked = false;
            updateBtns();
        }
    }

    private void updateInfos(int p_gameIndex)
    {
        for (int i = 0; i < infos.Count; i++)
        {
            if (i < GameList[p_gameIndex].infos.Count)
            {
                ChartProfile infoData = GameList[p_gameIndex].infos[i];

                UGUIChartBridge graphComponent = infos[i].GetComponent<UGUIChartBridge>();

                graphComponent._profile = infoData;
            }
        }

        for (int i = 0; i < treat.Count; i++)
        {
            TextMeshProUGUI treatName = treat[i].transform.Find("TextAndPastilles/TreatName").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI treatCost = treat[i].transform.Find("Button/TreatCost").GetComponent<TextMeshProUGUI>();

            Image autonomyIcon = treat[i].transform.Find("TextAndPastilles/Pastilles/Autonomy").GetComponent<Image>();
            Image socialIcon = treat[i].transform.Find("TextAndPastilles/Pastilles/Social").GetComponent<Image>();
            Image competenceIcon = treat[i].transform.Find("TextAndPastilles/Pastilles/Competence").GetComponent<Image>();

            if (i < GameList[p_gameIndex].treatButtonsInfo.Count)
            {
                treatDataSO treatData = GameList[p_gameIndex].treatButtonsInfo[i];
                treatName.text = treatData.treatName;
                treatCost.text = treatData.treatCost.ToString() + "€";

                var pastilles = treatData.treatedStats;
                Image[] icons = { autonomyIcon, socialIcon, competenceIcon };

                for (int j = 0; j < pastilles.Count && j < icons.Length; j++)
                {
                    icons[j].gameObject.SetActive(pastilles[j]);
                }
            }
            else
            {
                treatName.text = "";
                treatCost.text = "";
                autonomyIcon.gameObject.SetActive(false);
                socialIcon.gameObject.SetActive(false);
                competenceIcon.gameObject.SetActive(false);
            }
        }
    }

    public void updateBtns()
    {
        for (int i = 0; i < treat.Count; i++)
        {
            treatDataSO t_treatData = GameList[currentGameIndex].treatButtonsInfo[i];
            Button treatBtn = treat[i].transform.Find("Button").GetComponent<Button>();

            if (gameManager.usedMoney + t_treatData.treatCost <= gameManager.maxMoney)
            {
                treatBtn.interactable = true;
            }
            else
            {
                treatBtn.interactable = false;
            }

            if (isBtn1Clicked && i == 0 || isBtn2Clicked && i == 1)
            {
                treatBtn.interactable = false;
            }
        }
    }

    public void treatDataBtn1(Button p_button)
    {
        treatDataSO t_treatData = GameList[currentGameIndex].treatButtonsInfo[0];
        Debug.Log("treatDataBtn1 : " + t_treatData.treatName);

        if (gameManager.usedMoney + t_treatData.treatCost <= gameManager.maxMoney)
        {
            _audioManager.PlaySFX(_audioManager.achat);
            knowledgeManager.setKnowledge(t_treatData.treatedStats[0], t_treatData.treatedStats[1], t_treatData.treatedStats[2]);

            gameManager.usedMoney += t_treatData.treatCost;
            budgetUpdateEvent.Raise(this, EventArgs.Empty);

            if (t_treatData.isDark)
            {
                scoreManager.AddMoralScore(1);
            }
            isBtn1Clicked = true;
        }
        updateBtns();
    }

    public void treatDataBtn2(Button p_button)
    {
        treatDataSO t_treatData = GameList[currentGameIndex].treatButtonsInfo[1];
        Debug.Log("treatDataBtn1 : " + t_treatData.treatName);

        if (gameManager.usedMoney + t_treatData.treatCost <= gameManager.maxMoney)
        {
            _audioManager.PlaySFX(_audioManager.achat);
            knowledgeManager.setKnowledge(t_treatData.treatedStats[0], t_treatData.treatedStats[1], t_treatData.treatedStats[2]);

            gameManager.usedMoney += t_treatData.treatCost;
            budgetUpdateEvent.Raise(this, EventArgs.Empty);

            if (t_treatData.isDark)
            {
                scoreManager.AddMoralScore(1);
            }
            isBtn2Clicked = true;
        }
        updateBtns();
    }

    // TODO Credit to be added : <a href="https://www.flaticon.com/fr/icones-gratuites/frere" title="frère icônes">Frère icônes créées par Freepik - Flaticon</a>
    // <a href="https://www.flaticon.com/fr/icones-gratuites/maman" title="maman icônes">Maman icônes créées par Freepik - Flaticon</a>
}
