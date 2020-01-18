using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class LabyrinthGenerator
    {
        public static int[,] Generate(int height, int width, Vector2 entry, Vector2 output)
        {
            var matrix = new int[width, height];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                {
                    matrix[i, j] = 0;
                }
            matrix[(int)entry.x, (int)entry.y] = 1;
            matrix[(int)output.x, (int)output.y] = 2;

            while (true)
            {
                entry = Randomize(entry, width, height);
                output = Randomize(output, width, height);
                if (matrix[(int)entry.x, (int)entry.y] == 2)
                {
                    break;
                }
                matrix[(int)entry.x, (int)entry.y] = 1;
                if (matrix[(int)output.x, (int)output.y] == 1)
                {
                    break;
                }
                matrix[(int)output.x, (int)output.y] = 2;
            }


            return matrix;
        }

        static Vector2 Randomize(Vector2 point, int width, int height)
        {
            if (UnityEngine.Random.value > 0.5f)
            {
                if (UnityEngine.Random.value > 0.5f)
                {
                    if (point.x < width - 2)
                    {
                        point.x += 1f;
                    }
                }
                else
                {
                    if (point.x > 1)
                    {
                        point.x -= 1f;
                    }
                }
            }
            else
            {
                if (UnityEngine.Random.value > 0.5f)
                {
                    if (point.y < height - 2)
                    {
                        point.y += 1f;
                    }
                }
                else
                {
                    if (point.y > 1)
                    {
                        point.y -= 1f;
                    }
                }
            }
            return point;
        }
    }
}
