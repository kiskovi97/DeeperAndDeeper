using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static GameState instance;

    public float score = 0;

    public static void AddScore(float addScore)
    {
        instance.score += addScore;
    }

    private void Awake()
    {
        if (instance == null)
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag("GameState");

            if (objs.Length > 1)
            {
                Destroy(this.gameObject);
            }
            else
            {
                DontDestroyOnLoad(this.gameObject);
                instance = this.gameObject.GetComponent<GameState>();
            }
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Quit");
            Application.Quit();
        }
        scoreText.text = score.ToString();
    }
}
