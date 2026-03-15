using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OpenCredit : MonoBehaviour
{
    [SerializeField] private GameObject creditCanvas;
    [SerializeField] private GameObject MenuCanvas;

    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void OpenCreditOnClick()
    {
        MenuCanvas.SetActive(false);
        _audioManager.PlayClic();
        creditCanvas.SetActive(true);
    }
}
