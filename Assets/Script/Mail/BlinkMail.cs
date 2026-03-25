using UnityEngine;

public class BlinkMail : MonoBehaviour
{
    [SerializeField] private GameObject notifMailIcon;
    private AudioManager _audioManager;

    private bool _isNotify = true;

    private void Awake()
    {
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        ActiveNotif();
    }

    public void ActiveNotif()
    {
        if (_isNotify)
        {
            notifMailIcon.SetActive(true); 
            _audioManager.PlaySFX(_audioManager.notifMail);
            Invoke("DeactiveNotif", 1.5f);
        }
       
    }

    public void DeactiveNotif()
    {
        if (_isNotify)
        {
            notifMailIcon.SetActive(false); 
            Invoke("ActiveNotif", 1.5f);
        
        }
    }


    public void CloseIconMailClick()
    {
        if(_isNotify)
        {
            
            notifMailIcon.SetActive(false); 
            _isNotify = false;
        }
        
    }
}
