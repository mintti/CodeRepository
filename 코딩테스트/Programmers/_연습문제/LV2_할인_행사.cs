using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int solution(string[] want, int[] number, string[] discount) {
        int answer = 0;
        int count = 0;
        string product;
        var saleDict = new Dictionary<string, int>();
        
        // 초기 데이타 설정
        for(int i = 0; i < 10; i++)
        {
            product = discount[i];
            if(saleDict.ContainsKey(product))
               saleDict[product]++;
            else 
               saleDict.Add(product, 1);
        }
        
        int index = 10;
        do
        {
            // 제품 비교
            int buyCount = 0;
            for(int j = 0; j < want.Length; j++)
            {
                product = want[j];
                if(saleDict.ContainsKey(product) && saleDict[product] == number[j])
                {
                    buyCount += number[j];   
                }
            }
            
            // 답 계산
            if(buyCount == 10)
            {
                answer ++;
            }
            
            // 다음 값 준비
            if(index < discount.Length)
            {
                // 제품 제거
                product = discount[index - 10]; 
                saleDict[product]--;
                if(saleDict[product] == 0) saleDict.Remove(product);
                
                // 제품 추가
                product = discount[index];
                if(saleDict.ContainsKey(product)) saleDict[product]++;
                else saleDict.Add(product, 1);
            }
        }while(++index <= discount.Length );
        
        return answer;
    }
}