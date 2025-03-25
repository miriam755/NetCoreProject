using System;
using NLog;

namespace FinishProject.API.Middlewares
{
    public class ShabbatMiddleware
    {
   
            private readonly Logger  logger = LogManager.GetCurrentClassLogger();
            private readonly RequestDelegate _next;

            public ShabbatMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public async Task InvokeAsync(HttpContext context)
            {
               logger.Warn("middleware start");
            var shabbat =
                DateTime.UtcNow.DayOfWeek == DayOfWeek.Saturday; ;
                if (shabbat)
                {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync("Service unavailable on Shabbat."); // שלח הודעה
            }
                else
                {
                    await _next(context);
                }

               logger.Info("middleware end");

            }
        }
    }

 
           
       