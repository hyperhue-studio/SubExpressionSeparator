using System;
using System.Collections.Generic;

namespace SubExpressionSeparator
{
    public static class ExpressionFlattener
    {
        public static Stack<string> FlattenAndLogParentheses(string expression)
        {
            Stack<string> expressionStack = new Stack<string>();

            // Check if the number of left and right parentheses are the same
            int leftParenCount = 0;
            int rightParenCount = 0;
            foreach (var character in expression)
            {
                if (character == '(')
                    leftParenCount++;
                else if (character == ')')
                    rightParenCount++;
            }

            if (leftParenCount != rightParenCount)
                throw new ArgumentException("Mismatched number of left and right parentheses.");

            if (leftParenCount > 6)
                throw new ArgumentException("Expression contains more than 6 pairs of parentheses.");

            // Process while parentheses exist
            while (expression.Contains("("))
            {
                int start = expression.LastIndexOf("(");
                int end = expression.IndexOf(")", start);
                string insideParentheses = expression.Substring(start + 1, end - start - 1);
                expressionStack.Push(insideParentheses);
                expression = expression.Remove(start, end - start + 1);
                Console.WriteLine($"Removed string: {insideParentheses}");
                Console.WriteLine($"Current expression: {expression}\n");
            }

            // Add the final expression to the stack
            expressionStack.Push(expression);

            return expressionStack;
        }

        public static void Main()
        {
            // Example usage
            string expression = "4-2*((12-4)+3+1)";
            Console.WriteLine($"Initial expression: {expression}\n");

            Stack<string> expressionStack = FlattenAndLogParentheses(expression);

            Console.WriteLine("Stack of sub-expressions (top to bottom):");
            foreach (var subExpression in expressionStack)
            {
                Console.WriteLine(subExpression);
            }
        }
    }
}