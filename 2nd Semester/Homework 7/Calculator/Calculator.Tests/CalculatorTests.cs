using NUnit.Framework;

namespace Calculator.Tests
{
    public class Tests
    {
        Calculator calc = new ();
        
        [SetUp]
        public void Setup()
        {
            calc = new Calculator();
        }

        [Test]
        public void DigitPressesWorkCorrectly()
        {
            for (int i = 9; i >= 0; i--)
            {
                calc.OperandPress(i.ToString());
            }
            Assert.AreEqual("9876543210", calc.FirstOperand);
        }

        [Test]
        public void EqualsSignGivesResultOfOperation()
        {
            calc.OperandPress("2");
            calc.OperatorPress("+");
            calc.OperandPress("5");
            calc.OperatorPress("=");
            Assert.AreEqual("7", calc.FirstOperand);
        }

        [Test]
        public void ConsequentOperationsGiveCorrectResult()
        {
            calc.OperandPress("1");
            calc.OperatorPress("+");
            calc.OperandPress("6");
            calc.OperatorPress("-");
            calc.OperandPress("3");
            calc.OperatorPress("=");
            Assert.AreEqual("4", calc.FirstOperand);
        }

        [Test]
        public void NumberBecomesDecimalAfterCommaPress()
        {
            calc.OperandPress("3");
            calc.DecimalPress();
            calc.OperandPress("2");
            Assert.AreEqual("3,2", calc.FirstOperand);
        }

        [Test]
        public void OperationsWithDecimalNumbersAfterCommaPressAreCorrect()
        {
            calc.OperandPress("3");
            calc.DecimalPress();
            calc.OperandPress("2");
            calc.OperatorPress("+");
            calc.OperandPress("1");
            calc.DecimalPress();
            calc.OperandPress("6");
            calc.OperatorPress("=");
            Assert.AreEqual((3.2 + 1.6).ToString("G2"), calc.FirstOperand);
        }

        [Test]
        public void PositiveNumberIsChangedToNegativeWhenSignButtonIsPressed()
        {
            calc.OperandPress("3");
            calc.OperandPress("2");
            calc.ChangeSignPress();
            Assert.AreEqual("-32", calc.FirstOperand);
        }

        [Test]
        public void ZeroShouldNotChangeSign()
        {
            calc.OperandPress("0");
            calc.ChangeSignPress();
            Assert.AreEqual("0", calc.FirstOperand);
        }

        [Test]
        public void OperationsWithNumbersWhoseSignsWereChangedAreCorrect()
        {
            calc.OperandPress("3");
            calc.OperandPress("2");
            calc.ChangeSignPress();
            calc.OperatorPress("-");
            calc.OperandPress("8");
            calc.OperatorPress("=");
            Assert.AreEqual("-40", calc.FirstOperand);
        }

        [Test]
        public void DataIsClearedCorrectly()
        {
            calc.OperandPress("3");
            calc.OperatorPress("*");
            calc.OperandPress("8");
            calc.Clear();
            Assert.Multiple(() =>
            {
                Assert.AreEqual(string.Empty, calc.FirstOperand);
                Assert.AreEqual(string.Empty, calc.SecondOperand);
                Assert.AreEqual(' ', calc.Operator);
            });
        }

        [Test]
        public void NumberIsDeletedWhenBackspaceIsPressed()
        {
            calc.OperandPress("3");
            calc.OperandPress("8");
            calc.OperandPress("1");
            calc.BackspacePress();
            Assert.AreEqual("38", calc.FirstOperand);
            calc.BackspacePress();
            Assert.AreEqual("3", calc.FirstOperand);
            calc.BackspacePress();
            Assert.AreEqual(string.Empty, calc.FirstOperand);
        }

        [Test]
        public void ExpressionIsDeletedWhenBackspaceIsPressed()
        {
            calc.OperandPress("3");
            calc.OperatorPress("*");
            calc.OperandPress("6");
            calc.BackspacePress();
            Assert.Multiple(() =>
            {
                Assert.AreEqual("3", calc.FirstOperand);
                Assert.AreEqual('*', calc.Operator);
                Assert.AreEqual(string.Empty, calc.SecondOperand);
            });
            calc.BackspacePress();
            Assert.Multiple(() =>
            {
                Assert.AreEqual("3", calc.FirstOperand);
                Assert.AreEqual(' ', calc.Operator);
                Assert.AreEqual(string.Empty, calc.SecondOperand);
            });
            calc.BackspacePress();
            Assert.Multiple(() =>
            {
                Assert.AreEqual(string.Empty, calc.FirstOperand);
                Assert.AreEqual(' ', calc.Operator);
                Assert.AreEqual(string.Empty, calc.SecondOperand);
            });
        }
    }
}