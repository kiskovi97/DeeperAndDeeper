using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    new Collider2D collider;
    new SpriteRenderer renderer;
    Animator animator;
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
            collider.isTrigger = false;
            renderer.enabled = true;
            animator.SetTrigger("Shut");
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
