using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using NaughtyAttributes;

[Serializable]
public class rsGame
{
    public List<infoRsSO> infos;
}
public class RsController : MonoBehaviour
{
    [SerializeField] private List<rsGame> rsGames;
    [SerializeField] private List<GameObject> infos;

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

    public void NextGame()
    {
        currentGameIndex++;
        if (currentGameIndex < rsGames.Count)
        {
            updateInfos(currentGameIndex);
        }
    }

    private void updateInfos(int gameIndex) {
        for (int i = 0; i < infos.Count; i++)
        {
            Image profilePicture = infos[i].GetComponentInChildren<Image>();
            TextMeshProUGUI title = infos[i].GetComponentInChildren<TextMeshProUGUI>();
            TextMeshProUGUI message = infos[i].GetComponentInChildren<TextMeshProUGUI>();

            if (i < rsGames[gameIndex].infos.Count)
            {
                infoRsSO infoData = rsGames[gameIndex].infos[i];
                profilePicture.sprite = infoData.profilePicture;
                title.text = infoData.title;
                message.text = infoData.message;
            }
            else
            {
                profilePicture.sprite = null;
                title.text = "";
                message.text = "";
            }
        }
    }
}
