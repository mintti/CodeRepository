using System;
using System.Linq;

public class Solution {
    public int solution(int n, int[] lost, int[] reserve) {
        int answer = n - lost.Length;
        
        // 중복 값 제거
        var list = lost.Where(x => Array.IndexOf(reserve, x) != -1);
        var lostList = lost.ToList();
        var reserveList = reserve.ToList();
        foreach(var item in list)
        {
            lostList.Remove(item);
            reserveList.Remove(item);
            answer ++;
        }
        
        // 정렬
        lost = lostList.OrderBy(x => x).ToArray();
        reserve = reserveList.OrderBy(x => x).ToArray();
        
        // 순차적으로 비교
        int lostIdx = 0, rsvIdx = 0;
        while(lostIdx < lost.Length && rsvIdx < reserve.Length)
        {
            int lVal = lost[lostIdx];
            int rVal = reserve[rsvIdx];
            
            if(lVal < rVal)
            {
                if(lVal + 1 == rVal)
                {
                    answer ++;
                    rsvIdx ++; 
                }
                lostIdx ++;
            }
            else if (lVal > rVal)
            {
                if(lVal - 1 == rVal)
                {
                    answer ++;
                    lostIdx ++;
                }
                rsvIdx ++;
            }
        }
        
        return answer;
    }
}