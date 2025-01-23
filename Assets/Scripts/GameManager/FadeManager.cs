using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{

    public Image fadeImage;               // Drag your FadeImage here
    public Camera mainCamera;             // Main camera reference
    public Cinemachine.CinemachineVirtualCamera cinemachineCamera; // Cinemachine Camera reference
    public float fadeDuration = 1f;       // Time for fade in/out

    private void Start()
    {
        StartCoroutine(PlayIntroSequence());
    }

    private IEnumerator PlayIntroSequence()
    {
        // Ensure fade starts fully black
        fadeImage.color = new Color(0, 0, 0, 0);

        // Play Cinemachine camera animation
        cinemachineCamera.Priority = 10; // Ensure Cinemachine is active
        yield return new WaitForSeconds(5.5f); // Wait for Cinemachine animation to finish (adjust this as needed)

        // Fade out to black
        yield return StartCoroutine(FadeOut());

        // Switch to Main Camera
        cinemachineCamera.Priority = 0; // Lower Cinemachine priority
        mainCamera.gameObject.SetActive(true);

        // Fade in from black
        yield return StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, elapsedTime / fadeDuration); // Fade from black to transparent
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, elapsedTime / fadeDuration); // Fade from transparent to black
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }
}
