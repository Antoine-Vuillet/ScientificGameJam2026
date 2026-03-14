using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OpenCredit : MonoBehaviour
{
    [SerializeField] private GameObject creditCanvas;

    public void OpenCreditOnClick()
    {
        creditCanvas.SetActive(true);
    }
}
