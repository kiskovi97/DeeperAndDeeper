using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    new Collider2D collider;
    new SpriteRenderer renderer;
    Animator animator;
    public Labyrinth labyrinth;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
        renderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            var pos = collision.gameObject.transform.position;
            var me = transform.position;
            if (pos.y < me.y)
            {
                collider.isTrigger = false;
                renderer.enabled = true;
                animator.SetTrigger("Shut");
                if (GameState.instance == null || GameState.instance.game == null)
                    return;
                var time = GameState.instance.game.time;
                GameState.instance.game.clip = labyrinth.clip;
                GameState.instance.game.Play();
                GameState.instance.game.time = time;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
