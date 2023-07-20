using System;
using System.Linq;
using System.Collections.Generic;

public class TangerineGroup
{
    public int Size;
    public int Count;
    
    public TangerineGroup()
    {
        
    }
    
    public TangerineGroup(int newSize)
    {
        Size = newSize;
        Count = 1;
    }
}

public class Solution {
    public int solution(int k, int[] tangerine) {
        // 패턴 1. 귤이 부족함
        if (tangerine.Length < k) return 0;

        var tgDict = new Dictionary<int, int>();
        foreach (int item in tangerine)
        {
            if (tgDict.ContainsKey(item))
                tgDict[item]++;
            else tgDict.Add(item, 1);
        }
        
        // 귤이 많은 순으로 정렬한 시퀀스를 생성
        var tg = tgDict.OrderByDescending(x=> x.Value);

        // 패턴 2. 판매할 귤 갯수와 귤 양이 일치함
        if (tangerine.Length == k) return tgDict.Count;

        // 패턴 3. 제일 큰 귤 수부터 합쳐 최소한의 조합을 생성
        int answer = 0;
        int curCount = 0;
        foreach (var t in tg)
        {
            answer++;
            curCount += t.Value;
            if (curCount >= k) break;
        }

        return answer;
    }
}