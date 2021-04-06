using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI_Script : MonoBehaviour
{
    public Text scoreText;
    int score;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ("SCORE: " + score);

    }

    public void SetScore(int sentScore)
    {
        score = score + sentScore;
    }
}
