using Microsoft.Extensions.DependencyInjection;
using System;

namespace HTBLib.DI
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public abstract class DependencyAttribute : Attribute
    {
        public abstract void Add(IServiceCollection services, Type type);
    }
}
