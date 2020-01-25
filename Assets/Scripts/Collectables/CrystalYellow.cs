using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalYellow : Collactable
{
    protected override void OnPlayer(Character character)
    {
        GameState.AddScore(1);
    }
}
