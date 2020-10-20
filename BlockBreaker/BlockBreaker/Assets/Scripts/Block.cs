using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blocksparklesVFX;

    // Cached reference
    Level level;
    GameSession gameSession;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();
        gameSession = FindObjectOfType<GameSession>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayCollision();
        DestroyBlock();
        
    }

    private void DestroyBlock()
    {
        level.TryGoNextLevel();
        TriggerSparklesVFX();
        Destroy(gameObject);
        gameSession.AddToScore();
        
    }

    private void PlayCollision()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blocksparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1.0f);
     
    }

}
