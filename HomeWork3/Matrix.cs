using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork3
{

    public enum eDirection
    {
        down,
        right
    }
    internal class Matrix
    {
        public static void SnakeDisplay(eDirection direction, int elements)
        {
            int[,] matrix = new int[elements, elements];
            int counter = 1;
            if (eDirection.down == direction)
            {
                for (int stage = 0; stage < elements; stage++)
                {
                    if (stage % 2 == 0)
                    {
                        for (int y = 0; y <= stage; y++)
                            matrix[y, stage - y] = counter++;
                    }
                    else
                    {
                        for (int x = stage; x >= 0; x--)
                            matrix[x, stage - x] = counter++;
                    }
                }

                for (int stage = elements; stage <= (elements - 1) * 2; stage++)
                {
                    if (stage % 2 == 0)
                    {
                        for (int y = stage - elements + 1; y <= elements - 1; y++)
                            matrix[y, stage - y] = counter++;
                    }
                    else
                    {
                        for (int y = elements - 1; y >= stage - elements + 1; y--)
                            matrix[y, stage - y] = counter++;
                    }
                }
            }
            else
            {
                for (int stage = 0; stage < elements; stage++)
                {
                    if (stage % 2 == 0)
                    {
                        for (int x = stage; x >= 0; x--)
                            matrix[x, stage - x] = counter++;

                    }
                    else
                    {
                        for (int y = 0; y <= stage; y++)
                            matrix[y, stage - y] = counter++;
                    }
                }

                for (int stage = elements; stage <= (elements - 1) * 2; stage++)
                {
                    if (stage % 2 == 0)
                    {
                        for (int y = elements - 1; y >= stage - elements + 1; y--)
                            matrix[y, stage - y] = counter++;
                    }
                    else
                    {
                        for (int y = stage - elements + 1; y <= elements - 1; y++)
                            matrix[y, stage - y] = counter++;

                    }
                }
            }

            for (int i = 0; i < elements; i++)
            {
                for (int q = 0; q < elements; q++)
                {
                    Console.Write(matrix[i, q] + " ");
                }
                Console.WriteLine();
            }

        }
    }
}
