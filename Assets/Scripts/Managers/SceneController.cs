using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
        
        if (Input.GetButtonDown("Cancel"))
        {
            QuitGame();
        }       
    }

    [ContextMenu("Restart current level")]
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    [ContextMenu("Go to next level")]
    public void GoToNextLevel()
    {
        StartCoroutine(GoToNextLevelRoutine());
    }

    private IEnumerator GoToNextLevelRoutine()
    {
        int current = SceneManager.GetActiveScene().buildIndex;
        int next = current + 1;

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(next, LoadSceneMode.Single);
    }

    [ContextMenu("Quit Game")]
    public void QuitGame()
    {
        Application.Quit();
    }

    [ContextMenu("Go to win screen")]
    public void GoToWinScreen()
    {
        SceneManager.LoadScene("WinScreen", LoadSceneMode.Single);
    }

    [ContextMenu("Go to lose screen")]
    public void GoToLoseScreen()
    {
        SceneManager.LoadScene("LoseScreen", LoadSceneMode.Single);
    }

}
