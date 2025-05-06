using Domain.Exceptions;
using Microsoft.Extensions.Logging;
using Shared.ErrorModels;
using System.Diagnostics;
using System.Text.Json;

namespace E_Commerece.CustomMiddleware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate Next;
        private readonly ILogger logger;
        public CustomExceptionMiddleware(RequestDelegate Next,ILogger <CustomExceptionMiddleware> logger)
        {
            this.Next = Next;
            this.logger = logger;
        }

       

        public async Task Invoke(HttpContext context)
        {
            try
                {
                await Next.Invoke(context);
                if (context.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    var Responce = new ErrorToReturn()
                    {
                        ErrorMessage = $"EndPoint {context.Request.Path} is not found "
               ,
                        StatusCode = context.Response.StatusCode
                    };
                    var RespnceToReturn = JsonSerializer.Serialize(Responce);
                    await context.Response.WriteAsync(RespnceToReturn);

                }
            }
            catch (Exception ex){
                logger.LogError(ex, "Something Wrong");
                context.Response.StatusCode = ex switch
                {
                    NotFoundException=> StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError

                };
                context.Response.ContentType = "application/json";
                var Responce = new ErrorToReturn()
                {
                    ErrorMessage = ex.Message
                ,
                    StatusCode = context.Response.StatusCode
                };
                var RespnceToReturn=JsonSerializer.Serialize(Responce);
                await context.Response.WriteAsync(RespnceToReturn);

            }
        }

      
    }
}
