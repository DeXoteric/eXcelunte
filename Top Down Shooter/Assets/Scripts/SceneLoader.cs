using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private float gameOverDelay;

    public void LoadMainMenu()
    {
        GameManager.instance.GameStarted = false;
        SceneManager.LoadScene("Main Menu");
    }

    public void LoadGame()
    {
        GameManager.instance.GameStarted = false;
        SceneManager.LoadScene("Game");
        GameManager.instance.ResetGame();
    }

    public void LoadGameOver()
    {
        FindObjectOfType<EnemySpawner>().gameObject.SetActive(false);
        PoolManager.instance.DeactivateAllPooledObjects();
        StartCoroutine(GameOverCoroutine());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(gameOverDelay);
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }
}