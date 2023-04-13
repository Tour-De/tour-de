namespace TourDe.Api.Middleware;

public class ExceptionMiddleware: IMiddleware
{
    /// <inheritdoc />
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            var responseContent = new ErrorResponse
            {
                Code = StatusCodes.Status207MultiStatus,
                Message = e.Message,
            };

            context.Response.StatusCode = responseContent.Code;
            await context.Response.WriteAsJsonAsync(responseContent);
        }
    }

    public class ErrorResponse
    {
        public string? Message { get; set; }
        
        public int Code { get; set; }
    }
}