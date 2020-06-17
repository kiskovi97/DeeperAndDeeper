using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    public Sprite play;
    public Sprite pause;

    public Image spriteRenderer;

    private void Awake()
    {
        if (spriteRenderer == null)
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
