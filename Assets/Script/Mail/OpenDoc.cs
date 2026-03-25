using UnityEngine;

public class OpenDoc : MonoBehaviour
{
    [SerializeField] private GameObject docs;
    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    public void OpenDocOnClick()
    {
        _audioManager.PlayClic();
        docs.SetActive(true);
    }
}
