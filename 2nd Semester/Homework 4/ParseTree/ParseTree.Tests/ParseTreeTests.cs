using System;
using System.IO;
using System.Collections.Generic;
using NUnit.Framework;
namespace ParseTree.Tests
{
    public class Tests
    {
        private static IEnumerable<TestCaseData> Operators
            => new[]
            {
                new TestCaseData(new OperatorAdd()),
                new TestCaseData(new OperatorSubtract()),
                new TestCaseData(new OperatorMultiply()),
                new TestCaseData(new OperatorDivide()),
            };

        [Test]
        public void OperandShouldReturnItsValue()
        {
            var operand = new Operand(null, 3);
            Assert.AreEqual(3, operand.Value);
        }

        [TestCaseSource(nameof(Operators))]
        public void OperatorsShouldEvaluateCorrectly(Operator oper)
        {
            oper.LeftChild = new Operand(oper, 3.1);
            oper.RightChild = new Operand(oper, 8.9);
            switch (oper.Operation)
            {
                case '+':
                    Assert.AreEqual(oper.Evaluate(), 3.1 + 8.9);
                    break;
                case '-':
                    Assert.AreEqual(oper.Evaluate(), 3.1 - 8.9);
                    break;
                case '*':
                    Assert.AreEqual(oper.Evaluate(), 3.1 * 8.9);
                    break;
                case '/':
                    Assert.AreEqual(oper.Evaluate(), 3.1 / 8.9);
                    break;
            }
        }

        [Test]
        public void TreeShouldBeBuiltCorrectly()
        {
            string input = "(*(+1 2) 3 )";
            var root = Tree.CreateTree(input);
            Assert.IsTrue(root is OperatorMultiply);
            Assert.IsTrue(root.LeftChild is OperatorAdd);
            Assert.IsTrue(root.LeftChild.LeftChild is Operand);
            Assert.IsTrue(root.LeftChild.RightChild is Operand);
            Assert.IsTrue(root.RightChild is Operand);
        }

        [TestCase("(*(+1 2) 3 )", ExpectedResult = 9.0)]
        [TestCase("(+ (* 3 4) (+ 1 (* 4 5)))", ExpectedResult = 33.0)]
        [TestCase("( / ( + 3 22) 2", ExpectedResult = 12.5)]
        [TestCase("( - (+ 30 20) 50", ExpectedResult = 0.0)]
        public double TreeShouldCalculateCorrectly(string input)
        {
            var root = Tree.CreateTree(input);
            return Tree.CalculateValue(root);
        }

        [Test]
        public void TreeShouldBePrintedCorrectly()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            string input = "(*(+1 2) 3 )";
            var root = Tree.CreateTree(input);
            Tree.PrintTree(root);
            Assert.AreEqual("( * ( + 1 2 ) 3 ) ", stringWriter.ToString());
        }

        //[Test]
        //public void StringShouldBeParsedCorrectly()
        //{
        //    Assert.AreEqual(Tree.ParseInput("(*(*(* 3 9) 10) 8 )"),
        //        "( * ( * ( * 3 9 ) 10 ) 8 )".Split());
        //    Assert.AreEqual(Tree.ParseInput("(+  (* 2 1 ) ( + 3 ( + (* 5 66) 4)))"),
        //        "( + ( * 2 1 ) ( + 3 ( + ( * 5 66 ) 4 ) ) )".Split());
        //}

        [Test]
        public void DivisionByZeroShouldThrowException()
        {
            string input = "/ 2 0";
            var root = Tree.CreateTree(input);
            Assert.Throws<DivideByZeroException>(() => Tree.CalculateValue(root));
        }
    }
}