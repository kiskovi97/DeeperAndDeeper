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
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = GameState.score + " in time: " + GameState.deltaTime;
    }
}
