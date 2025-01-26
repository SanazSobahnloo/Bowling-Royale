using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class ThrowBallIconManager : MonoBehaviour
{
    public static ThrowBallIconManager Instance;

    public int maxThrows = 2;
    private int remainingThrows;

    [SerializeField] private List<GameObject> DisableBallIconList = new List<GameObject>();
    [SerializeField] private List<GameObject> EnableBallIconList = new List<GameObject>();

    public Image[] ballImages;

    public Sprite EnableBallSprite;
    public Sprite DisableBallSprite;


    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {

        remainingThrows = maxThrows;
        UpdateBallImages();
    }

    public void ThrowBall()
    {
        if (remainingThrows > 0)
        {

            remainingThrows--;


            UpdateBallImages();
        }
        else
        {
            Debug.Log("No throws remaining!");
        }
    }

    void UpdateBallImages()
    {
        for (int i = 0; i < ballImages.Length; i++)
        {
            if (i < remainingThrows)
            {

                ballImages[i].sprite = EnableBallSprite;
            }
            else
            {

                ballImages[i].sprite = DisableBallSprite;
            }
        }
    }
}
