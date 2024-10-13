using System.Net;
using Application.Common.Exceptions;
using Newtonsoft.Json;
using WebApi.Common.Models.Enums;
using WebApi.Common.Models.Responses.Common;

namespace WebApi.Common.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            
            response.ContentType = "application/json";
            
            var responseModel = new ErrorResponse { Message = "Falha ao realizar a operação", Description = error.Message };

            switch (error)
            {
                case ApiException:
                    // custom application error
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseModel.Code = GinzoErrorCode.InvalidObject;
                    break;
                case KeyNotFoundException:
                    // not found error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    responseModel.Code = GinzoErrorCode.InvalidParameter;
                    break;
                case InvalidOperationException:
                    // not found error
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseModel.Code = GinzoErrorCode.InvalidObject;
                    break;
                default:
                    // unhandled error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    responseModel.Code = GinzoErrorCode.Unknow;
                    break;
            }

            var result = JsonConvert.SerializeObject(responseModel);

            await response.WriteAsync(result);
        }
    }
}