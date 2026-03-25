using UnityEngine;

public class OpenMail : MonoBehaviour
{
    [SerializeField] private GameObject mailTutoWindows;
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    public void OpenMailOnClick()
    {
        _audioManager.PlayClic();
        mailTutoWindows.SetActive(true);
    }
}
