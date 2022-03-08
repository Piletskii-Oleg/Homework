using NUnit.Framework;

namespace PrefixTree.Tests
{
    public class Tests
    {
        private Trie trie = new Trie();
        [SetUp]
        public void Setup()
        {
            trie = new Trie();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}