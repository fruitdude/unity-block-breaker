using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour{

    //config params
    [SerializeField] AudioClip blockSound;
    [SerializeField] GameObject blockSparklesVFX;
    [SerializeField] Sprite[] hitSprites;

    //cached reference
    Level level;
    GameSession addPointsToScore;

    //state variables
    [SerializeField] int amountOfHitsTaken; //ONLY SERIALIZED FOR DEBUG PORPUSES
    

    private void Start() {
        addPointsToScore = FindObjectOfType<GameSession>();
        CountBreakableBlocks();

    }

    private void CountBreakableBlocks() {
        level = FindObjectOfType<Level>();
        if (tag == "breakable") {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (tag == "breakable") {
            HandleHits();
        }
    }
    
    //calculates the amount of hits a block needs before it is destroyed
    private void HandleHits() {
        amountOfHitsTaken++;
        int maxHits = hitSprites.Length + 1; //sets the number it needs to destroy a block to the size of the hitSprite[] array
        if (amountOfHitsTaken >= maxHits) {
            DestroyBlock();
        } else {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite() {
        int spriteIndex = amountOfHitsTaken - 1;
        if (hitSprites[spriteIndex] != null) {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        } else {
            Debug.LogError("Blcok sprite is missing from array" + gameObject.name);
        }
        
    }

    private void DestroyBlock() {
        AudioSource.PlayClipAtPoint(blockSound, Camera.main.transform.position);
        TriggerSparklesVFX();
        level.BlockDestroyed();
        addPointsToScore.AddToScore();
        Destroy(gameObject, 0.0f);
    }

    private void TriggerSparklesVFX() {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 2.0f);
    }
}
