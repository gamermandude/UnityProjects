using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("COLLIDED!!!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("TRIGGERED...");
        var level = new LevelManager();
        level.LoadLevel("Lose");
    }
}
