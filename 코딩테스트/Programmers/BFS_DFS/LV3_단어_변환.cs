using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    int answer;
    int Length;
    public int solution(string begin, string target, string[] words){
        
        answer = 0;
        if(begin != target && words.FirstOrDefault(x => x == target) != null)
        {
            Length = target.Length;
            DFS(begin, target, words.ToList(), 0);
        }
        
        return answer;
    }
    
    
    public void DFS(string current, string target, List<string> words, int count)
    {
        if(answer != 0 && count >= answer) return;    
       
        // 비슷한 단어를 모음
        var similerWords = new List<string>();
        foreach(var word in words)
        {
            int fail = 0;
            for(int i = 0; i < Length; i++)
            {
                if(word[i] != current[i]) fail ++;
                if(fail >= 2) break;
            }
            
            if(fail < 2)
            {
                similerWords.Add(word);
            }
        }
        
        if(similerWords.Count == 0) return;
        else
        {
            count ++;
            if(similerWords.Any(x => x == target))
            {
                if(answer == 0) answer = count;
                else if(count < answer) answer = count;
                return;
            }
            
            foreach(var word in similerWords)
            {
                var list = words.ToList();
                list.Remove(word);
                DFS(word, target, list, count);
            }
        }
        
        return;
    }
}