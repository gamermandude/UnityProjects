using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    public int maxHits;
    public int timesHit;

	// Use this for initialization
	void Start () {
        timesHit = 0;
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("timeshit " + timesHit);
        print("maxhits " + maxHits);

        timesHit++;
        if(timesHit >= maxHits)
        {
            Destroy(gameObject);
            ScoreKeeper.Score += maxHits * 1000;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
