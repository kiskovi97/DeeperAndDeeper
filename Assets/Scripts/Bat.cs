using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Vector2Extension
{
    public static Vector3 Rotate(this Vector3 v, float degree)
    {
        float sin = Mathf.Sin(degree * Mathf.Deg2Rad);
        float cos = Mathf.Cos(degree * Mathf.Deg2Rad);

        float tx = v.x;
        float ty = v.y;

        v.x = (cos * tx) - (sin * ty);
        v.y = (sin * tx) + (cos * ty);

        return v;
    }
}
public class Bat : MonoBehaviour
{
    public float speed = 2f;

    private Vector3 direction = Vector3.down;

    // Update is called once per frame
    void Update()
    {
        direction = direction.Rotate(Time.deltaTime * 20f);

        //transform.Rotate(new Vector3(0, 0, Time.deltaTime * 20f));
        transform.position += direction * Time.deltaTime * speed;
        var hit = Physics2D.Raycast(transform.position, direction, 2f);
        if (hit.collider != null)
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);
            var pos = new Vector2(transform.position.x, transform.position.y);
            var distance = (hit.point - pos).magnitude;
            var correctionNeeded = (2f - distance) * 0.6f;
            //transform.Rotate(new Vector3(0, 0, Time.deltaTime * correctionNeeded * 90));

            direction = direction.Rotate(Time.deltaTime * correctionNeeded * 90f);
            transform.position -= direction * Time.deltaTime * speed * correctionNeeded;
        }
        Debug.DrawLine(transform.position, transform.position + new Vector3(direction.x, direction.y), Color.green);
    }
}
