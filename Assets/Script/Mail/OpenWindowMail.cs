using UnityEngine;

public class OpenWindowMail : MonoBehaviour
{
    [SerializeField] private GameObject mailWindows;

    public void OpenWindowMailOnClick()
    {
        mailWindows.SetActive(true);
    }
}
