using UnityEngine;
using System.Collections;

public class PinFallController : MonoBehaviour
{
    public static ScoreManager scoreManager;

    private bool isPinFall = false;


    public static PinFallController Instance;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {

        if (scoreManager == null)
        {
            scoreManager = FindObjectOfType<ScoreManager>();
        }
    }
    void Update()
    {
        if (!isPinFall && Vector3.Dot(transform.up, Vector3.up) < 0.7f) // Checks if the pin has fallen by comparing its vertical alignment.
        {
            scoreManager.AddScore(1);    
            isPinFall = true;
            Invoke("RemovePin", 3.0f);

        }

    }

    void RemovePin()
    {
        if (isPinFall)
        {
                Destroy(gameObject);
        }
    
    }

}
