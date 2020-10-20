using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseCollider : MonoBehaviour
{
    [SerializeField] string gameOverScene;
    GameSession gameStatus;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Game Over");
        gameStatus = FindObjectOfType<GameSession>();
        if (gameStatus != null)
        {
            gameStatus.ResetScore();
        }
    }
}
