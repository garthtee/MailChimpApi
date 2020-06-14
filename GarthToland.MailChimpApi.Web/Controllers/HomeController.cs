using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GarthToland.MailChimpApi.Web.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new { version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString() });
        }
    }
}