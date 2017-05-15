using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        print("You lose");
        var levelManager = GameObject.FindObjectOfType<LevelManager>();
        levelManager.LoadLevelByName("GameOver");
    }
}
