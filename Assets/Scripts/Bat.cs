using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public float speed = 2f;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * 20f));
        transform.position += transform.up * Time.deltaTime * speed;
        var hit = Physics2D.Raycast(transform.position, transform.up, 2f);
        if (hit.collider != null)
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            var pos = new Vector2(transform.position.x, transform.position.y);
            var distance = (hit.point - pos).magnitude;
            var correctionNeeded = (2f - distance) * 0.5f;
            transform.Rotate(new Vector3(0, 0, Time.deltaTime * correctionNeeded * 90));
            transform.position -= transform.up * Time.deltaTime * speed * correctionNeeded;
        }
    }
}
