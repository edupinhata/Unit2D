using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        Invoke("GoNextScene", 0.2f);
    }

    public void GoNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("sceneCount = " + SceneManager.sceneCountInBuildSettings);
        int nextSceneIndex = currentSceneIndex + 1;
        SceneManager.LoadScene(nextSceneIndex % (SceneManager.sceneCountInBuildSettings));
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        GameSession gameSession = FindObjectOfType<GameSession>();
        if (gameSession != null)
        {
            gameSession.ResetScore();
        }        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
