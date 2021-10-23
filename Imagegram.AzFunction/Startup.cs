using Imagegram.Application;
using Imagegram.Persistence;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

[assembly: FunctionsStartup(typeof(Imagegram.AzFunction.Startup))]
namespace Imagegram.AzFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            //var configuration = builder.GetContext().Configuration;
            builder.Services.ConfigurePesistenceServices();
            builder.Services.ConfigureApplicationServices();
        }
    }
}
