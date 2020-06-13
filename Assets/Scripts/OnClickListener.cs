using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickListener : MonoBehaviour
{
    public Dropdown Dropdown;

    public GameObject Settings;

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

    public void SetSettings()
    {
        if (Settings.activeSelf)
        {
            Settings.SetActive(false);

        } else
        {
            Settings.SetActive(true);
            Dropdown.value = GameState.RotationMovement ? 1 : 0;
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
