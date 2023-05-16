using System;
using System.Collections.Generic;

class Program
{
    static bool IsExpressionCorrect(string expression)
    {
        Stack<char> stack = new Stack<char>();

        foreach (char c in expression)
        {
            if (c == '(')
            {
                stack.Push(c);
            }
            else if (c == ')')
            {
                if (stack.Count == 0 || stack.Peek() != '(')
                {
                    return false; 
                }
                stack.Pop();
            }
        }

        return stack.Count == 0; 
    }

    static void Main(string[] args)
    {
        string[] expressions = {
            "(2+3)(1+6)(((2-3)(5+1)))",
            "2(3)(1+6(7+2))((2-3)(5+1))",
            "2(3+5(((6))))",
            "((2+3)(4-1)))",
            "2(3+5(((6))"
        };

        foreach (string expression in expressions)
        {
            Console.WriteLine($"{expression}: {IsExpressionCorrect(expression)}");
        }
    }
}
