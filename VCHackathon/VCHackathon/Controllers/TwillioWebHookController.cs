using Newtonsoft.Json;
using System.Web.Http;
using Twilio.Mvc;
using Twilio.TwiML.Mvc;
using VCHackathon.Filters;
using VCHackathon.Services;

namespace VCHackathon.Controllers
{
    [ExceptionFilter]
    public class TwillioWebHookController : ApiController
    {
        public TwiMLResult Index(SmsRequest request)
        {
            Logger.LogInfo($"Content : {request.Body}");

            return new TwiMLResult();
        }
    }
}
