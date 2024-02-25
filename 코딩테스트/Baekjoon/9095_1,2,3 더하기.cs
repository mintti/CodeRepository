using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[] tc = new int[n];
        for(int i = 0; i < n; i++)
        {
            tc[i] = int.Parse(Console.ReadLine());
        }

        int[] dp = new int[11];
        dp[1] = 1;
        dp[2] = 2;
        dp[3] = 4;

        for(int i = 4; i < 11; i++)
        {
            dp[i] = dp[i - 3] + dp[i - 2] + dp[i - 1];
        }

        foreach(var item in tc)
        {
            Console.WriteLine(dp[item]);
        }
    }
}