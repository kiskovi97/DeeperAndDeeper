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
            int XX = 0;
            while (XX < 100000)
            {
                XX++;
                var tmpEntry = entry;
                var tmpOutput = output;
                entry = Randomize(entry, width, height, output);
                output = Randomize(output, width, height, entry);
                if (matrix[(int)entry.x, (int)entry.y] == 2)
                {
                    break;
                }
                if (matrix[(int)output.x, (int)output.y] == 1)
                {
                    break;
                }
                if (CanBeEmpty(matrix,entry))
                {
                    matrix[(int)entry.x, (int)entry.y] = 1;
                } else
                {
                    entry = tmpEntry;
                }
                if (CanBeEmpty(matrix, output))
                {
                    matrix[(int)output.x, (int)output.y] = 2;
                } else
                {
                    output = tmpOutput;
                }
            }


            return matrix;
        }

        private static bool CanBeEmpty(int[,]  matrix, Vector2 entry)
        {
            int i = (int)entry.x;
            int j = (int)entry.y;
            int code = 0;
            if (matrix.GetLength(0) - 1 > entry.x)
            {
                code += matrix[i + 1, j] > 0 ? 1 : 0;
            }
            else
            {
                return false;
            }
            if (matrix.GetLength(1) - 1 > entry.y)
            {
                code += matrix[i, j + 1] > 0 ? 1 : 0;
            }
            else
            {
                return false;
            }
            if (0 < entry.y)
            {
                code += matrix[i, j - 1] > 0 ? 1 : 0;
            }
            else
            {
                return false;
            }
            if (0 < entry.x)
            {
                code += matrix[i - 1, j] > 0 ? 1 : 0;
            }
            else
            {
                return false;
            }
            return code < 4 && code > 0;
        }

        static Vector2 Randomize(Vector2 point, int width, int height, Vector2 towards)
        {
            var delta = (point - towards).normalized;

            var randomValueXOrY = (Mathf.Abs(delta.x) - Mathf.Abs(delta.y) + 1) * 0.5f;
            var randomValueX = (delta.x + 1) * 0.5f;
            var randomValueY = (delta.y + 1) * 0.5f;

            var randomXorY = randomValueXOrY;
            var randomY = randomValueY * 0.5f + 0.5f;
            var randomX = randomValueX; // * 0.8f + 0.2f

            if (UnityEngine.Random.value > randomXorY)
            {
                if (UnityEngine.Random.value > randomX)
                {
                    if (point.x < width - 2)
                    {
                        point.x += 1f;
                    }
                    else
                    {
                        point.x -= 1f;
                    }
                }
                else
                {
                    if (point.x > 1)
                    {
                        point.x -= 1f;
                    }
                    else
                    {
                        point.x += 1f;
                    }
                }
            }
            else
            {
                if (UnityEngine.Random.value > randomY)
                {
                    if (point.y < height - 2)
                    {
                        point.y += 1f;
                    }
                    else
                    {
                        point.y -= 1f;
                    }
                }
                else
                {
                    if (point.y > 1)
                    {
                        point.y -= 1f;
                    }
                    else
                    {
                        point.y += 1f;
                    }
                }
            }
            return point;
        }
    }
}
