using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private bool isMuted;
    private AudioSource audioSource;

    public AudioClip coinGrabSound;
    public AudioClip clickSound;
    public AudioClip jumpSound;

    public AudioSource effectsSource;

    public void PlayOnceClick()
    {
        if (isMuted) return;
        effectsSource.PlayOneShot(clickSound, 1f);
    }

    public void PlayOnceJump()
    {
        if (isMuted) return;
        effectsSource.PlayOneShot(jumpSound, 1f);
    }

    public void PlayCoinGrab()
    {
        if (isMuted) return;
        effectsSource.PlayOneShot(coinGrabSound, 1f);
    }

    void Awake()
    {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public void ToggleMuted()
    {
        isMuted = !isMuted;
        audioSource.mute = isMuted;
    }

    public bool GetMuted()
    {
        return isMuted;
    }
}
