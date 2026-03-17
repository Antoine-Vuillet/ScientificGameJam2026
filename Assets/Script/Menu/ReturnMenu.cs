using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReturnMenu : MonoBehaviour
{
    private AudioManager _audioManager;
    private SceneLoader _sceneLoader;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        _sceneLoader = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
    }

    public void ReturnMenuOnClick()
    {
        _audioManager.PlayClic();
        _audioManager.StopMusic();
        _sceneLoader.SceneLoading("MenuStartScene");
        _audioManager.PlayMusic(_audioManager.MusicMainMenu);

    }
}
