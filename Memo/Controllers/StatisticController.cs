using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;

namespace Memo.Api.Controllers
{
    public class StatisticController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
         
            return Ok(10);
        }
    }
}