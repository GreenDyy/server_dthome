
using Microsoft.Extensions.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace server_dthome.Repositories
{
    public class TwilioSMSRepository : ITwilioSMSRepository
    {
        private readonly string _accountSid;
        private readonly string _authToken;
        private readonly string _fromPhoneNumber;
        public readonly IConfiguration _configuration;

        public TwilioSMSRepository(IConfiguration configuration)
        {
            _configuration = configuration;

            _accountSid = _configuration["Twilio:AccountSid"];
            _authToken = _configuration["Twilio:AuthToken"];
            _fromPhoneNumber = _configuration["Twilio:FromPhoneNumber"];
            TwilioClient.Init(_accountSid, _authToken);
        }

        public async Task SendSms(string toPhoneNumber, string message)
        {
            //var messageOptions = new CreateMessageOptions(new PhoneNumber(toPhoneNumber))
            //{
            //    From = new PhoneNumber(_fromPhoneNumber),
            //    Body = message,    
            //};

            //var msg = await MessageResource.CreateAsync(messageOptions);

            var msg = await MessageResource.CreateAsync(
                 body: message,
                 from: new PhoneNumber(_fromPhoneNumber),
                 to: new PhoneNumber(toPhoneNumber));
            Console.WriteLine("oh yeah", msg.Body);
        }
    }
}
