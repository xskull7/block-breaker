using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    [SerializeField] Sprite[] blockSprites;
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject SparkelVfx;
    
    [SerializeField] int timesHit;
    
    level level;
    Gamestatus breakblock;
    private void Start()
    {
        level = FindObjectOfType<level>();
        if (tag == "Breakable")
        {
            level.countbreakableblock();
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        blockhits();
        breakblock = FindObjectOfType<Gamestatus>();
        level.breakedblock();
        breakblock.Score();

    }

    private void blockhits()
    {
        if (tag == "Breakable")
        {
            timesHit++;
            int Hitreq = blockSprites.Length + 1;
            if (timesHit>=Hitreq)
            {
                Destroy(gameObject);
                collisionspaarkleVFX();
            }
            else
            {
                Shownextblocksprite();
            }
        }
    }

    private void Shownextblocksprite()
    {
        int Spriteindex = timesHit - 1;
        if (blockSprites[Spriteindex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = blockSprites[Spriteindex];
        }
        else
        {
            Debug.LogError("Block Sprite is missing from array" + gameObject.name);
        }
    }

    private void collisionspaarkleVFX()
    {
        GameObject Sparkle = Instantiate(SparkelVfx, transform.position, transform.rotation);
        Destroy(Sparkle, 1f);
    }
}
