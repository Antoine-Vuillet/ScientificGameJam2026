using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------AudioSource-------")]
    [SerializeField] private AudioSource music;
    [SerializeField] private AudioSource SFX;

    [Header("-------AudioClipSFX-------")]
    public AudioClip clic1;
    public AudioClip clic2;
    public AudioClip clic3;
    public AudioClip notifMail;
    public AudioClip chaise;
    public AudioClip notifPhone;

    [Header("-------AudioClipMusic-------")]
    public AudioClip MusicMainMenu;
    public AudioClip MusicInGame;
    public AudioClip MusicEndGame;


    void Start()
    {
        music.clip = MusicMainMenu;
        music.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }

    public void ChangeMusic(AudioClip musicClip)
    {
        music.clip = musicClip;
        music.Play();
    }

    public void StopMusic()
    {
        music.mute = true;
    }

    public void PlayClic()
    {
        var id = Random.Range(1,4);
        switch (id)
        {
            case 1:
                PlaySFX(clic1);
                break;
            case 2:
                PlaySFX(clic2);
                break;
            case 3:
                PlaySFX(clic3);
                break;
        }
           
    }
    
}
