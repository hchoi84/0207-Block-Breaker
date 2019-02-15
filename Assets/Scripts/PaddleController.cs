using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private float xMin = 1f, xMax = 15f;
    private float current = 0f, change = 3f, xOffSet = 0f;
    [SerializeField] private Ball ball;
    [SerializeField] private bool autoPlay = false;

    private void Start()
    {
        ball = FindObjectOfType<Ball>();
    }

    void Update()
    {
        if (!autoPlay)
        {
            MovePaddleWithMouse();
        }
        
        if (autoPlay)
        {
            MovePaddleWithBall();
        }
    }

    private void MovePaddleWithMouse()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float xLimit = Mathf.Clamp(mousePos.x, xMin, xMax);
        transform.position = new Vector2(xLimit, transform.position.y);
    }

    private void MovePaddleWithBall()
    {
        current += Time.deltaTime;
        Debug.Log(current);
        if(current >= change)
        {
            xOffSet = Random.Range(-0.5f, 0.5f);
            Debug.Log(xOffSet);
            current = 0f;
        }

        if (ball.GetHasStarted())
        {
            Vector2 ballPos = ball.transform.position;
            float xLimit = Mathf.Clamp(ballPos.x, xMin, xMax);
            transform.position = new Vector2(xLimit + xOffSet, transform.position.y);
        }
    }
}
