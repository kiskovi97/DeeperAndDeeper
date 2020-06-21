using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : Collactable
{
    protected override void OnPlayer(Character character)
    {
        character.BatteryCharge();
    }
}
