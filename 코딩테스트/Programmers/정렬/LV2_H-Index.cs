using System;
//https://programmers.co.kr/learn/courses/30/lessons/42747
public class Solution {
    public int solution(int[] citations) {
        Array.Sort(citations);
        Array.Reverse(citations);
        
        int index = 0;
        foreach(int n in citations)
        {
            if(n > index)
                index++;
            else
                break;
        }
        return index;
    }
}