using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickListener : MonoBehaviour
{

    public GameObject Settings;

    public PauseButton pauseButton;

    private void Awake()
    {
        var selected = PlayerPrefs.GetInt("RotationMovement");
        GameState.RotationMovement = selected != 0;
    }

    public void Quit()
    {
        GameState.Quit();
    }

    public void LoadMenu()
    {
        GameState.LoadMenu();
    }

    public void LoadGameOver()
    {
        GameState.GameOver();
    }

    public void LoadGame()
    {
        GameState.LoadTutorial();
    }

    private float timeScale = 1f;

    public void SetSettings()
    {
        if (Settings.activeSelf)
        {
            Settings.SetActive(false);
            Time.timeScale = timeScale;
            if (pauseButton != null) pauseButton.SetPause();

        } else
        {
            timeScale = Time.timeScale;
            Time.timeScale = 0f;
            Settings.SetActive(true);
            if (pauseButton != null) pauseButton.SetPlay();
        }
    }
}
