using UnityEngine;

public class CloseDoc : MonoBehaviour
{
    [SerializeField] private GameObject docs;
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    public void CloseDocOnClick()
    {
        _audioManager.PlayClic();
        docs.SetActive(false);
    }
}
