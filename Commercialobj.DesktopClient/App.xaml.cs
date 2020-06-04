using Microsoft.Extensions.DependencyInjection;
using Commercialobj.ApplicationServices.GetAdmAreaListUseCase;
using Commercialobj.ApplicationServices.Ports.Cache;
using Commercialobj.ApplicationServices.Repositories;
using Commercialobj.DesktopClient.InfrastructureServices.ViewModels;
using Commercialobj.DomainObjects;
using Commercialobj.DomainObjects.Ports;
using Commercialobj.InfrastructureServices.Cache;
using Commercialobj.InfrastructureServices.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Commercialobj.DesktopClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDomainObjectsCache<commercialobj>, DomainObjectsMemoryCache<commercialobj>>();
            services.AddSingleton<NetworkCommercialobjRepository>(
                x => new NetworkCommercialobjRepository("localhost", 80, useTls: false, x.GetRequiredService<IDomainObjectsCache<commercialobj>>())
            );
            services.AddSingleton<CachedReadOnlyCommercialobjRepository>(
                x => new CachedReadOnlyCommercialobjRepository(
                    x.GetRequiredService<NetworkCommercialobjRepository>(), 
                    x.GetRequiredService<IDomainObjectsCache<commercialobj>>()
                )
            );
            services.AddSingleton<IReadOnlyCommercialobjRepository>(x => x.GetRequiredService<CachedReadOnlyCommercialobjRepository>());
            services.AddSingleton<IGetCommercialobjListUseCase, GetCommercialobjListUseCase>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<MainWindow>();
        }

        private void OnStartup(object sender, StartupEventArgs args)
        {
            var mainWindow = _serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }
}
