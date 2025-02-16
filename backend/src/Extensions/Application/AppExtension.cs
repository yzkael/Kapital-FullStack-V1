using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace src.Extensions.Application
{
    public static class AppExtension
    {
        public static void AddAppExtension(this WebApplication app)
        {
            app.UseExceptionHandler();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

        }
    }
}