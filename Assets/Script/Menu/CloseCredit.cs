using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CloseCredit : MonoBehaviour
{
    [SerializeField] private GameObject creditCanvas;

    public void CloseCreditOnClick()
    {
        creditCanvas.SetActive(false);
    }
}
