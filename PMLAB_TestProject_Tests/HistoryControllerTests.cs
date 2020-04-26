using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using PMLAB_TestProject.Controllers;
using System.Threading.Tasks;

namespace PMLAB_TestProject_Tests
{
    public class HistoryControllerTests : AbstractControllerTests
    {
        private HistoryController historyController;

        [SetUp]
        public new async Task Setup()
        {
            await base.Setup();
            historyController = new HistoryController();
        }
        [Test]
        public async Task GetEmptyHistoryTest()
        {
            string expected = "History is empty";

            var okResult = await historyController.Get(historyService);

            Assert.IsInstanceOf<OkObjectResult>(okResult.Result);
            Assert.AreEqual(expected, ((OkObjectResult)okResult.Result).Value);
        }
        [Test]
        public async Task GetFullHistoryTest()
        {
            string expression1 = "2+2*2";
            string expression2 = "2*2+2";
            string expected = expression1 + " = 6\r\n" + expression2 + " = 6";

            var helpfulRequest1 = await calculatorController.Get(expression1, historyService, calculatorService);
            var helpfulRequest2 = await calculatorController.Get(expression2, historyService, calculatorService);
            var okResult = await historyController.Get(historyService);

            Assert.IsInstanceOf<OkObjectResult>(helpfulRequest1.Result);
            Assert.IsInstanceOf<OkObjectResult>(helpfulRequest2.Result);
            Assert.IsInstanceOf<OkObjectResult>(okResult.Result);
            Assert.AreEqual(expected, ((OkObjectResult)okResult.Result).Value);
        }
        [Test]
        public async Task DeleteHistoryTest()
        {
            string expression = "2+2*2";
            string expected = "History is empty";

            var helpfulRequest = await calculatorController.Get(expression, historyService, calculatorService);
            var notEmptyHistory = await historyController.Delete(historyService);
            var fullHistoryEmptyRequest = await historyController.Get(historyService);
            var okResult_EmptyHistory = await historyController.Delete(historyService);


            Assert.IsInstanceOf<OkObjectResult>(helpfulRequest.Result);
            Assert.IsInstanceOf<OkObjectResult>(notEmptyHistory.Result);
            Assert.IsInstanceOf<OkObjectResult>(fullHistoryEmptyRequest.Result);
            Assert.IsInstanceOf<OkObjectResult>(okResult_EmptyHistory.Result);
            Assert.AreEqual(expected, ((OkObjectResult)fullHistoryEmptyRequest.Result).Value);
        }
        [Test]
        public async Task GetSearchHistoryTest()
        {
            string request = "2+2";
            string expression1 = "2+2*2+1";
            string expression2 = "2*2+2+2";
            string expression3 = "2+2+2+3";
            string incorrectExpression = "3/0";
            string expected = expression1 + " = 7\r\n"
                + expression2 + " = 8\r\n"
                + expression3 + " = 9";

            var x1 = calculatorController.Get(expression1, historyService, calculatorService);
            var y1 = calculatorController.Get(incorrectExpression, historyService, calculatorService);
            var x2 = calculatorController.Get(expression2, historyService, calculatorService);
            var y2 = calculatorController.Get(incorrectExpression, historyService, calculatorService);
            var x3 = calculatorController.Get(expression3, historyService, calculatorService);
            await Task.WhenAll(new[] { x1, x2, x3, y1, y2 });
            var okResult = await historyController.Get(request, historyService);

            Assert.IsInstanceOf<OkObjectResult>(okResult.Result);
            Assert.AreEqual(expected, ((OkObjectResult)okResult.Result).Value);
        }
        [Test]
        public async Task GetSearchHistoryFailTest()
        {
            string request = "2+2";
            string expected = request + " not found in history";

            var notFoundObjectResult1 = await historyController.Get(request, historyService);
            var calculatorControllerOkResult = await calculatorController.Get("2*2", historyService, calculatorService);
            var notFoundObjectResult2 = await historyController.Get(request, historyService);

            Assert.IsInstanceOf<NotFoundObjectResult>(notFoundObjectResult1.Result);
            Assert.IsInstanceOf<OkObjectResult>(calculatorControllerOkResult.Result);
            Assert.IsInstanceOf<NotFoundObjectResult>(notFoundObjectResult2.Result);
            Assert.AreEqual(expected, ((NotFoundObjectResult)notFoundObjectResult1.Result).Value);
            Assert.AreEqual(expected, ((NotFoundObjectResult)notFoundObjectResult2.Result).Value);
        }
    }
}
