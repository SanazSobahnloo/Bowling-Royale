using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    private AudioSource audioSource;
    public bool isMuted = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;

        if (isMuted)
        {
            audioSource.Pause();
        }
        else
        {
            audioSource.Play();
        }
    }
}
