using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using Xamarin.Forms;

namespace HTBLib.DI.Xamarin
{
    public class DIApp : Application
    {
        private readonly IHost host;

        public DIApp()
        {
            host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => LoadServices(context, services))
                .Build();
        }

        protected override async void OnStart()
        {
            await host.StartAsync();
            base.OnStart();
        }

        private void LoadServices(HostBuilderContext context, IServiceCollection services)
        {
            foreach (var a in
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
