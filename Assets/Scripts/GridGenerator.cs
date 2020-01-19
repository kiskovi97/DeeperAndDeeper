using Assets.Scripts;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject[] labyrinths;


    // Start is called before the first frame update
    void Start()
    {
        int index = (int)(Random.value * labyrinths.Length);
        var obj = Instantiate(labyrinths[index], transform);
        var lab = obj.GetComponent<Labyrinth>();

        int index2 = (int)(Random.value * labyrinths.Length);
        var obj2 = Instantiate(labyrinths[index2], transform);
        obj2.transform.localPosition = Vector2.down * lab.height;

    }
}
