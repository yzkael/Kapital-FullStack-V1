using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace src.Extensions.Application
{
    public static class AppConfiguration
    {
        //Made for testing purposes
        public static void AddCorsDevConfig(this WebApplication app)
        {
            app.UseCors("DevCors");
        }
    }
}