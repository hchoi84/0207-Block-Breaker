using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private int blocks = 0;

    public void AddBlock()
    {
        blocks++;
    }

    public void SubtractBlock()
    {
        blocks--;
        if(blocks == 0)
        {
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene + 1);
    }

    public void LoadLevel1()
    {
        FindObjectOfType<GameStatus>().DestroySelf();
        SceneManager.LoadScene(1);
    }

    public void LoadLoseScene()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
