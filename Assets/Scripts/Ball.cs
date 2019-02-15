using UnityEngine;

public class Ball : MonoBehaviour
{
    private PaddleController paddle;
    private Rigidbody2D myRigidbody;
    private AudioSource audioSource;
    private bool hasStarted = false;
    private float xVelocity = 6f, yVelocity = 15f;
    
    void Start()
    {
        paddle = FindObjectOfType<PaddleController>();
        myRigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        LockBallToPaddle();
        if (Input.GetMouseButtonDown(0) && !hasStarted)
        {
            hasStarted = true;
            myRigidbody.velocity = new Vector2(2f, 15f);
        }
    }

    private void LockBallToPaddle()
    {
        if (!hasStarted)
        {
            float offsetFromPaddle = 0.25f;
            Vector2 paddlePos = paddle.transform.position;
            float ballYPos = paddlePos.y + offsetFromPaddle;
            transform.position = new Vector2(paddlePos.x, ballYPos);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PaddleController>())
        {
            float paddlePos = paddle.transform.position.x;
            float ballPos = this.transform.position.x;
            float xOffSet = (ballPos - paddlePos) * xVelocity;
            myRigidbody.velocity = new Vector2(xOffSet, yVelocity);
        }
        if (hasStarted)
        {
            audioSource.Play();
        }
    }

    public bool GetHasStarted()
    {
        return hasStarted;
    }
}
