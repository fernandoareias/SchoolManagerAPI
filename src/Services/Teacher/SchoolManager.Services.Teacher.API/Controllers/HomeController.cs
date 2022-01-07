using Microsoft.AspNetCore.Mvc;
using SchoolManager.Services.Teacher.Domain.Teacher.Response;
using System.Threading.Tasks;

namespace SchoolManager.Services.Teacher.API.Controllers
{
    [ApiController]
    [Route("api/health")]
    public class HomeController : Controller
    {
      
        [HttpGet]
        public async Task<IActionResult> GetHealth()
        {
            return await Task.FromResult(
                Ok(
                    new ResponseView(true, "[+] Status: On", null)
                  )
                );
        }
    }
}
