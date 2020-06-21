using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : Collactable
{
    protected override void OnPlayer(Character character)
    {
        GameState.LoadGame();
    }
}
