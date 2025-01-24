//using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private int score;
    
    [SerializeField] Text scoreText;

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score:" + score.ToString("0");
    }

    public int ShowScore() 
    {
    return score;
    }
}
