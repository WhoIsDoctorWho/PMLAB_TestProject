using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace PMLAB_TestProject_Tests
{
    public class CalculatorControllerTests : AbstractControllerTests
    {
        [Test]
        public async Task SimpleExpressionTest()
        {
            var okResult = await calculatorController.Get("2+2*2", historyService, calculatorService);

            Assert.IsInstanceOf<OkObjectResult>(okResult.Result);
            Assert.AreEqual(2 + 2 * 2, ((OkObjectResult)okResult.Result).Value);
        }
        [Test]
        public async Task TranscendentalExpressionTest()
        {
            var okResult = await calculatorController.Get("Cos(0) * Log(4, 2)", historyService, calculatorService);

            Assert.IsInstanceOf<OkObjectResult>(okResult.Result);
            Assert.AreEqual(Math.Cos(0) * Math.Log(4, 2), ((OkObjectResult)okResult.Result).Value);
        }
        [Test]
        public async Task IncorrectExpressionTest()
        {
            var badRequestResult_InvalidInput = await calculatorController.Get("I do want to join PMLAB!", historyService, calculatorService);
            var badRequestResult_DivideByZero = await calculatorController.Get("2+2/(2-2)", historyService, calculatorService);
            var badRequestResult_SqrtOfNegativeNumber = await calculatorController.Get("Sqrt(1-2)", historyService, calculatorService);

            Assert.IsInstanceOf<BadRequestObjectResult>(badRequestResult_InvalidInput.Result);
            Assert.IsInstanceOf<BadRequestObjectResult>(badRequestResult_DivideByZero.Result);
            Assert.IsInstanceOf<BadRequestObjectResult>(badRequestResult_SqrtOfNegativeNumber.Result);
        }
    }
}