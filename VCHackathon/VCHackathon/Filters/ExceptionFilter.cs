using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using VCHackathon.Services;

namespace VCHackathon.Filters
{
    public class ExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public async Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            Logger.LogError("Error caught in exception filter", actionExecutedContext.Exception);

            actionExecutedContext.Response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
        }
    }
}