using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GameOfLife
{
    class Program
    {
        static void InitBoard(char[,] a)
        {
            for (int y = 0; y < a.GetLength(1); y++)
            {
                for (int x = 0; x < a.GetLength(0); x++)
                {
                    a[x, y] = '-';
                }
            }
        }

        static void InputFirstGen(char[,] a) {
            int x, y;
            Console.WriteLine("Enter X coordinates: ");
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Y coordinates: ");
            y = int.Parse(Console.ReadLine());

            while (x != -1 && y != -1) {
                a[x + 1, y + 1] = '*';
                Console.WriteLine("Enter X coordinates: ");
                x = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Y coordinates: ");
                y = int.Parse(Console.ReadLine());
            }
        }

        static void Print(char[,] a) {
            int x1 = 60, y1 = 6;
            for (int y = 1; y < a.GetLength(1) - 1; y++)
            {
                for (int x = 1; x < a.GetLength(0) - 1; x++)
                {
                    Console.SetCursorPosition(x1, y1);
                    Console.Write(a[x,y]);
                    x1++;
                }
                x1 = 60;
                y1++;
                Console.WriteLine();
            }
        }

        static int CountNeighbor(char[,] a, int x, int y) {
            int count = 0;

            if (a[x, y - 1] == '*') {
                count++;
            }

            if (a[x, y + 1] == '*')
            {
                count++;
            }

            if (a[x + 1, y] == '*')
            {
                count++;
            }

            if (a[x - 1, y] == '*')
            {
                count++;
            }

            if (a[x - 1, y - 1] == '*')
            {
                count++;
            }

            if (a[x + 1, y - 1] == '*')
            {
                count++;
            }

            if (a[x - 1, y + 1] == '*')
            {
                count++;
            }

            if (a[x + 1, y + 1] == '*')
            {
                count++;
            }
            return count;
        }

        static void UpdateNextGen(char[,] a, char[,] b) {
            for (int y = 1; y < a.GetLength(1) - 1; y++) {
                for (int x = 1; x < a.GetLength(0) - 1; x++) {

                    b[x, y] = a[x, y];

                    if (CountNeighbor(a, x, y) > 3 || CountNeighbor(a, x, y) == 1 || CountNeighbor(a, x, y) == 0)
                    {
                        b[x, y] = '-';
                    }

                    if (CountNeighbor(a, x, y) == 3)
                    {
                        b[x, y] = '*';
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            const int Max = 20;
            char[,] a = new char[Max + 2, Max + 2];
            char[,] b = new char[Max + 2, Max + 2];
             InitBoard(a);
              InitBoard(b);
              InputFirstGen(a);
            bool flag = true;
            while (1 == 1)
            {
                if (flag)
                {
                    Thread.Sleep(1000);
                    UpdateNextGen(a, b);
                    Print(b);
                    flag = false;
                }

                if (!flag) {
                    Thread.Sleep(1000);
                    UpdateNextGen(b, a);
                    Print(a);
                    flag = true;
                }
            }
        }
    }
}
