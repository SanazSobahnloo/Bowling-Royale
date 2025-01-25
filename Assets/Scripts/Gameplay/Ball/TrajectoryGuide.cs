using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryGuide : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;

    [SerializeField]  Camera customCamera;
    [SerializeField] Transform ball;
    [SerializeField] float sensitivity = 0.3f;

    [SerializeField] float lineLength = 5f;
    private Vector3 dragStartPos;
    private Vector3 smoothDirection= Vector3.zero;
    private bool isDragging = false;

    private void Start()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            //mainCamera.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragStartPos = GetMouseWorldPosition();
            isDragging = true;
        }
        else if (Input.GetMouseButton(0) && isDragging)
        {
            DrawGuideLine();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            lineRenderer.positionCount = 0;
            isDragging = false;
        }
    }

    void DrawGuideLine()
    {
        Vector3 currentMousePos = GetMouseWorldPosition();
        Vector3 launchDirection = (dragStartPos - currentMousePos).normalized;

        launchDirection *= sensitivity;

        Vector3 startPoint = ball.position;
        Vector3 endPoint = startPoint + launchDirection * lineLength;

        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endPoint);
    }

    Vector3 GetMouseWorldPosition()
    {
        //    Vector3 mousePos = Input.mousePosition;
        //    mousePos.z = customCamera.WorldToScreenPoint(ball.position).z;
        //    Vector3 worldPos = customCamera.ScreenToWorldPoint(mousePos);

        //    return new Vector3(worldPos.x, ball.position.y, worldPos.z);

        Vector3 mousePos = Input.mousePosition;

        if (customCamera != null)
        {
            mousePos.z = customCamera.WorldToScreenPoint(ball.position).z;
            Vector3 worldPos = customCamera.ScreenToWorldPoint(mousePos);

            return new Vector3(worldPos.x, worldPos.y, worldPos.z);
        }

        Debug.LogWarning("Custom camera is not assigned!");
        return Vector3.zero;
    }

}
