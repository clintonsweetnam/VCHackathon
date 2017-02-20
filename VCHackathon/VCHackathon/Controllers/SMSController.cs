using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Twilio;
using VCHackathon.Filters;
using VCHackathon.Models;

namespace VCHackathon.Controllers
{
    [ExceptionFilter]
    public class SMSController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post(SendMessageModel model)
        {
            var accountSid = "AC0dcce29fe32f1ec447531d0f2bde44c9"; // Your Account SID from www.twilio.com/console
            var authToken = "96f6441d059c68d4b1105f55de64b572";  // Your Auth Token from www.twilio.com/console
            var twillioPhoneNumber = ConfigurationManager.AppSettings["TwilloPhoneNumber"];

            var twilio = new TwilioRestClient(accountSid, authToken);
            var message = twilio.SendMessage(
                twillioPhoneNumber, // From (Replace with your Twilio number)
                model.PhoneNumber, // To (Replace with your phone number)
                model.MessageContent
                );

            if (message.RestException != null)
            {
                var error = message.RestException.Message;
                Console.WriteLine(error);
                Console.Write("Press any key to continue.");
                Console.ReadKey();
            }

            return new HttpResponseMessage(HttpStatusCode.OK);
        }
    }
}
