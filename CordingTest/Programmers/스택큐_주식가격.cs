using System;
//https://programmers.co.kr/learn/courses/30/lessons/42584
public class Solution {
    public int[] solution(int[] prices) {
        int size = prices.Length;
        int[] answer = new int[size];
    
        for(int i= 0 ; i < size -1; i ++)
        {
            int up = 0;
            int j;
            for(j = i+1 ; j< size; j++)
            {
                if(prices[i] <= prices[j])
                    up++;
                else
                    break;
            }
            if(j < size)    up++;
            answer[i] = up;
        }

        answer[size -1] = 0;

        return answer;
    }
}