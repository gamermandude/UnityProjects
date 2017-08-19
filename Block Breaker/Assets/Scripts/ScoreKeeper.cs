using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreKeeper
{
    public static int Score = 0;
    public static int Lives = 3;
    public static List<Scores> Scores;

    public static void Reset()
    {
        if (Scores == null) Scores = new List<Scores>();
        Scores.Add(new Scores { HighScore = Score, date = DateTime.Now, Initials = "UNK" });
        Score = 0;
        Lives = 3;
    }
}

public class Scores
{
    public string Initials;
    public int HighScore;
    public DateTime date;
}