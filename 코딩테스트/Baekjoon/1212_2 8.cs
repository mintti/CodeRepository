using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        var arr = new string[8] { "000", "001", "010", "011", "100", "101", "110", "111" };
        var result = new StringBuilder();
        var input = Console.ReadLine();

        if(input == "0")
        {
            result.Append("0");
            Console.Write(result);
        }
        else
        {

            foreach (var item in input)
            {
                int num = item - '0';
                result.Append(arr[num]);
            }
            Console.Write(result.ToString().Substring(result.ToString().IndexOf('1')));
        }
    }
}