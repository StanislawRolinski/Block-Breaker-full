using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBlock : MonoBehaviour
{
    // config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFS;
    [SerializeField] Sprite[] hitSprites;


    // cached ref
    BlockCount blockCount;

    //state var
    [SerializeField] int timesHit;


    

    private void Start()
    {
        CountBreakableBlockes();
    }

    private void CountBreakableBlockes()
    {
        blockCount = FindObjectOfType<BlockCount>();
        if (tag == "Breakable")
        {
           
            blockCount.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            HandHit();

        }
    }

    private void HandHit()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
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
        if(hitSprites[timesHit - 1] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
        }
        else
        {
            Debug.LogError("Block sprite is missing from array " + gameObject.name);
        }
        
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        blockCount.BlockDestroyed();
        FindObjectOfType<GameStatus>().AddToScore();
        TriggerSparkelsVFX();
    }

    void TriggerSparkelsVFX()
    {
        GameObject sparkeles = Instantiate(blockSparklesVFS, transform.position, transform.rotation);
        Destroy(sparkeles, 1f);
    }
}
