using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GarthToland.MailChimpApi.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SubscriptionController : Controller
    {
        private readonly IMailChimpService _mailChimpService;

        public SubscriptionController(IMailChimpService mailChimpService)
        {
            _mailChimpService = mailChimpService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Subscriber subscriber)
        {
            if (string.IsNullOrEmpty(subscriber.FirstName) || string.IsNullOrEmpty(subscriber.Email))
            {
                return BadRequest();
            }

            var result = await _mailChimpService.CreateSubscriberAsync(subscriber);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result.Id);
        }
    }
}