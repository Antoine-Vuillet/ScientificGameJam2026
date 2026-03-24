using UnityEngine;

public class CloseWindowMail : MonoBehaviour
{
    [SerializeField] private GameObject mailWindows;

    public void CloseWindowMailOnClick()
    {
        mailWindows.SetActive(false);
    }
}
