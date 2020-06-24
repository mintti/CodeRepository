using System;
using System.Collections.Generic;
//https://programmers.co.kr/learn/courses/30/lessons/42578
public class Solution {
    public int solution(string[,] clothes) {
        Dictionary<string, int> table = new Dictionary<string, int>();
        
        for(int i = 0; i < clothes.GetLength(0); i++)
        {
             try{table.Add(clothes[i,1], 1);}
            catch{table[clothes[i,1]]++;}
        }

        int answer = 1;
        foreach (int value in table.Values) {
            answer*=(value+1);
        }
        answer-=1;
        return answer;
    }
}