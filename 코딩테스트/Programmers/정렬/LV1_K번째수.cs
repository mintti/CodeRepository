using System;
//https://programmers.co.kr/learn/courses/30/lessons/42748
public class Solution {
    public int[] solution(int[] array, int[,] commands) {
        int[] answer = new int[commands.GetLength(0)];
        
        for(int index = 0; index < commands.GetLength(0); index++)
        {
            int size = commands[index, 1] - commands[index, 0] + 1;
            int[] cutArray = new int[size];
            
            Array.Copy(array, commands[index, 0] -1, cutArray, 0, size );
            Array.Sort(cutArray);
            
            answer[index] = cutArray[commands[index, 2] -1];
            
        }
        return answer;
    }
}