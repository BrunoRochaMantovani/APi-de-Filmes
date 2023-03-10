using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Security.Authentication;

namespace Filmes_API.ViewModels
{
    public static class ResultViewModel
    {

        public static ProblemDetails ToProblemDetails(this Exception e)
        {
            return new ProblemDetails()
            {
                Status = (int)GetErrorCode(e.InnerException ?? e),
                Title = e.Message
            };
        }

        private static HttpStatusCode GetErrorCode(Exception e)
        {
            switch (e)
            {
                case ValidationException _:
                    return HttpStatusCode.BadRequest;
                case FormatException _:
                    return HttpStatusCode.BadRequest;
                case AuthenticationException _:
                    return HttpStatusCode.Forbidden;
                case NotImplementedException _:
                    return HttpStatusCode.NotImplemented;
                default:
                    return HttpStatusCode.InternalServerError;
            }
        }
    }
}
