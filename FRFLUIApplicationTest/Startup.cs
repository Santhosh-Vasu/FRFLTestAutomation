using FRFLApplicationTest.Pages;
using FRFLTestFramework.Config;
using FRFLTestFramework.Driver;
using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;


namespace FRFLUIApplicationTest
{
    
    public class Startup
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();
            services
           .AddSingleton(ConfigReader.Readconfig())
           .AddScoped<IDriverFixture, DriverFixture>()
           .AddScoped<IApplicationHomePage, ApplicationHomePage>();

            return services;
        }
        //public void Configure(IServiceProvider provider)
        //{

        //}

    }
}
