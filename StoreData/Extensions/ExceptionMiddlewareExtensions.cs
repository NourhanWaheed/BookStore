using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreData.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {

           //app.UseExceptionHandler(appError =>
           // {
           //     appError.Run(async context =>
           //     {
           //         context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
           //         context.Response.ContentType = "application/json";
           //         var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
           //         if (contextFeature != null)
           //         {
           //             await context.Response.WriteAsync(new ErrorDetails()
           //             {
           //                 StatusCode = context.Response.StatusCode,
           //                 Message = "Internal Server Error."
           //             }.ToString());
           //         }
           //     });
           // });
        }
    }
}
