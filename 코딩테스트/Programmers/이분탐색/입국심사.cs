using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public long solution(int n, int[] times)
    {
        times = times.OrderBy(x => x).ToArray();
        long start = 0;
        long end = (long)times[0] * n;
        long answer = end;
        long mid = (start + end) / 2;
        
        while(start < mid)
        {
            long res = 0;
            
            for(int i = 0; i < times.Length; i++)
            {
                res += mid / times[i];
            }

            if(res >= n)
            {
                end = mid;
                answer = mid;
            }
            else
            {
                start = mid;
            }
            
            mid = (start + end) / 2;
        }

        return answer;
    }
}