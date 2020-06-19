using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreMadeGrid : MonoBehaviour
{
    public GameObject[] labyrinths;

    public Queue<GameObject> labs = new Queue<GameObject>();

    public GameObject player;

    private float prevHeight = 0;
    private int entryPoint = -1;
    // Start is called before the first frame update
    void Start()
    {
        int index = (int)(Random.value * labyrinths.Length);
        var obj = Instantiate(labyrinths[index], transform);

        labs.Enqueue(obj);

        var lab = obj.GetComponent<Labyrinth>();
        if (entryPoint == -1)
        {
            entryPoint = lab.width / 2;
        }
        entryPoint = lab.Generate(entryPoint);
        obj.transform.localPosition = Vector2.down * (prevHeight);
        prevHeight += lab.height;
    }
}
