using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DerivativeCalculator;
using System.Collections.Generic;

namespace TestDerivativeCalculator
{
    [TestClass]
    public class UnitTestPostfix
    {
        [TestMethod]
        public void TestMethod1()
        {
            // arrange
            PostfixConverter pc = new PostfixConverter();

            string prefix = "a+b";
            List<string> answer = new List<string>();
            answer.Add("a");
            answer.Add("b");
            answer.Add("+");

            // act
            List<string> postfix = pc.Convert(prefix);

            // assert
            Assert.AreEqual(ListToString(answer), ListToString(postfix));
        }

        [TestMethod]
        public void TestMethod2()
        {
            // arrange
            PostfixConverter pc = new PostfixConverter();

            string prefix = "25a";
            List<string> answer = new List<string>();
            answer.Add("25");
            answer.Add("a");
            answer.Add("*");

            // act
            List<string> postfix = pc.Convert(prefix);

            // assert
            Assert.AreEqual(ListToString(answer), ListToString(postfix));
        }

        [TestMethod]
        public void TestMethod3()
        {
            // arrange
            PostfixConverter pc = new PostfixConverter();

            string prefix = "25a/12";
            List<string> answer = new List<string>();
            answer.Add("25");
            answer.Add("a");
            answer.Add("*");
            answer.Add("12");
            answer.Add("/");

            // act
            List<string> postfix = pc.Convert(prefix);

            // assert
            Assert.AreEqual(ListToString(answer), ListToString(postfix));
        }

        [TestMethod]
        public void TestMethod4()
        {
            // arrange
            PostfixConverter pc = new PostfixConverter();

            string prefix = "25ab/c";
            List<string> answer = new List<string>();
            answer.Add("25");
            answer.Add("a");
            answer.Add("*");
            answer.Add("b");
            answer.Add("*");
            answer.Add("c");
            answer.Add("/");

            // act
            List<string> postfix = pc.Convert(prefix);

            // assert
            Assert.AreEqual(ListToString(answer), ListToString(postfix));
        }

        [TestMethod]
        public void TestMethod5()
        {
            // arrange
            PostfixConverter pc = new PostfixConverter();

            string prefix = "32a+5b";
            List<string> answer = new List<string>();
            answer.Add("32");
            answer.Add("a");
            answer.Add("*");
            answer.Add("5");
            answer.Add("b");
            answer.Add("*");
            answer.Add("+");

            // act
            List<string> postfix = pc.Convert(prefix);

            // assert
            Assert.AreEqual(ListToString(answer), ListToString(postfix));
        }

        private string ListToString(List<string> list)
        {
            string outputString = "";
            foreach (string s in list)
            {
                if (outputString.Length > 0)
                {
                    outputString += ";";
                }
                outputString += s;
            }
            return outputString;
        }
    }
}
