using Assets.Scripts;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject[] labyrinths;


    // Start is called before the first frame update
    void Start()
    {
        var prevHeight = 0;
        for (int i=0; i<10; i++)
        {
            int index = (int)(Random.value * labyrinths.Length);
            var obj = Instantiate(labyrinths[index], transform);
            var lab = obj.GetComponent<Labyrinth>();
            obj.transform.localPosition = Vector2.down * (prevHeight);
            prevHeight += lab.height;
        }

    }
}
