using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collactable : MonoBehaviour
{
    public AudioClip clip;
    public ParticleSystem explosion;
    public SpriteRenderer sprite;
    public float timer = 0f;
    public bool isDestroying = false;
    private void Awake()
    {
        explosion = GetComponent<ParticleSystem>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isDestroying && collision.gameObject.tag.Equals("Player"))
        {
            Character character = collision.gameObject.GetComponent<Character>();
            OnPlayer(character);
            if (clip != null)
            {
                AudioSource.PlayClipAtPoint(clip, transform.position);
            }
            CinemachineShake.ShakeCamera(3f, 0.3f);
            isDestroying = true;
            timer = 1f;
            if (explosion != null)
            {
                explosion.Play();
            }
            if (sprite != null)
            {
                sprite.enabled = false;
            }
        }
    }

    private void Update()
    {
        if (isDestroying)
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                Destroy(gameObject, 0.1f);
            }
        }
    }

    protected abstract void OnPlayer(Character character);
}
