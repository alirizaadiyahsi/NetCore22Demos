using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// Applying the ApiConventionType attribute as an assembly level attribute.
// This applies the specified convention to all controllers in an assembly.
[assembly: ApiConventionType(typeof(DefaultApiConventions))]

namespace NetCore22Demos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseBeatPulse(options=>
                {
                    options.ConfigurePath(path:"health") //default hc
                        .ConfigureTimeout(milliseconds:1500) // default -1 infinitely
                        .ConfigureDetailedOutput(detailedOutput:true, includeExceptionMessages:true); //default (true,false)
                })
                .UseStartup<Startup>();
    }
}
