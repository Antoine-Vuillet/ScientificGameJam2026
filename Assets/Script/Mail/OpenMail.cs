using UnityEngine;

public class OpenMail : MonoBehaviour
{
    [SerializeField] private GameObject mailTutoWindows;

    public void OpenMailOnClick()
    {
        mailTutoWindows.SetActive(true);
    }
}
