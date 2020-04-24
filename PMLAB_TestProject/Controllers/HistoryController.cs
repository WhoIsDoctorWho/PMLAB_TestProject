using Microsoft.AspNetCore.Mvc;
using PMLAB_TestProject.Services;
using System.Threading.Tasks;

namespace PMLAB_TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<string>> Get([FromServices]HistoryService historyService)
        {
            string result = await historyService.GetAll();            
            return result == string.Empty ? "History is empty" : result;
        }
        [HttpGet("search")]
        public async Task<ActionResult<string>> Get([FromQuery]string request, [FromServices]HistoryService historyService)
        {
            string result = await historyService.Search(request);
            if (result == string.Empty)
                return NotFound(request + " not found in history");
            return Ok(result);
        }
        [HttpDelete]
        public async Task<ActionResult<string>> Delete([FromServices]HistoryService historyService)
        {
            if (await historyService.Clear())
                return Ok("Success");
            return StatusCode(500, "Internal server error, try again later");
        }
    }
}
