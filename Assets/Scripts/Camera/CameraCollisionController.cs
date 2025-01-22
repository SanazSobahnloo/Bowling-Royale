using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollisionController : MonoBehaviour
{

    public static CameraCollisionController Instance;

   



    [SerializeField] private Camera mainCamera;
    [SerializeField] private Camera collisionCamera;
    [SerializeField] private GameObject ball;
    [SerializeField] private float switchDistance = 3f;
    [SerializeField] private float returnTime = 1.5f;

    private bool switched = false;



    private void Awake()
    {
        Instance = this;
    }


    private void Start()
    {
        mainCamera.gameObject.SetActive(true);
        collisionCamera.gameObject.SetActive(false);

    }
    private void Update()
    {
        if (!switched && ball.transform.position.z >= transform.position.z - switchDistance)

        {
            SwitchToCollisionCamera();


        }
    }


    void SwitchToCollisionCamera()
    {
        mainCamera.gameObject.SetActive(false);
        collisionCamera.gameObject.SetActive(true);
        switched = true;
        //Invoke("SwitchToMainCamera", returnTime);
    }

    public void SwitchToMainCamera()
    {
        mainCamera.gameObject.SetActive(true);
        collisionCamera.gameObject.SetActive(false);
        switched = false;
    }
}
