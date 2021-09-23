namespace Tanner.EmailApi.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Services;

    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly SendEmailService _emailService;

        public EmailController(SendEmailService emailService)
        {
            _emailService = emailService;
        }
        
        [HttpPost]
        public async Task <IActionResult> SendEmail([FromBody] CreateEmailRequest emailRequest)
        {
            // var contentToSend = emailRequest.Email + emailRequest.Name + emailRequest.Content;
            var contentToSend = emailRequest.Email + " \n" + emailRequest.Name + " \n" + emailRequest.Content;
            await _emailService.SendEmail("test", contentToSend);
            return Ok();
        }
    }

    public class CreateEmailRequest
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        
        
    }
}