using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrsytalPurple : Collactable
{
    protected override void OnPlayer(Character character)
    {
        character.StartLight();
    }
}
