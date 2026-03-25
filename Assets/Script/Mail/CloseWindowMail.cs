using UnityEngine;

public class CloseWindowMail : MonoBehaviour
{
    [SerializeField] private GameObject mailWindows;
    [SerializeField] private GameObject mailTutoWindows;
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    public void CloseWindowMailOnClick()
    {
        _audioManager.PlayClic();
        mailWindows.SetActive(false);
        mailTutoWindows.SetActive(false);
    }
}
