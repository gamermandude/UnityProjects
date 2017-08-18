using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour
{
    int max;
    int min;
    int guess;

    int maxGuessesAllowed = 10;
    public Text textGuess;

	// Use this for initialization
	void Start ()
    {
        max = 1000;
        min = 1;
        guess = 500;
        max++;
	}

    public void GuessHigher()
    {
        min = guess;
        NextGuess();
    }

    public void GuessLower()
    {
        max = guess;
        NextGuess();
    }
    private void NextGuess()
    {
        guess = (min + max) / 2;
        textGuess.text = guess.ToString();
        maxGuessesAllowed--;
        if(maxGuessesAllowed < 1)
        {
            Application.LoadLevel("Win");
        }
    }
}
