using NUnit.Framework;
using PMLAB_TestProject.Controllers;
using PMLAB_TestProject.Services;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace PMLAB_TestProject_Tests
{
    public class AbstractControllerTests
    {
        protected CalculatorController calculatorController;
        protected HistoryService historyService;
        protected CalculatorService calculatorService;
        protected string Path
        {
            get => Directory.GetParent(Directory.GetCurrentDirectory())
                .Parent.Parent.ToString() + "\\History\\history.txt";
        }
        [SetUp]
        public async Task Setup()
        {
            calculatorController = new CalculatorController();
            await ClearFile();
            historyService = new HistoryService(Path);
            calculatorService = new CalculatorService();
        }
        [TearDown]
        public async Task ClearFile()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(Path, false, Encoding.Default))
                {
                    await sw.WriteAsync(string.Empty);
                }
            }
            catch (Exception) { }
        }
    }
}
