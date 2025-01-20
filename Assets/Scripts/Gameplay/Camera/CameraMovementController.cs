using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    [SerializeField] Transform ball;
    [SerializeField] Vector3 offset = new Vector3(0, 0, -5);
    [SerializeField] float smoothSpeed = 5f;

    private void Start()
    {

    }


    private void LateUpdate()
    {
        if (ball != null)
        {
            Vector3 targetPosition = ball.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
            transform.LookAt(ball.position);
        }
    }

}
