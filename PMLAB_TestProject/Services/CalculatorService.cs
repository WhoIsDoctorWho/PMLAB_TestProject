using System;
using System.Data;
using System.Linq;

namespace PMLAB_TestProject.Services
{
    public class CalculatorService
    {
        char[] operators = new char[] { '+', '-', '*', '/', '%', '(', ')' };
        public string Calculate(string expression)
        {
            if (!IsExpressionCorrect(expression))
                throw new ArgumentException($"Incorrect input:\n{expression}");
            string result = new DataTable().Compute(expression, null).ToString();
            if (result == "∞")
                throw new DivideByZeroException($"Cannot divide by zero:\n{expression}");
            return result;
        }
        private bool IsExpressionCorrect(string expression)
        { 
            return expression.All(
                ch => char.IsWhiteSpace(ch) || char.IsDigit(ch) || operators.Contains(ch));
        }
    }
}
