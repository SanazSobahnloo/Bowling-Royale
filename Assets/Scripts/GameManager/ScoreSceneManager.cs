using UnityEngine;
using UnityEngine.UI;
//using static System.Net.Mime.MediaTypeNames;


public class ScoreSceneManager : MonoBehaviour
{

    [SerializeField] private Text ScoreText; // Assign via Inspector
    [SerializeField] private Text resultText;
    private void Start()
    {
        // Retrieve and display the game result
        int playerScore = PlayerPrefs.GetInt("Score", 0);
        ScoreText.text = playerScore.ToString();
        string gameResult = PlayerPrefs.GetString("GameResult", "No Result");
        resultText.text = gameResult;

    }
}

