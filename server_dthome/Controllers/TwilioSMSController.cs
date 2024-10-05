using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_dthome.Repositories;

namespace server_dthome.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TwilioSMSController : ControllerBase
    {
        private readonly ITwilioSMSRepository _smsRepository;
        public TwilioSMSController(ITwilioSMSRepository smsRepository)
        {
            _smsRepository = smsRepository;
        }

        [HttpPost("send-sms")]
        public async Task<IActionResult> SendSms([FromBody] SmsRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _smsRepository.SendSms(request.ToPhoneNumber, request.Message);
            return Ok("SMS đã được gửi đi!");
        }
    }

    public class SmsRequest
    {
        public string ToPhoneNumber { get; set; }
        public string Message { get; set; }
    }
}