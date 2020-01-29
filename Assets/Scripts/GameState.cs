using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public static GameState instance;
    public AudioSource menu;
    public AudioSource game;
    public float soundMix = 2f;

    public int MenuScene = 0;
    public int GameScene = 1;

    public static float score = 0;

    public static void AddScore(float addScore)
    {
        score += addScore;
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

    private bool InGame = false;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Quit();
        }
        if (InGame)
        {
            if (menu.volume > 0)
            {
                menu.volume -= Time.deltaTime / soundMix;
            }
            if (game.volume < 1)
            {
                game.volume += Time.deltaTime / soundMix;
            }
        } else
        {
            if (game.volume > 0)
            {
                game.volume -= Time.deltaTime / soundMix;
            }
            if (menu.volume < 1)
            {
                menu.volume += Time.deltaTime / soundMix;
            }
        }

    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(MenuScene);
        InGame = false;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(GameScene);
        InGame = true;
    }
}
