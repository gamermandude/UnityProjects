using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizard : MonoBehaviour {


    int max = 1000;
    int min = 1;
    int guess = 500;
	// Use this for initialization
	void Start () {
        max++;

        print("welcome to number wizard");
        print("Pick a number in your head from 1 to 1000");

        print("The highest number you can pick is " + max);
        print("The lowest number you can pick is " + min);

        print("Is the number higher or lower than " + guess + "?");

        print("Press up arrow for higher, down arrow for lower, return for equals.");

        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = guess;
            guess = (min + max) / 2;
            print("Higher or lower than" + guess);
            //print("up arrow pressed");
        } else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess;
            guess = (min + max) / 2;
            print("higher or lower than" + guess);

            //print("down arrow pressed");
        } else if (Input.GetKeyDown(KeyCode.Return))
        {
            print("Enter pressed.");
        }
	}
}
