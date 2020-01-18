using Assets.Scripts;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public TileMapHelper helper;

    public int height = 10;
    public int width = 10;

    private int[,] matrix;

    // Start is called before the first frame update
    void Start()
    {
        matrix = LabyrinthGenerator.Generate(height, width, new Vector2(width / 2, 0), new Vector2(width/2, height - 1));

        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
            {
                if (matrix[i, j] == 0)
                {
                    var obj = GenerateWall(i, j);
                    if (obj != null)
                    {
                        obj.transform.localPosition = new Vector3(i - width / 2, -j);
                    }
                }
                else
                {
                    var obj = helper.GetSimple();
                    obj.transform.localPosition = new Vector3(i - width / 2, -j);
                }
            }

    }

    private GameObject GenerateWall(int i, int j)
    {
        int code = 0;
        if (j > 0 && matrix[i , j - 1] > 0)
        {
            code += 8;
        }
        if (j < height - 1 && matrix[i, j + 1] > 0)
        {
            code += 2;
        }
        if (i < width - 1 && matrix[i + 1, j] > 0)
        {
            code += 1;
        }
        if (i > 0 && matrix[i - 1, j] > 0)
        {
            code += 4;
        }
        return helper.Get(code);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
