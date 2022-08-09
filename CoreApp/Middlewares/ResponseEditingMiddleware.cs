using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CoreApp.Middlewares
{
    public class ResponseEditingMiddleware
    {
        private RequestDelegate _requestDelegate;
        public ResponseEditingMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }
        public async Task Invoke(HttpContext context)
        {
            await _requestDelegate.Invoke(context);
            if (context.Response.StatusCode==StatusCodes.Status404NotFound)
            {
                //await context.Response.WriteAsync("Olmayan Sayfaya Gittiniz"); //yönlendirme için sildim.
                context.Response.Redirect("Home/Index"); //await redirect yönlendirmesi ile konuşla // startup endpoints den değiştirebilirsin.
            }
        }
    }
}
