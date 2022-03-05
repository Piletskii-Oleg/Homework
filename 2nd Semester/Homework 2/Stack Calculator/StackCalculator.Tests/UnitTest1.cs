using NUnit.Framework;
using Stack_Calculator;

namespace StackCalculator.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ThreePushesThreePopsInArrayStack()
        {
            var stack = new ArrayStack(4);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            int three = (int)stack.Pop();
            int two = (int)stack.Pop();
            int one = (int)stack.Pop();
            Assert.AreEqual(3, three);
            Assert.AreEqual(2, two);
            Assert.AreEqual(1, one);
        }

        [Test]
        public void ThreePushesThreePopsInMSListStack()
        {
            var stack = new MSListStack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            int three = (int)stack.Pop();
            int two = (int)stack.Pop();
            int one = (int)stack.Pop();
            Assert.AreEqual(3, three);
            Assert.AreEqual(2, two);
            Assert.AreEqual(1, one);
        }

        [Test]
        public void ThreePushesThreePopsInMyListStack()
        {
            var stack = new MyListStack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            int three = (int)stack.Pop();
            int two = (int)stack.Pop();
            int one = (int)stack.Pop();
            Assert.AreEqual(3, three);
            Assert.AreEqual(2, two);
            Assert.AreEqual(1, one);
        }
    }
}