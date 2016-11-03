using System;

namespace Application.NUnit.Domain.Calculating
{
    public class SimpleCalculator
    {
        public CalculationResult Add(int inputOne, int inputTwo)
        {
            if (inputOne == int.MaxValue || inputTwo == int.MaxValue)
            {
                throw new NotSupportedException("Maximum values not supported.");
            }
            return new CalculationResult() { Outcome = inputOne + inputTwo };
        }
    }
}
