using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayButton : MonoBehaviour
{
    private AudioManager _audioManager;
    private SceneLoader _sceneLoader;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        _sceneLoader = GameObject.FindGameObjectWithTag("SceneLoader").GetComponent<SceneLoader>();
    }

    public void PlayGameOnClick()
    {
        _audioManager.PlayClic();
        _audioManager.StopMusic();
        _sceneLoader.SceneLoading("MainScene");

    }
}
