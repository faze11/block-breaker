using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    private int spriteIndex = 0;
    private LevelManager levelManager;
    public Sprite[] hitSprites;
    public bool IsBreakable;
    private int timesHit = 0;
    public static int breakableCount = 0;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (IsBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;
        if (hitSprites != null && hitSprites.Length > 0 && timesHit <= hitSprites.Length)
        {
            LoadSprites();
        }
        else
        {
            // destroy brick
            Destroy(this.gameObject);
            breakableCount--;

            if (breakableCount <= 0)
            {
                // you win
                levelManager.LoadNextLevel();
            }
        }
    }

    void LoadSprites()
    {
        spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

	// Use this for initialization
	void Start () {
        this.timesHit = 0;
        this.levelManager = FindObjectOfType<LevelManager>();
        if (IsBreakable)
            breakableCount++;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
