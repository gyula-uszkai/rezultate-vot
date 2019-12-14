using System;
using Amazon.Extensions.NETCore.Setup;
using ElectionResults.Core.Storage;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace ElectionResults.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, builder) =>
                {
                    var env = hostingContext.HostingEnvironment;
                    builder.AddJsonFile("appsettings.json", true, true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    if (env.EnvironmentName == "Development")
                    {
                        builder.AddSystemsManager($"/{Consts.ParameterStoreName}-dev", new AWSOptions
                        {
                            DefaultClientConfig =
                            {
                                ServiceURL = "http://localhost:4583",
                                UseHttp = true
                            }
                        }, TimeSpan.FromSeconds(30));
                    }
                    else
                        builder.AddSystemsManager($"/{Consts.ParameterStoreName}", new AWSOptions(), TimeSpan.FromSeconds(30));
                })
                .UseStartup<Startup>();
    }
}
