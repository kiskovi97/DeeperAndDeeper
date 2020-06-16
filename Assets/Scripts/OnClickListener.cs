using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickListener : MonoBehaviour
{
    public Dropdown Dropdown;

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

    private void LoadGameOver()
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
            Dropdown.value = GameState.RotationMovement ? 1 : 0;
            if (pauseButton != null) pauseButton.SetPlay();
        }
    }

    public void Save()
    {
        var selected = Dropdown.value;
        GameState.RotationMovement = selected != 0;
        PlayerPrefs.SetInt("RotationMovement", selected);
        SetSettings();
    }
}
