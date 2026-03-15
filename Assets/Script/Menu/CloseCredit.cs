using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CloseCredit : MonoBehaviour
{
    [SerializeField] private GameObject creditCanvas;
    [SerializeField] private GameObject MenuCanvas;

    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void CloseCreditOnClick()
    {
        _audioManager.PlayClic();
        creditCanvas.SetActive(false);
        MenuCanvas.SetActive(true);
    }
}
