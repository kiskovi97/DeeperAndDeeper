using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine;

public class Labyrinth : MonoBehaviour
{
    public TileMapHelper helper;
    public GameObject enemy;
    public GameObject battery;
    public GameObject[] crystals;

    public int height = 10;
    public int width = 10;
    public int crystalPerLevel = 10;

    public Texture2D texture;

    private int[,] matrix;
    public float enemyProbability = 0.05f;
    public float batteryProbability = 0.01f;
    public float crystalProbability = 0.05f;

    public bool PreMade = false;

    private void Start()
    {
        if (PreMade)
        {
            matrix = new int[height, width];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    var color = texture.GetPixel(i, j);
                    matrix[i, j] = (int)(color.grayscale / 10f);
                }
            CreateTiles();
        }
    }

    public int Generate(int entry)
    {
        int output = (int)(Random.value * (width - 2)) + 1;
        matrix = LabyrinthGenerator.Generate(height, width, new Vector2(entry, 0), new Vector2(output, height - 1));

        CreateTiles();

        return output;
    }

    private void CreateTiles()
    {
        var listOfPlaces = new List<Vector3>();

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
                    var obj = j == 0 ? helper.GetGate() : helper.GetSimple();
                    obj.transform.localPosition = new Vector3(i - width / 2, -j);
                    listOfPlaces.Add(new Vector3(i - width / 2, -j));
                    if (Random.value < enemyProbability)
                    {
                        var enemyObj = Instantiate(enemy, transform);
                        enemyObj.transform.localPosition = new Vector3(i - width / 2, -j);
                    }
                }
            }

        var batteryPlaceIndex = (int)(listOfPlaces.Count * Random.value);
        var battaeryPlace = listOfPlaces[batteryPlaceIndex];
        var batteryObj = Instantiate(battery, transform);
        batteryObj.transform.localPosition = battaeryPlace;
        listOfPlaces.RemoveAt(batteryPlaceIndex);

        for (int i=0; i< crystalPerLevel && listOfPlaces.Count > 0; i++)
        {
            var placeIndex = (int)(listOfPlaces.Count * Random.value);
            var place = listOfPlaces[placeIndex];
            GenerateCrystal(place);
            listOfPlaces.RemoveAt(placeIndex);
        }
    }

    private void GenerateCrystal(Vector2 point)
    {
        int index = (int)(crystals.Length * Random.value);
        var obj = Instantiate(crystals[index], transform);
        obj.transform.localPosition = point;
    }

    private GameObject GenerateWall(int i, int j)
    {
        int code = 0;
        if (j > 0 && matrix[i, j - 1] > 0)
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
}
