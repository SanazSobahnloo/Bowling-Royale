using UnityEngine;
using System.Collections;

public class BallMovementController : MonoBehaviour
{
    public ResetBall resetBall;
    public static BallMovementController Instance;

   [SerializeField] private GameObject ballResetPosition;
    [SerializeField] int maxThrows = 2;
    private int currentThrow = 0;
    private Vector3 ballPosition;

    private Vector2 _startPosition;
    private Vector2 _endPosition;
    private bool _isDragging = false;

    public float forceMultiplier = 10f; // Adjust the force applied to the ball
    private Rigidbody _rigidbody;

    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {

        if (resetBall == null)
        {
            resetBall = FindObjectOfType<ResetBall>();
        }

        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false; // Disable gravity until the ball is launched
    }

    void Update()
    {
        HandleInput();
        ballPosition = transform.position;
        EnableNextThrow();

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
        if (Input.touchCount > 0 && maxThrows > currentThrow)
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
        if (maxThrows > currentThrow)
        {
            Vector2 direction = (_startPosition - _endPosition).normalized; // Calculate drag direction
            float distance = Vector2.Distance(_startPosition, _endPosition); // Calculate drag distance
            _rigidbody.useGravity = true; // Enable gravity
            _rigidbody.AddForce(new Vector3(direction.x, 0, direction.y) * distance * forceMultiplier); // Apply force

            currentThrow++;
            FindObjectOfType<ThrowBallIconManager>().ThrowBall();
            StartCoroutine(WaitForBallToStop());

            //if (BallMovementController.Instance.ShowCurrentThrow() >= 2)
            //{
            //    GameManager.Instance.CheckGameResult(ScoreManager.Instance.ShowScore(), 10); // ????
            //}

        }

    }



    private IEnumerator WaitForBallToStop()
    {

        while (ballPosition.z < ballResetPosition.transform.position.z)
        {
            yield return null; 
        }

        
        Invoke("CheckGameStatus", 3.0f);
    }



    public int ShowCurrentThrow()
    {
      return  currentThrow;

    }


    void EnableNextThrow()
    {

        if (maxThrows > currentThrow)
        {
            if (ballPosition.z > ballResetPosition.transform.position.z)
            {
                Invoke("CallResetBallPosition", 3.0f);
            }
        }
        else
        {
            Debug.Log("Game Over. No more throws left.");
        }

    }
    void CallResetBallPosition()
    {
        if (resetBall != null )
        {
            resetBall.ResetBallPosition();  
          
            
        }
            //PinFallController.Instance.RemovePin();     // Call Method to remove the pin
             CameraCollisionController.Instance.SwitchToMainCamera(); // Call Switch To MainCamera Method

    }

    private void CheckGameStatus()
    {
        int score = ScoreManager.Instance.ShowScore();
        if (currentThrow >= maxThrows)
        {    
            if (score >= 10) 
            {
                Debug.Log("Player Wins!");
                GameManager.Instance.CheckGameResult(score, 10); 
            }
            else
            {
                Debug.Log("Player Loses!");
                GameManager.Instance.CheckGameResult(score, 10); 
            }
        }
        else if (score >= 10)
        {
            Debug.Log("Player Wins!");
            GameManager.Instance.CheckGameResult(score, 10);
        }
    }
}
