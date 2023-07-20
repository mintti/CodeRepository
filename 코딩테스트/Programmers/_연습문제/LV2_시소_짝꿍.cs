using System;
using System.Linq;
using System.Collections.Generic;

public class Solution {
    public long solution(int[] weights) {
        long answer = 0;
        
        var dict = new Dictionary<int, int>(); 
        foreach(var w in weights.OrderBy(x => x))
        {
            if(dict.ContainsKey(w)) dict[w]++;
            else dict.Add(w, 1);
        }
        
        int count = dict.Keys.Count;
        var keys = dict.Keys.ToList();
        for(int i = 0; i < count; i++)
        {
            int target = keys[i];
            answer += GetCombo(dict[target] - 1);
            
            for(int c = i + 1; c < count; c++)
            {
                int comparer = keys[c];
                var division = (float)comparer / target;
                    
                if(division == 2f ||division == 1.5f || ((float) target / comparer ) == 0.75f)
                {
                    answer += (long)dict[target] * dict[comparer];
                }
            }
        }
        
        return answer;
    }
    
    private long GetCombo(int n)
    {
        if(n == 0) return 0;
        if(n == 1) return 1;
        return n + GetCombo(n - 1);
    }
}