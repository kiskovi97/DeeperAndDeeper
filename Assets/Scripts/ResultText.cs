using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultText : MonoBehaviour
{

    public TextMeshProUGUI scoreText;

    public bool OnlyTop = false;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
       
        var maxScore = PlayerPrefs.GetFloat("MaxScore");
        var maxTime = PlayerPrefs.GetFloat("MaxTime");

        if (OnlyTop)
        {
            scoreText.text = "Top score: " + maxScore.ToString("#0") + " - Top time: " + maxTime.ToString("#0");
            return;
        }


        if (maxTime < GameState.deltaTime)
        {
            maxTime = GameState.deltaTime;
        }

        if (maxScore < GameState.score)
        {
            maxScore = GameState.score;
        }

        scoreText.text = "Actual score: " + GameState.score.ToString("#0") + "\nTop score: " + maxScore.ToString("#0");
        scoreText.text += "\nActual time: " + GameState.deltaTime.ToString("#0") + "\nTop time: " + maxTime.ToString("#0");

        PlayerPrefs.SetFloat("MaxScore", maxScore);
        PlayerPrefs.SetFloat("MaxTime", maxTime);
        PlayerPrefs.Save();
    }

}
