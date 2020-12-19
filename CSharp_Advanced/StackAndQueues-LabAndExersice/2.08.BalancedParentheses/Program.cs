using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._08.BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> parenthesis = new Stack<char>();

            bool isBalanced = true;

            foreach (char c in input)
            {
                if (c == '(' || c == '[' || c == '{')
                {
                    parenthesis.Push(c);
                }
                else
                {
                    if (!parenthesis.Any())
                    {
                        isBalanced = false;
                        break;
                    }

                    char currentOpenParentheses = parenthesis.Pop();

                    bool isRound = currentOpenParentheses == '(' && c == ')';
                    bool isCurly = currentOpenParentheses == '{' && c == '}';
                    bool isSquare = currentOpenParentheses == '[' && c == ']';


                    if (isRound == false && isCurly == false && isSquare == false)
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }

            if (isBalanced)
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
