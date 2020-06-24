using System;
using System.Collections.Generic;
//https://programmers.co.kr/learn/courses/30/lessons/42583
public class Solution {
    public int solution(int bridge_length, int weight, int[] truck_weights)
    {
        
        int answer = 0;
        int w = 0;
        int sec = 1;
        
        Queue<int> wait = new Queue<int>();
        Queue<int> ing = new Queue<int>();
        List<int> time = new List<int>();
        
        foreach(int t in truck_weights)
            wait.Enqueue(t);
        
        while(wait.Count > 0 || ing.Count > 0)
        {
            if(wait.Count > 0 && w + wait.Peek() <= weight)
            {//들어갈 자격이있음.
                w += wait.Peek();
                ing.Enqueue(wait.Dequeue());
                time.Add(0);
            }
            sec++;

            for (int i = 0; i < time.Count; i++)
            {
                if(++time[i] == bridge_length)
                {
                    w -= ing.Dequeue();
                    time.RemoveAt(i--);
                }
            }
        }
        
        answer = sec ;
        
        return answer;
    }
}