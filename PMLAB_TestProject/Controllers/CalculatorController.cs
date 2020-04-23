using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using PMLAB_TestProject.Services;

namespace PMLAB_TestProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            throw new NotImplementedException();
        }
        [HttpGet("{expression}")]
        public ActionResult<string> Get(string expression)
        {
            throw new NotImplementedException();
        }
        [HttpPost]
        public ActionResult<string> Post([FromServices]CalculatorService calculator, [FromBody]string expression)
        {
            try
            {                
                return Ok(calculator.Calculate(expression));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }
    }
}