using UnityEngine;
using UnityEngine.UI;

public class MuteManager : MonoBehaviour
{
    public AudioSource backgroundMusic;  // Reference to your background music Audio Source
    public Button muteButton;            // Reference to your button
    public Sprite muteIcon;              // Icon for mute state
    public Sprite unmuteIcon;            // Icon for unmute state
    private bool isMuted = false;        // Track mute state

    private void Start()
    {
        // Add listener to the button
        muteButton.onClick.AddListener(ToggleMute);

        // Initialize the button's appearance
        UpdateButtonIcon();
    }

    private void ToggleMute()
    {
        isMuted = !isMuted; // Toggle mute state

        if (isMuted)
        {
            backgroundMusic.Pause(); // Mute the music
        }
        else
        {
            backgroundMusic.Play(); // Unmute the music
        }

        UpdateButtonIcon(); // Update the button's icon or text
    }

    private void UpdateButtonIcon()
    {
        // Update button icon based on the mute state
        Image buttonImage = muteButton.GetComponent<Image>();
        if (isMuted)
        {
            buttonImage.sprite = muteIcon; // Set mute icon
        }
        else
        {
            buttonImage.sprite = unmuteIcon; // Set unmute icon
        }
    }
}
