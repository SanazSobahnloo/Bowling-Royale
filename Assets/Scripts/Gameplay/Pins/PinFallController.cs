using UnityEngine;
using System.Collections;
//using System.Diagnostics;

public class PinFallController : MonoBehaviour
{
    public static ScoreManager scoreManager;

    private bool isPinFall = false;


    public AudioSource audioSource;
    public AudioClip pinFallSound;  


    public static PinFallController Instance;

    //private void Awake()
    //{
    //    Instance = this;
    //}

    void Start()
    {

        //if (scoreManager == null)
        //{
        //    scoreManager = FindObjectOfType<ScoreManager>();
        //}
    }
    void Update()
    {
        //    if (!isPinFall && Vector3.Dot(transform.up, Vector3.up) < 0.7f) // Checks if the pin has fallen by comparing its vertical alignment.
        //    {
        //        scoreManager.AddScore(1);    
        //        isPinFall = true;
        //        Invoke("RemovePin", 3.0f);

        //    }

        
        if (!isPinFall && Vector3.Dot(transform.up, Vector3.up) < 0.7f)
        {
            Debug.Log("Pin has fallen!"); 
            isPinFall = true;


            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddScore(1);
            }
            else
            {
                Debug.LogWarning("ScoreManager is missing!");
            }

             Invoke("RemovePin", 3.0f); 
        }
        
        
        
    }


    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Ball"))
        {
          
            audioSource.PlayOneShot(pinFallSound);
        }
    }

    void RemovePin()
    {
    //if (isPinFall)
    //{
    //        Destroy(gameObject);
    //}



    Debug.Log("Removing pin...");
    Destroy(gameObject);
    }

}
