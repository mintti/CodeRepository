using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(int[] order) {
        var main = new Stack<int>(Enumerable.Range(1, order.Length).Reverse());
        var sub = new Stack<int>();
    
        int index = 0;
        
        while(index < order.Length)
        {
            if(main.Count > 0 && order[index] == main.Peek())
            {
                index++;
                main.Pop();
            }
            else if(sub.Count > 0 && order[index] == sub.Peek() )
            {
                index++;
                sub.Pop();
            }
            else
            {
                if(main.Count > 0)
                {
                    sub.Push(main.Pop());
                }
                else
                {
                    break;
                }
            }
        }
        return index;
    }
}