using System;
using System.Collections.Generic;
using System.Linq;
 
public class Solution {
    public int solution(int x, int y, int n) 
    {
        int answer = 0;
        var q = new Queue<int>();
        var checkedValue = new HashSet<int>(); // 확인한 값 목록
        
        // 확인하지 않은 값만 큐에 넣는 Action 
        Action<int> action = (val) => 
        {
            if(val <= y)
            { 
                if(!checkedValue.Contains(val))
                {
                    q.Enqueue(val);
                    checkedValue.Add(val);
                }
            } 
        };
        
        q.Enqueue(x);
        
        // BFS
        while(q.Count > 0)
        {
            foreach(int item in q.ToList())
            {
                if(item == y) return answer; // 정답!
                
                var v = q.Dequeue();
                action(v + n);
                action(v * 2);
                action(v * 3);
            }
            answer++;
        }
        return -1;
    }
}