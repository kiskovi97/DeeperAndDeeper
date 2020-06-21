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

    private float time = 0f;

    // Update is called once per frame
    void Update()
    {
        direction = direction.Rotate(Time.deltaTime * 20f);

        //transform.Rotate(new Vector3(0, 0, Time.deltaTime * 20f));
        transform.position += direction * Time.deltaTime * speed;
    }
}
