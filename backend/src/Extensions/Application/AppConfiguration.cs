using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace src.Extensions.Application
{
    public static class AppConfiguration
    {
        public static void ConfigureSeeContext(this WebApplication app)
        {
            app.Use(async (context, next) =>
            {
                Console.WriteLine(context.Request.Headers.Cookie);
                Console.WriteLine("POTOOOOOOOOOOOOOOOOOOOOOO");
                // Call the next delegate/middleware in the pipeline.  
                await next(context);
            });
        }
    }
}