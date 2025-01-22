//using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    
    private int score;
    
    [SerializeField] Text scoreText;

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score:" + score.ToString("0");
    }
}
