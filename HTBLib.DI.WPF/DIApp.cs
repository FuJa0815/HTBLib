using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Windows;

namespace HTBLib.DI.WPF
{
    public class DIApp<T> : Application
        where T : Window
    {
        private readonly IHost host;

        public DIApp()
        {
            host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => LoadServices(context, services))
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await host.StartAsync();
            var mainWindow = host.Services.GetRequiredService<T>();
            mainWindow.Show();
            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using (host)
            {
                await host.StopAsync(TimeSpan.FromSeconds(5));
            }
            base.OnExit(e);
        }

        private void LoadServices(HostBuilderContext context, IServiceCollection services)
        {
            foreach(var a in 
                from a in AppDomain.CurrentDomain.GetAssemblies()
                from t in a.GetTypes()
                let attributes = t.GetCustomAttributes(typeof(DependencyAttribute), true)
                where attributes != null && attributes.Length > 0
                select new { Type = t, Attribute = (DependencyAttribute)attributes[0] })
            {
                a.Attribute.Add(services, a.Type);
            }
        }
    }
}
