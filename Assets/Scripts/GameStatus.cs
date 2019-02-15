using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [Range(0.1f, 5)] [SerializeField] private float gameSpeed = 1f;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private int pointsEarned;

    private void Awake()
    {
        int singleton = FindObjectsOfType(GetType()).Length;
        if(singleton > 1)
        {
            gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Update()
    {
        Time.timeScale = gameSpeed;
        if (!score)
        {
            score = GameObject.Find("Score Text").GetComponent<TextMeshProUGUI>();
            score.text = pointsEarned.ToString();
        }
    }    

    public void AddPointsEarned(int points)
    {
        pointsEarned += points;
        score.text = pointsEarned.ToString();
    }

    public void DestroySelf()
    {
        Destroy(this.gameObject);
    }
}