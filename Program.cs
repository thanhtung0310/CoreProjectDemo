using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CoreProjectDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) 
        {
            var builder = new WebHostBuilder()
                // dùng Kestrel
                .UseKestrel()
                // sử dụng Startup
                .UseStartup<Startup>()
                // cấu hình địa chỉ root
                .UseContentRoot(Directory.GetCurrentDirectory())
                // cấu hình về app
                .ConfigureAppConfiguration((hostingContext, config) => 
                {
                    // lấy từ file settings
                    var env = hostingContext.HostingEnvironment;
                    config.AddJsonFile(path: "appsettings.json", optional: true, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional:true, reloadOnChange:true);

                    // lấy từ user Secrets
                    if (env.IsDevelopment())
                    {
                        var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
                        if (appAssembly != null)
                        {
                            config.AddUserSecrets(appAssembly, optional: true);
                        }
                    }

                    // lấy từ Environment Variables
                    config.AddEnvironmentVariables();

                    // lấy từ command line args
                    if (args != null)
                    {
                        config.AddCommandLine(args);
                    }
                })
                // cấu hình log
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.AddConfiguration(hostingContext.Configuration.GetSection(key: "Logging"));
                    logging.AddConsole();
                    logging.AddDebug();
                })
                // chạy trên IIS để catch trace
                .UseIISIntegration()
                // sử dụng service provider mặc định
                .UseDefaultServiceProvider((context, options) =>
                {
                    options.ValidateScopes = context.HostingEnvironment.IsDevelopment();
                });
            return builder;
        }
    }
}
