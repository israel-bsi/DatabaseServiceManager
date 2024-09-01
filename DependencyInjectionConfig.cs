using DatabaseServiceManager.Common;
using DatabaseServiceManager.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseServiceManager;

public class DependencyInjectionConfig
{
    public static ServiceProvider Configure()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddTransient<FrmMain>();
        serviceCollection.AddTransient<IService, DatabaseService>();

        return serviceCollection.BuildServiceProvider();
    }
}