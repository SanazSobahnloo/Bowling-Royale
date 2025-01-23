using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryGuide : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Transform ball;
    public float sensitivity = 0.3f;

    public float lineLength = 5f;
    private Vector3 dragStartPos;
    private Vector3 smoothDirection= Vector3.zero;
    private bool isDragging = false;

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
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.WorldToScreenPoint(ball.position).z;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        return new Vector3(worldPos.x, ball.position.y, worldPos.z);
    }

}
