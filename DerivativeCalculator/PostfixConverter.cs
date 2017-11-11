using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerivativeCalculator
{
    public class PostfixConverter
{
        const string addSubtract = "+-";
        const string multiplyDivide = "*/";
        const string openParenthasis = "(";
        const string closeParenthasis = "(";
        const string exponent = "^";
        const string digits = "1234567890";
        const string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public List<string> Convert(string prefix)
        {
            Stack<string> operatorStack = new Stack<string>();
            List<string> postfix = new List<string>();

            bool currentCharIsDigit = false;
            bool currentCharIsLetter = false;
            bool priorCharIsDigit = false;
            bool priorCharIsLetter = false;
            string numberString = "";

            foreach (char c in prefix)
            {
                currentCharIsDigit = false;
                currentCharIsLetter = false;

                if (digits.IndexOf(c) >= 0)
                {
                    currentCharIsDigit = true;
                    numberString = charIsDigit(c, numberString, priorCharIsDigit);
                }
                else
                {
                    if (priorCharIsDigit)
                    {
                        postfix.Add(numberString);
                        numberString = "";
                    }
                    if (letters.IndexOf(c) >= 0)
                    {
                        currentCharIsLetter = true;
                        charIsLetter(c, operatorStack, postfix, priorCharIsDigit, priorCharIsLetter);
                    }
                    else if (addSubtract.IndexOf(c) >= 0)
                    {
                        charIsAddSubtract(c, operatorStack, postfix);
                    }
                    else if (multiplyDivide.IndexOf(c) >= 0)
                    {
                        charIsMultiplyDivide(c, operatorStack, postfix);
                    }
                }
                priorCharIsLetter = currentCharIsLetter;
                priorCharIsDigit = currentCharIsDigit;
            }
            if(priorCharIsDigit)
            {
                postfix.Add(numberString);
            }
            while (operatorStack.Count > 0)
            {
                postfix.Add(operatorStack.Pop());
            }
            return postfix;
        }

        private string charIsDigit(char c, string numberString, bool priorCharIsDigit)
        {
            if (priorCharIsDigit)
            {
                numberString = numberString + c;
            }
            else
            {
                numberString = c.ToString();
            }
            return numberString;
        }

        private void charIsLetter(char c, Stack<string> operatorStack, List<string> postfix, bool priorCharIsDigit, bool priorCharIsLetter)
        {
            if (priorCharIsDigit || priorCharIsLetter)
            {
                bool continueCheck = true;
                while (continueCheck)
                {
                    if (operatorStack.Count > 0)
                    {
                        if (multiplyDivide.IndexOf(operatorStack.Peek()) >= 0)
                        {
                            postfix.Add(operatorStack.Pop());
                        }
                        else
                        {
                            continueCheck = false;
                        }
                    }
                    else
                    {
                        continueCheck = false;
                    }
                }
                operatorStack.Push("*");
            }
            postfix.Add(c.ToString());
        }

        private void charIsAddSubtract(char c, Stack<string> operatorStack, List<string> postfix)
        {
            bool continueCheck = true;
            while (continueCheck)
            {
                if (operatorStack.Count > 0)
                {
                    // if the stack has an operator at the top then pop that operator to the postfix list
                    if ((addSubtract.IndexOf(operatorStack.Peek()) >= 0) || (multiplyDivide.IndexOf(operatorStack.Peek()) >= 0))
                    {
                        postfix.Add(operatorStack.Pop());
                    }
                    else
                    {
                        continueCheck = false;
                    }
                }
                else
                {
                    continueCheck = false;
                }
            }
            operatorStack.Push(c.ToString());
        }

        private void charIsMultiplyDivide(char c, Stack<string> operatorStack, List<string> postfix)
        {
            bool continueCheck = true;
            while (continueCheck)
            {
                if (operatorStack.Count > 0)
                {
                    if (multiplyDivide.IndexOf(operatorStack.Peek()) >= 0)
                    {
                        postfix.Add(operatorStack.Pop());
                    }
                    else
                    {
                        continueCheck = false;
                    }
                }
                else
                {
                    continueCheck = false;
                }
            }
            operatorStack.Push(c.ToString());
        }
    }
}
