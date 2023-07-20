using System;

public class Solution {
    public int[] solution(int brown, int yellow) {
        int sum = brown + yellow;
        int square = (int)Math.Sqrt(sum);

        int w, h;
        w = h = square;
        
        while (!(w * h == sum  && (w - 2) * (h - 2) == yellow))
        {
            w++;
            if(w * h > sum)
            {
                w = square;
                h--;
            }
        }
        return new int[] { w, h };

    }
}