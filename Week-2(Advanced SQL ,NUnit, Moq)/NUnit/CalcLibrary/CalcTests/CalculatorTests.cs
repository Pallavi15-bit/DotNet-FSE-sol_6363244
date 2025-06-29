using NUnit.Framework;
using CalcLibrary;

namespace CalcTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new SimpleCalculator();
        }

        [TearDown]
        public void Teardown()
        {
            _calculator = null;
        }

        [TestCase(5, 10, 15)]
        [TestCase(0, 0, 0)]
        [TestCase(-5, 5, 0)]
        public void Addition_AddsTwoNumbers_ReturnsCorrectResult(double a, double b, double expected)
        {
            double result = _calculator.Addition(a, b);

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
