using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour
{
    LevelLoader levelLoader;

    private void Start()
    {
        levelLoader = FindObjectOfType<LevelLoader>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelLoader.LoadLoseScene();
    }
}
