using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        var stack = new Stack<int>();
        int result = default;

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();

            if (input.StartsWith("push"))
            {
                int value = int.Parse(input.Split(' ')[1]);
                stack.Push(value);
            }
            else
            {
                switch (input)
                {
                    case "pop"   : result = stack.Count() > 0  ? stack.Pop() : -1; break;
                    case "size"  : result = stack.Count(); break;
                    case "empty" : result = stack.Count() == 0 ? 1 : 0; break;
                    case "top"   : result = stack.Count() > 0  ? stack.Peek() : -1; break;
                }

                Console.WriteLine(result.ToString());
            }
        }
    }
}