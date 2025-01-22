using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBall : MonoBehaviour
{
    public static ResetBall instance;

    [SerializeField] Transform ball;
    [SerializeField] Rigidbody ballRB;
    [SerializeField] Transform ballStartPos;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    public void ResetBallPosition() 
    {
        ball.position = ballStartPos.position;
        ballRB.velocity = Vector3.zero;
        ballRB.angularVelocity = Vector3.zero;

    }
}
