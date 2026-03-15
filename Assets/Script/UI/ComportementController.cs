using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using NaughtyAttributes;
using TMPro;

[Serializable]
public class comportementGame
{
    public List<infoComportementSO> infos;
    public List<treatDataSO> treatButtonsInfo;
}

public class ComportementController : MonoBehaviour
{
    [SerializeField] private List<comportementGame> GameList;
    [SerializeField] private List<GameObject> infos;
    [SerializeField] private List<GameObject> treat;

    private int currentGameIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateInfos(currentGameIndex);
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
        }
    }

    private void updateInfos(int p_gameIndex)
    {
        for (int i = 0; i < infos.Count; i++)
        {
            TextMeshProUGUI infoName = infos[i].transform.Find("InfoName").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI infoNumber = infos[i].transform.Find("DataContainer/InfoNumber").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI infoPercent = infos[i].transform.Find("DataContainer/InfoPercent").GetComponent<TextMeshProUGUI>();

            if (i < GameList[p_gameIndex].infos.Count)
            {
                infoComportementSO infoData = GameList[p_gameIndex].infos[i];
                infoName.text = infoData.infoName;
                infoNumber.text = infoData.infoStat;
                infos[i].GetComponent<Image>().color = infoData.infoColor;
                
                if (int.Parse(infoData.infoPercentage) <= 0)
                {
                    infoPercent.text = "▼" + infoData.infoPercentage + "%";
                    infoPercent.color = ColorUtility.TryParseHtmlString("#E00007", out Color color) ? color : Color.red;
                }
                else
                {
                    infoPercent.text = "▲" + infoData.infoPercentage + "%";
                    infoPercent.color = ColorUtility.TryParseHtmlString("#15ff00", out Color color) ? color : Color.green;
                }
                
            }
            else
            {
                infoName.text = "";
                infoNumber.text = "";
                infoPercent.text = "";
                infos[i].GetComponent<Image>().color = Color.clear;
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



    public void treatDataBtn(TextMeshProUGUI p_treatCost)
    {

    }

    // TODO Credit to be added : <a href="https://www.flaticon.com/fr/icones-gratuites/frere" title="frère icônes">Frère icônes créées par Freepik - Flaticon</a>
    // <a href="https://www.flaticon.com/fr/icones-gratuites/maman" title="maman icônes">Maman icônes créées par Freepik - Flaticon</a>
}
