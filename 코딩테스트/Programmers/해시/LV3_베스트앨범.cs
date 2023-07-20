using System;
using System.Linq;
using System.Collections.Generic;
//https://programmers.co.kr/learn/courses/30/lessons/42579
public class Solution {
    public int[] solution(string[] genres, int[] plays) {
        Dictionary<int, int> dic = new Dictionary<int, int>();
        for(int i = 0 ; i < genres.Length; i++)
            dic.Add(i, plays[i]);
        
        Dictionary<string, int> sum = new Dictionary<string, int>();
        for(int i = 0; i < genres.Length; i++)
        {
            try{sum.Add(genres[i], plays[i]);}
            catch{sum[genres[i]]+= plays[i];}
        }
        var genreDesc = sum.OrderByDescending( x => x.Value);

        List<int> answer = new List<int>();
        Dictionary<int, int> temp = new Dictionary<int, int>();
        foreach(var gd in genreDesc)
        {
            foreach(var d in dic)
            {   
                if(gd.Key == genres[d.Key])
                    temp.Add(d.Key, d.Value);
            }
            var songDesc = temp.OrderByDescending(x=>x.Value);
            int index = 0;
            foreach(var sd in songDesc)
            {
                if(index < 2 && temp.Count > index++)
                    answer.Add(sd.Key);
                
                dic.Remove(sd.Key);
            }
            temp.Clear();
        }

        return answer.ToArray();
    }
}