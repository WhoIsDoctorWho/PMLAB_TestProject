using NCalc;
using System;

namespace PMLAB_TestProject.Services
{
    public class CalculatorService
    {        
        public double Calculate(string expression)
        {
            Expression e = new Expression(expression);
            
            bool isExpressionCorrect = double.TryParse(e.Evaluate().ToString(), out double result);

            if (!isExpressionCorrect || double.IsNaN(result))
                throw new ArgumentException($"Incorrect input: {expression}");
            if (double.IsInfinity(result))
                throw new DivideByZeroException($"Cannot divide by zero, check your input: {expression}");

            return result;
        }
    }
}
