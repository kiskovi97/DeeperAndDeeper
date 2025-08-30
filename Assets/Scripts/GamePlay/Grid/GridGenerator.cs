using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    private static GameObject[] labyrinths;
    
    public Queue<GameObject> labs = new Queue<GameObject>();

    public GameObject player;
    public LevelDesign levelDesign;

    private float prevHeight = 0;
    private int entryPoint = -1;

    public static void SetLevelDesigns(LevelDesign levelDesign)
    {
        labyrinths = levelDesign.labyrinths;
    }

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

            var obj = labs.Dequeue();
            Destroy(obj);
        }
    }

    void NewGrid()
    {
        if (labyrinths == null || labyrinths.Length == 0)
        {
            SetLevelDesigns(levelDesign);
        }
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
