using Microsoft.AspNetCore.Mvc;
using PMLAB_TestProject.Services;
using System;
using System.Threading.Tasks;

namespace PMLAB_TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {        
        [HttpGet]
        public async Task<ActionResult<double>> Post([FromQuery]string expression, [FromServices]HistoryService historyService, [FromServices]CalculatorService calculator)
        {
            string history = string.Empty;
            try
            {
                double result = calculator.Calculate(expression);
                history = $"{expression} = {result}";
                return Ok(result);
            }
            catch (DivideByZeroException ex)
            {
                history = ex.Message;
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                history = ex.Message;
                return BadRequest($"Incorrect input, please, try again\n{expression}\n{ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong, please, try again later\n{ex.Message}");
            }
            finally
            {
                await historyService.Append(history);
            }
        }
    }
}