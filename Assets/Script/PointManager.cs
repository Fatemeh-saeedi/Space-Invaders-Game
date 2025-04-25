using System;
using UnityEngine;
using TMPro;

public class PointManager:MonoBehaviour
{
    public int score; 
    public TMP_Text scoreText;

    public void UpdateScore(int points)
    {
        score += points;
        scoreText.text = "Score: "+score;
    }
}
