using NUnit.Framework;

namespace ParseTree.Tests
{
    public class Tests
    {
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
        //[TestCase("( / ( + 3 22) 2", ExpectedResult = 12.5)]
        public double TreeShouldCalculateCorrectly(string input)
        {
            var root = Tree.CreateTree(input);
            return Tree.CalculateValue(root);
        }


    }
}