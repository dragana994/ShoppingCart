using ShoppingCart.SharedKernel;
using System.Net;
using System.Text.Json;

namespace ShoppingCart.Api.Middleware
{
    //TODO fix this
    public class ExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                var errorResult = new ErrorResult
                {
                    Source = exception.TargetSite?.DeclaringType?.FullName,
                    Exception = exception.Message.Trim()
                };

                errorResult.Messages.Add(exception.Message);

                switch (exception)
                {
                    case ArgumentException:
                        errorResult.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;

                    default:
                        errorResult.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var response = context.Response;
                if (!response.HasStarted)
                {
                    response.ContentType = "application/json";
                    response.StatusCode = errorResult.StatusCode;
                    await response.WriteAsync(JsonSerializer.Serialize(errorResult));
                }
                else
                {
                    //TODO Add Logger
                }
            }
        }
    }
}
