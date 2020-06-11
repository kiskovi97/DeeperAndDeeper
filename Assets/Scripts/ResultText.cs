using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultText : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
       
        var maxScore = PlayerPrefs.GetFloat("MaxScore");
        var maxTime = PlayerPrefs.GetFloat("MaxTime");

        if (maxTime < GameState.deltaTime)
        {
            maxTime = GameState.deltaTime;
        }

        if (maxScore < GameState.score)
        {
            maxScore = GameState.score;
        }

        scoreText.text = "Score: " + GameState.score.ToString("#0") + "/" + maxScore.ToString("#0");
        scoreText.text += "\nTime: " + GameState.deltaTime.ToString("#0") + "/" + maxTime.ToString("#0");

        PlayerPrefs.SetFloat("MaxScore", maxScore);
        PlayerPrefs.SetFloat("MaxTime", maxTime);
    }

}
