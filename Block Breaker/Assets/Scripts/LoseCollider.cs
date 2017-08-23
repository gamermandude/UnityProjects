using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private Ball theBall;
    private LevelManager levelManager;
	// Use this for initialization
	void Start ()
    {
        theBall = FindObjectOfType<Ball>();
        levelManager = FindObjectOfType<LevelManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("COLLIDED!!!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var ball = collision.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            ScoreKeeper.Lives--;
            ball.Reset();
            Brick.TotalBricks = 0;

            if (ScoreKeeper.Lives < 1)
            {
                ScoreKeeper.Reset();
                print("TRIGGERED...");
                levelManager.LoadLevel("Lose");
            }
        }
    }
}
