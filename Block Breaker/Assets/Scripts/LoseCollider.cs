using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour
{
    private Ball theBall;
	// Use this for initialization
	void Start ()
    {
        theBall = FindObjectOfType<Ball>();
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

            if (ScoreKeeper.Lives < 1)
            {
                ScoreKeeper.Reset();
                print("TRIGGERED...");
                var level = new LevelManager();
                level.LoadLevel("Lose");
            }
        }
    }
}
