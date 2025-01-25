//using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
            Instance = this;
    }

    public void CheckGameResult(int playerScore, int maxScore)
    {
        if (playerScore >= maxScore)
        {
            PlayerPrefs.SetInt("Score", playerScore); ;
            PlayerPrefs.SetString("GameResult", "Strike, great job!");
            PlayerPrefs.Save();
            SceneManager.LoadScene("Results"); // ?? ???? ????? ???
        }
        else
        {
            PlayerPrefs.SetInt("Score", playerScore);
            PlayerPrefs.SetString("GameResult", "Your score");
            PlayerPrefs.Save();
            SceneManager.LoadScene("Results");
        }
    }

    private bool AllThrowsUsed()
    {
        // Implement logic to check if the player has used all allowed throws
        return BallMovementController.Instance.ShowCurrentThrow() >= 2; // Example for max 2 throws
    }

    private void LoadResultScene()
    {
        SceneManager.LoadScene("Results"); ; // Replace with the name of your result scene
    }
}
