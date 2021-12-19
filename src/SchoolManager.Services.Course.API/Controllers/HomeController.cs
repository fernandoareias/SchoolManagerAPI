using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SchoolManager.Services.Course.API.Controllers
{
    [ApiController]
    [Route("api/health")]
    public class HomeController : Controller
    {
      
        [HttpGet]
        public async Task<IActionResult> GetHealth()
        {
            return Ok();
        }
    }
}
