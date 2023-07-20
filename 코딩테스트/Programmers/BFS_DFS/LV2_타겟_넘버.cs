using System;
using System.Linq;

public class Solution {
    public int solution(int[] numbers, int target) {
        int answer = 0;
        
        answer = Calcul(numbers, target, 0);
        
        return answer;
    }
    
    public int Calcul(int[] numbers , int target, int curIdx)
    {
        int answer = 0;
        // 재귀 종료
        if(curIdx == numbers.Length)
        {
            if(numbers.Sum() == target) return 1;
            else return 0;
        }
        
        answer += Calcul(numbers, target, curIdx + 1);
        numbers[curIdx] *= -1;
        answer += Calcul(numbers, target, curIdx + 1);
        
        return answer;
    }
}