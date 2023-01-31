using Microsoft.Extensions.DependencyInjection;
using System;

namespace DIInWPF.StartupHelpers;

public static class ServiceExtensions
{
    public static void AddDependencyFactory<TDepen>(this IServiceCollection services)
        where TDepen : class
    {
        services.AddTransient<TDepen>();
        services.AddSingleton<Func<TDepen>>(x => () => x.GetService<TDepen>()!);
        services.AddSingleton<IAbstractFactory<TDepen>, AbstractFactory<TDepen>>();
    }
}
    