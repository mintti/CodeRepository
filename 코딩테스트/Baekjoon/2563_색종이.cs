using System;

class Program
{
    static void Main()
    {
        bool[,] grid = new bool[101, 101];
        int area = 0;
        int n = int.Parse(Console.ReadLine());
        for(int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(' ');
            int x = int.Parse(input[0]);
            int y = int.Parse(input[1]);

            for (int p = 0; p < 10; p++)
            {
                for(int q = 0; q < 10; q++)
                {
                    if (grid[ x + p, y + q] == false)
                    {
                        grid[x + p, y + q] = true;
                        area++;
                    }
                }
            }
        }

        Console.WriteLine(area);
    }
}