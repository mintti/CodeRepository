using System;
using System.Linq;
using System.Collections.Generic;

public class Info
{
    public int Rank { get; set; } = 101;
    public int Index { get; set; } = 101;
}

public class Solution {
    public int solution(int[] rank, bool[] attendance) {
        int answer = 0;
        
        // 선발 학생 정보 초기화
        var top3Infos = new List<Info>();
        for(int i = 0 ; i < 3; i++) 
            top3Infos.Add(new Info());
        
        // 순회
        for(int i = 0, cnt = rank.Length; i < cnt; i++)
        {
            if(attendance[i] && rank[i] < top3Infos[2].Rank)
            {
                top3Infos[2].Rank = rank[i];
                top3Infos[2].Index = i;
                top3Infos = top3Infos.OrderBy(x => x.Rank).ToList();
            }
        }
        
        // 결과 값 계산
        answer = top3Infos[0].Index * 10000 + top3Infos[1].Index * 100 + 1 * top3Infos[2].Index;
        return answer;
    }
}