using Newtonsoft.Json;

namespace KarDo.WebAPI.Middlewares
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _request;

        public GlobalExceptionHandler(RequestDelegate request)
        {
            _request = request;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _request(httpContext);
            }
            catch (Exception e)
            {
                await HandleOurException(httpContext, e);
            }
        }

        private async Task HandleOurException(HttpContext context, Exception exception)
        {

            await context.Response.WriteAsync(JsonConvert.SerializeObject(new Error
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message
            }));
        }

        public class Error
        {
            public int StatusCode { get; set; }
            public string Message { get; set; }
        }
    }
}
