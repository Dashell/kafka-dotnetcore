using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Product.API.Configuration;
using System.Net;

namespace Product.API.Infrastructure.Filters
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<HttpGlobalExceptionFilter> iLogger;

        public HttpGlobalExceptionFilter(ILogger<HttpGlobalExceptionFilter> iLogger)
        {
            this.iLogger = iLogger;
        }

        public void OnException(ExceptionContext context)
        {
            int code = StatusCodes.Status500InternalServerError;

            double? errorCode = default;

            switch (context.Exception)
            {
                #region Status Code selon les exceptions
                #endregion
            }

            if (code == (int)HttpStatusCode.InternalServerError)
            {
                iLogger.LogError(context.Exception, "Not handled exception thrown");
            }
            else
            {
                iLogger.LogWarning(context.Exception, "Handled exception thrown");
            }

            context.Result = new ObjectResult(new ErrorResult(context.Exception.Message, errorCode, context.Exception.StackTrace));
            context.HttpContext.Response.StatusCode = code;

            context.ExceptionHandled = true;
        }

        public class ErrorResult
        {
            /// <summary>
            /// Contenu de l'erreur
            /// </summary>
            public string Error { get; set; }

            /// <summary>
            /// Code de l'erreur
            /// </summary>
            public double? ErrorCode { get; set; }
            public string? StackTrace { get; set; }

            public ErrorResult(string error, double? errorCode, string? stackTrace)
            {
                Error = error;
                ErrorCode = errorCode;
                StackTrace = stackTrace;
            }
        }
    }
}
