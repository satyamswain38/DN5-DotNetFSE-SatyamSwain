using NUnit.Framework;
using CalcLibrary;

namespace CalculatorTests
{
    public class SimpleCalculatorTests
    {
        private SimpleCalculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new SimpleCalculator();
        }

        [TestCase(10, 20, 30)]
        [TestCase(5, 5, 10)]
        [TestCase(-5, 5, 0)]
        public void Addition_ValidInputs_ReturnsExpected(
            double a,
            double b,
            double expected)
        {
            Assert.That(
                calculator.Addition(a, b),
                Is.EqualTo(expected));
        }

        [Test]
        public void Subtraction_ValidInputs_ReturnsExpected()
        {
            Assert.That(
                calculator.Subtraction(20, 5),
                Is.EqualTo(15));
        }

        [Test]
        public void Multiplication_ValidInputs_ReturnsExpected()
        {
            Assert.That(
                calculator.Multiplication(5, 4),
                Is.EqualTo(20));
        }

        [Test]
        public void Division_ValidInputs_ReturnsExpected()
        {
            Assert.That(
                calculator.Division(20, 5),
                Is.EqualTo(4));
        }

        [Test]
        public void Division_ByZero_ThrowsException()
        {
            Assert.That(
                () => calculator.Division(10, 0),
                Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void AllClear_ShouldResetResult()
        {
            calculator.Addition(10, 20);
            calculator.AllClear();

            Assert.That(
                calculator.GetResult,
                Is.EqualTo(0));
        }
    }
}