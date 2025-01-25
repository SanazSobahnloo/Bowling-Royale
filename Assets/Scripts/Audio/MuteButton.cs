using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
    public Text buttonText;

    private void Start()
    {
        UpdateButtonText();
    }

    public void ToggleMute()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();

        if (audioManager != null)
        {
            audioManager.ToggleMute();
            UpdateButtonText();
        }
    }

    private void UpdateButtonText()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>();

        if (audioManager != null)
        {
            buttonText.text = audioManager.isMuted ? "Unmute" : "Mute";
        }
    }
}
