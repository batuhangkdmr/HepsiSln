using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HepsiAPI.Application
{
    public static class Resgistration
    {
        public static void AppApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));// bu assemblyde olan tüm servislerimizi bu şekilde dependency enjection a eklemiş oluyoruz
        }
    }
}
