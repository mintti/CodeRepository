using System;
using System.Collections.Generic;

public class Solution {
    public int solution(int[] topping) {
        int answer = 0;
        
        var leftDict = new Dictionary<int, int>();
        var rightDict = new Dictionary<int, int>();
        
        foreach(var t in topping)
        {
            if(leftDict.ContainsKey(t)) leftDict[t] ++;
            else leftDict.Add(t, 1);
        }
        
        int pivot = topping.Length - 1;
        
        while(pivot >= 0)
        {
            if(leftDict.Count == rightDict.Count)
                answer ++;
            if(leftDict.Count < rightDict.Count) break;
            
            int t = topping[pivot];
            leftDict[t]--;
            if(leftDict[t] == 0)
                leftDict.Remove(t);
            
            if(rightDict.ContainsKey(t)) rightDict[t] ++; 
            else rightDict.Add(t, 1);
            
            pivot--;
        }
    
        return answer;
    }
}