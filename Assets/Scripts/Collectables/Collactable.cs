using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collactable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            Character character = collision.gameObject.GetComponent<Character>();
            OnPlayer(character);
            Destroy(gameObject, 0.1f);
        }
    }

    protected abstract void OnPlayer(Character character);
}
