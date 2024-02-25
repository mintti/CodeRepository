using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        var tc = new List<(int k, int n)>(); 

        for(int i = 0; i < t; i++)
        {
            int k = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            tc.Add((k, n));
        }

        var sizeK = tc.Max(x => x.k) + 1;
        var sizeN = tc.Max(x => x.n) + 1;

        // 초기화
        int[,] dp = new int[sizeK, sizeN];
        for (int i = 0; i < sizeN; i++) dp[0, i] = i;
        for (int i = 1; i < sizeK; i++)
        {
            for(int j = 1; j < sizeN; j++)
            {
                dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
            }
        }
        
        // 출력
        foreach(var item in tc)
        {
            Console.WriteLine(dp[item.k, item.n]);
        }
    }
}