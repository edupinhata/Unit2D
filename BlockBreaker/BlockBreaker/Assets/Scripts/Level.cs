using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    [SerializeField] int breakableBlocks; // Serialized for debugging purposes

    // Cached reference
    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void TryGoNextLevel()
    {
        breakableBlocks -= 1;

        if (breakableBlocks <= 0)
        {
            sceneLoader.LoadNextScene(); 
        }
    }

    public int GetBreakableBlocks()
    {
        return breakableBlocks;
    }
}
