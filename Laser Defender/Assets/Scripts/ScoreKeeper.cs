using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    private static int CurrentScore;
    private Text text;

    void Start()
    {
        text = GetComponent<Text>();

    }
    public void Score(int points)
    {
        CurrentScore += points;
        text.text = string.Format("SCORE: {0:N0}", CurrentScore);
    }

    public void Reset()
    {
        CurrentScore = 0;
        
    }
}
