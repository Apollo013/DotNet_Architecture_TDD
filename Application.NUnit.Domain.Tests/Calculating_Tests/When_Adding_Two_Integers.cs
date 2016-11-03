using Application.NUnit.Domain.Calculating;
using NUnit.Framework;

namespace Application.NUnit.Domain.Tests.Calculating_Tests
{
    /*
     * Demonstrates using multiple test fixtures for running multiple tests using different arguments. 
     */


    [Category("Calculating_Tests")]
    [TestFixture(1, 1, 2)]
    [TestFixture(2, 2, 4)]
    [TestFixture(3, 2, 5)]
    [TestFixture(4, 4, 8)]
    [TestFixture(5, 6, 11)]
    [TestFixture(12, 10, 22)]
    [TestFixture(13, 14, 27)]
    [TestFixture(0, 0, 0)]
    public class When_Adding_Two_Integers
    {
        private SimpleCalculator _simpleCalculator;
        private int _firstParameter;
        private int _secondParameter;
        private int _result;

        public When_Adding_Two_Integers(int firstParameter, int secondParameter, int result)
        {
            _firstParameter = firstParameter;
            _secondParameter = secondParameter;
            _result = result;

        }

        [SetUp]
        public void AssignVariables()
        {
            _simpleCalculator = new SimpleCalculator();
        }

        [Test]
        public void Then_sum_is_correct()
        {
            CalculationResult calculationResult = _simpleCalculator.Add(_firstParameter, _secondParameter);
            Assert.AreEqual(_result, calculationResult.Outcome);
        }

    }
}
