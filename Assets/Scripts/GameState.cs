﻿using System;
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
    public float deltaTimeQuicker = 1f;

    public int MenuScene = 0;
    public int GameScene = 1;
    public int GameOverScene = 2;

    public static float score = 0;
    public static float deltaTime = 0;

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
        } else
        {
            Destroy(gameObject);
        }
    }

    private bool InGame = false;

    private void Update()
    {
        Time.timeScale += 0.001f * deltaTimeQuicker * Time.deltaTime;
        if (Input.GetKey(KeyCode.Escape))
        {
            Quit();
        }
        if (InGame)
        {
            if (menu != null)
            {
                if (menu.volume > 0)
                {
                    menu.volume -= Time.deltaTime / soundMix;
                }
            }
            if (game != null)
            {
                if (game.volume < 1)
                {
                    game.volume += Time.deltaTime / soundMix;
                }
            }
        } else
        {
            if (game != null)
            {
                if (game.volume > 0)
                {
                    game.volume -= Time.deltaTime / soundMix;
                }
            }
            if (menu != null)
            {
                if (menu.volume < 1)
                {
                    menu.volume += Time.deltaTime / soundMix;
                }
            }
        }

    }

    public static void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public static void LoadMenu()
    {
        Cursor.visible = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(instance.MenuScene);
        instance.InGame = false;
    }

    public static void GameOver()
    {
        LoadGameOver();
    }

    private static void LoadGameOver()
    {
        Cursor.visible = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(instance.GameOverScene);
        instance.InGame = false;
    }

    public static void LoadGame()
    {
        Cursor.visible = false;
        Time.timeScale = 1f;
        score = 0;
        SceneManager.LoadScene(instance.GameScene);
        instance.InGame = true;
    }
}
