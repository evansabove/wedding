using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using wedding_backend;

[assembly: FunctionsStartup(typeof(Startup))]
namespace wedding_backend
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            IConfiguration config = new ConfigurationBuilder().AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                                                              .AddEnvironmentVariables()
                                                              .Build();

            var configObject = new Config
            {
                BlobStorageConnectionString = config["BlobStorageConnectionString"]
            };

            builder.Services.AddSingleton(configObject);
        }
    }
}
