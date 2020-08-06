using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] Text scoreText;
    int score = 0;
    float difficultyConst = 1;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "SCORE: " + score;
    }

    public void UpdateScore(int val)
    {
        score += val;
        if (score % 10 == 0) difficultyConst *= 0.9f; 
        scoreText.text = "SCORE: " + score;
    }

    public float getDifficultyConst()
    {
        return difficultyConst;
    }
}
