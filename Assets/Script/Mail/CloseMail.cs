using UnityEngine;

public class CloseMail : MonoBehaviour
{
    [SerializeField] private GameObject mailTutoWindows;
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    public void ClosedMailOnClick()
    {
        _audioManager.PlayClic();
        mailTutoWindows.SetActive(false);
    }
}
