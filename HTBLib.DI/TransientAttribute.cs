using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace HTBLib.DI
{
    public class TransientAttribute : DependencyAttribute
    {
        public override void Add(IServiceCollection services, Type type) => services.AddTransient(type);
    }
}
