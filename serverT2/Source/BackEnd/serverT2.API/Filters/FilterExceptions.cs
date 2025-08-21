using serverT2.Communication.Responses;
using serverT2.Exceptions;
using serverT2.Exceptions.BaseExceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using serverT2.Exceptions;
using System.Net;

namespace api._20.API.Filters
{
    public class FilterExceptions : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is FileBookException) 
            {
                HandleProjectException(context);
            } 
            else
            {
                ThrowUnknowException(context);

            }
        }
        private void HandleProjectException(ExceptionContext context)
        {
            if(context.Exception is ErrorOnValidationException)
            {
                var exception = context.Exception as ErrorOnValidationException;
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ReponseErrorJson(exception.Errors));
            }
        }
        private void ThrowUnknowException(ExceptionContext context)
        {
            if (context.Exception is ErrorOnValidationException)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Result = new ObjectResult(new ReponseErrorJson(ResourceMessages.UNKNOW_ERROR));
            }
        } // sincronização de repositorios
    }


}
