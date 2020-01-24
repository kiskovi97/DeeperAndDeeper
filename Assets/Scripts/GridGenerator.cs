using Assets.Scripts;
using System.Collections;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject[] labyrinths;

    public GameObject player;

    private float prevHeight = 0;
    private int entryPoint = -1;

    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<2; i++)
        {
            NewGrid();
        }
    }

    private void Update()
    {
        if (player.transform.position.y - 20 < prevHeight * -1)
        {
            NewGrid();
        }
    }

    void NewGrid()
    {
        int index = (int)(Random.value * labyrinths.Length);
        var obj = Instantiate(labyrinths[index], transform);
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
