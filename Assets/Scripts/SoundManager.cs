using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    private bool isMuted;
    private AudioSource audioSource;

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
