using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Balanced_Parentheses_REAL_EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var charStack = new Stack<char>();
            var dict = new Dictionary<char, char>();
            dict.Add('(', ')');
            dict.Add('{', '}');
            dict.Add('[', ']');
            if (input.Length % 2 == 0)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    char ch = input[i];
                    if (ch == '(' || ch == '[' || ch == '{')
                    {
                        charStack.Push(ch);
                    }
                    else if (charStack.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                    else
                    {
                        char lastOpenBracket = charStack.Pop();
                        char expectedBracked = dict[lastOpenBracket];
                        if (ch != expectedBracked)
                        {
                            Console.WriteLine("NO");
                            return;
                        }

                    }

                }
            }
            else
            {
                Console.WriteLine("NO");
                return;
            }
            if (!charStack.Any())
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
