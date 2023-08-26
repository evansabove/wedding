using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using wedding_backend;

[assembly: FunctionsStartup(typeof(Startup))]
namespace wedding_backend
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
        }
    }
}
