using System;
using System.Collections.Generic;
//https://programmers.co.kr/learn/courses/30/lessons/42588
public class Solution {
        public int[] solution(int[] heights) {
        int size = heights.Length;
        int[] answer = new int[size];
        Stack<int> s = new Stack<int>();
        
        for(int i = size -1  ; i >= 0 ; i-- )
        {
            for(int j = 0 ; j < i; j++)
                s.Push(heights[j]);
            while(s.Count > 0)
            {
                if(s.Pop() > heights[i])
                {
                    answer[i] = s.Count + 1;
                    break;
                }    
            }
            s.Clear();
        }
        return answer;
    }
}