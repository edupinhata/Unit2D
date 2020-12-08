using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blocksparklesVFX;
    //[SerializeField] int maxHits;
    [SerializeField] private Sprite[] hitSprites;

    // Cached reference
    Level level;
    GameSession gameSession;
    
    // State variables
    int hitsReceived = 0;

    private void Start()
    {
        CountBreakableBlocks();
        gameSession = FindObjectOfType<GameSession>();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayCollision();
        if (tag == "Breakable")
        {
            HandleHit();
        }
    }

    private void HandleHit()
    {
        hitsReceived++;
        int maxHits = hitSprites.Length + 1;
        if (hitsReceived >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = hitsReceived - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError(string.Format("Block sprite of index {0} is missing from array", gameObject.name));
        }
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
