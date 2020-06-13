using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public Sprite play;
    public Sprite pause;

    private Image spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<Image>();
    }

    public void SetPlay()
    {
        spriteRenderer.sprite = play;
    }

    public void SetPause()
    {
        spriteRenderer.sprite = pause;
    }
}
