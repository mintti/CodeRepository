using System;
using System.Linq;
using System.Collections.Generic;

class Solution {
    public int solution(int[,] maps)
    {
        Queue<(int, int)> q = new Queue<(int, int)>();

        int maxX = maps.GetLength(1);
        int maxY = maps.GetLength(0);
        int[] xway = new int[4] { 1, -1, 0, 0 };
        int[] yway = new int[4] { 0, 0, 1, -1 };

        q.Enqueue((0, 0));

        while (q.Count > 0)
        {
            (int x, int y) = q.Dequeue();
            int value = maps[y, x] + 1;

            for(int i = 0; i < 4; i++)
            {
                int _x = x + xway[i];
                int _y = y + yway[i];

                if (_x >= 0 && _x < maxX && _y >= 0 && _y < maxY && maps[_y, _x] == 1)
                {
                    q.Enqueue((_x, _y));
                    maps[_y, _x] = value;
                }
            }
        }

        return maps[maxY - 1, maxX - 1] == 1 ? -1 : maps[maxY - 1, maxX - 1];
    }
}