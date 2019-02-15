using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip destroySound;
    [SerializeField] private int rewardPoints = 2;
    [SerializeField] private GameObject blockDestructionParticle;
    [SerializeField] private int health;
    private LevelLoader levelLoader;
    private GameStatus gameStatus;
    private Color[] blockColor = {
        new Color(255,255,255), new Color(148,0,211), new Color(75,0,130),
        new Color(0,0,255), new Color(0,255,0), new Color(255,255,0),
        new Color(255,127,0), new Color(255,0,0) };

    private void Start()
    {
        gameStatus = FindObjectOfType<GameStatus>();
        levelLoader = FindObjectOfType<LevelLoader>();
        levelLoader.AddBlock();
        GetComponent<SpriteRenderer>().color = blockColor[health - 1];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        if (health < 1)
        {
            ProcessDestruction();
        }
        else
        {
            GetComponent<SpriteRenderer>().color = blockColor[health - 1];
        }
    }

    private void ProcessDestruction() {
        AudioSource.PlayClipAtPoint(destroySound, Camera.main.transform.position, .25f);
        GameObject destructionVFX = Instantiate(blockDestructionParticle, transform.position, Quaternion.identity);
        Destroy(destructionVFX, 2f);
        levelLoader.SubtractBlock();
        gameStatus.AddPointsEarned(rewardPoints);
        Destroy(gameObject);
    }
}
