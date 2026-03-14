using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayButton : MonoBehaviour
{
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void PlayGameOnClick()
    {
        _audioManager.PlayClic();
        _audioManager.StopMusic();
    }
}
