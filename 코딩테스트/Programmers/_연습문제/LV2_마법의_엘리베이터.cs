using System;

public class Solution {
    public int solution(int storey) {
        
        int pow = 1 ;
        while(storey / pow > 0) pow *= 10;
        
        int res1 = GetCount(pow - storey) + 1;
        int res2 = GetCount(storey);
        
        if(res1 < res2) return res1;
        return res2;
    }
    
    private int GetCount(int value)
    {
        int result = 0;
        
        while(value > 0)
        {
            int remainder = value % 10;
            
            if( remainder <= 5)
            {
                result += remainder;
            }
            else
            {
                result += 10 - remainder;
                value += 10;
            }
            
            value /= 10;
        }
        return result;
    }
}