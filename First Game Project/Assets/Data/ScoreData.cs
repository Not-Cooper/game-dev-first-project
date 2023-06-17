using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ScoreData
{
    public int score;

    public ScoreData(LogicScript Logic)
    {
        this.score = Logic.getHighScore();
    }

    public ScoreData()
    {
        this.score = 0;
    }
}
