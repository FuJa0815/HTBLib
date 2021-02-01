using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HTBLib.DI
{
    public class SingletonAttribute : DependencyAttribute
    {
        public override void Add(IServiceCollection services, Type type) => services.AddSingleton(type);
    }
}
