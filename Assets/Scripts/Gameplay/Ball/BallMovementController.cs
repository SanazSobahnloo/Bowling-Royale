using UnityEngine;

public class BallMovementController : MonoBehaviour
{
    private Vector2 _startPosition;
    private Vector2 _endPosition;
    private bool _isDragging = false;

    public float forceMultiplier = 10f; // Adjust the force applied to the ball
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false; // Disable gravity until the ball is launched
    }

    void Update()
    {
        HandleInput();
    }

    // Handle touch input for dragging and launching the ball
    private void HandleInput()
    {
#if UNITY_EDITOR
        // for our testing
        if (Input.GetMouseButtonDown(0)) 
        {
            _startPosition = Input.mousePosition;
            _isDragging = true;
        }

        if (Input.GetMouseButtonUp(0) && _isDragging) 
        {
            _endPosition = Input.mousePosition;
            LaunchBall();
            _isDragging = false;
        }
#else
        // for mobile devices
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _startPosition = touch.position;
                _isDragging = true;
            }

            if (touch.phase == TouchPhase.Ended && _isDragging)
            {
                _endPosition = touch.position;
                LaunchBall();
                _isDragging = false;
            }
        }
#endif
    }

    // Launch the ball based on drag input
    private void LaunchBall()
    {
        Vector2 direction = (_startPosition - _endPosition).normalized; // Calculate drag direction
        float distance = Vector2.Distance(_startPosition, _endPosition); // Calculate drag distance
        _rigidbody.useGravity = true; // Enable gravity
        _rigidbody.AddForce(new Vector3(direction.x, 0, direction.y) * distance * forceMultiplier); // Apply force
    }
}
