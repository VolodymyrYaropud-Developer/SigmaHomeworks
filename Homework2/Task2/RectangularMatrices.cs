using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2.Task2
{
    internal static class RectangularMatrices
    {
        public static void VerticalSnake(int colon, int rows)//3 4 
        {
            for (int i = 0; i < colon; i++)
            {
                for (int q = 0; q < rows; q++)
                {
                    if (q % 2 != 0)
                        Console.Write($"{(q==1?q*colon*2-i: (q-1)*colon*2-i )} ");

                    else
                        Console.Write($"{(i + 1) + (q * colon)} ");
                }
                Console.WriteLine();
            }
        }

        public static void DiagonalSnake(int m)
        {
            int[,] matrix = new int[m, m];
            int count = 1;
            for (int stage = 0; stage < m; stage++)
            {
                if (stage % 2 == 0)
                {
                    for (int y = 0; y <= stage; y++)
                        matrix[y, stage - y] = count++;
                }
                else
                {
                    for (int x = stage; x >= 0; x--)
                        matrix[x, stage - x] = count++;
                }
            }

            for (int stage = m; stage <= (m - 1) * 2; stage++)
            {
                if (stage % 2 == 0)
                {
                    for (int y = stage - m + 1; y <= m - 1; y++)
                        matrix[y, stage - y] = count++;
                }
                else
                {
                    for (int y = m - 1; y >= stage - m + 1; y--)
                        matrix[y, stage - y] = count++;
                }
            }
            for (int i = 0; i < m; i++)
            {
                for (int q = 0; q < m; q++)
                {
                    Console.Write(matrix[i, q] + " ");
                }
                Console.WriteLine();
            }
        }

        public static void SpiralSnake(int rows, int columns) 
        {
            
        }
        

    }
}
