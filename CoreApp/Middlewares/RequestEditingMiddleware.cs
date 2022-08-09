using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CoreApp.Middlewares
{
    public class RequestEditingMiddleware
    {
        private RequestDelegate _requestDelegate;

        public RequestEditingMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task Invoke(HttpContext context) // Invoke olması gerekir.
        {
            if (context.Request.Path.ToString() == "/kaan")
            {
                await context.Response.WriteAsync("bu path güvenli değil");
            }
            else
            {
                await _requestDelegate.Invoke(context);
            }
        }
    }
}

