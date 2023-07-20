using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int[] solution(string[] maps) {
        var answer = new List<int>();
        
        var m = new int[100,100];
        var hash = new HashSet<(int x, int y)>();
        
        for(int i = 0, length =  maps.Length; i < length; i++)
        {
            for(int j = 0, jl =  maps[i].Length; j < jl; j++ )
            {
                char item = maps[i][j]; 
                if( item == 'X')
                    m[i,j] = -1;
                else
                {
                    
                    m[i,j] = Int32.Parse($"{item}");
                    hash.Add((i, j));
                }
            }
        }
        
        
        var wayX = new int[4]{-1, 1, 0, 0};
        var wayY = new int[4]{0, 0, 1, -1};
        
        var q = new Queue<(int x,int y)>();
        (int x, int y) curPos;
        int value = 0;
        int x;
        int y;
        
        if( hash.Count == 0) return new int[]{-1};
        else q.Enqueue(hash.First());
        
        while(q.Count > 0)
        {
            curPos = q.Dequeue();
            
            x = curPos.x;
            y = curPos.y;
            hash.Remove(curPos);
            
            value += m[x, y] ;
            m[x, y] = -1;
            
            for(int i = 0; i < 4; i++)
            {
                var nextX = x + wayX[i];
                var nextY = y + wayY[i];
                if ( nextX < 0 || nextX >= 100 || nextY < 0 || nextY >= 100 || q.Contains((nextX, nextY)) ) continue;
                
                var next = m[nextX, nextY];
                if(next > 0 ) q.Enqueue((nextX, nextY));
            }
            
            if(q.Count == 0) 
            {
                if(hash.Count > 0) q.Enqueue(hash.First());
                answer.Add(value);
                value = 0;
            }
        }
        
        return answer.OrderBy(item => item).ToArray();
    }
}