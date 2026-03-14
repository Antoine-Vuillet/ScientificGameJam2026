using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OpenCredit : MonoBehaviour
{
    [SerializeField] private GameObject creditCanvas;

    private AudioManager _audioManager;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void OpenCreditOnClick()
    {
        _audioManager.PlayClic();
        creditCanvas.SetActive(true);
    }
}
