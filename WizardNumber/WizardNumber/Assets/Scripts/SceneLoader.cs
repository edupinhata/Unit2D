using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("sceneCount = " + SceneManager.sceneCountInBuildSettings);
        SceneManager.LoadScene((currentSceneIndex + 1) % (SceneManager.sceneCountInBuildSettings));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
