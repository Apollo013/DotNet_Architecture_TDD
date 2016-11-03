using Application.NUnit.Domain.Calculating;
using NUnit.Framework;
using System;

namespace Application.NUnit.Domain.Tests.Calculating_Tests
{
    /*
     * Demonstrates exception handling (when expected)
     */


    [Category("Calculating_Tests")]
    [TestFixture]
    public class When_Adding_Integer_To_Maximum
    {
        private SimpleCalculator _simpleCalculator;

        [SetUp]
        public void AssignVariables()
        {
            _simpleCalculator = new SimpleCalculator();
        }

        [Test]
        public void Method_should_throw_not_supported_exception()
        {
            Assert.That(() => _simpleCalculator.Add(int.MaxValue, 3), Throws.TypeOf<NotSupportedException>());
        }
    }
}
