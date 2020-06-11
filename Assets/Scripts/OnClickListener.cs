using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickListener : MonoBehaviour
{
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
}
