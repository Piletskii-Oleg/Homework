using NUnit.Framework;

namespace ParseTree.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            var tree = new Tree();
        }

        [Test]
        public void TreeShouldBeBuiltCorrectly()
        {
            string input = "(*(+1 2) 3 )";
            var root = Tree.CreateTree(input);
            Assert.IsTrue(root.Operation == '*');
            Assert.IsTrue(root.RightChild.Value == 3);
            Assert.AreEqual(root.LeftChild.LeftChild.Value, 1);
            Assert.AreEqual(root.LeftChild.RightChild.Value, 2);
        }

        [Test]
        public void TreeShouldCalculateCorrectly()
        {
            string input = "(*(+1 2) 3 )";
            var root = Tree.CreateTree(input);
            Assert.AreEqual(Tree.CalculateValue(root), 9.0);
        }
    }
}