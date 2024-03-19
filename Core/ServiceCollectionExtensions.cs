using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace VSTest.Core;

/// <summary>
/// Этот класс содержит общие методы расширения IServiceCollection
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Регистрация в коллекции сервисов всеx типов сборки
    /// </summary>
    /// <param name="services">Коллекция сервисов</param>
    /// <param name="assembly">Сборка с сервисами</param>
    /// <returns>Коллекция сервисов</returns>
    public static IServiceCollection AddSelfRegisteredServices(this IServiceCollection services, Assembly assembly)
    {
        foreach (var dependency
            in assembly.EnumerateGenericImplementationsOf(typeof(ISelfRegisteredService<>)))
                services.AddScoped(dependency.TypeParameters[0], dependency.Implementation);

        return services;
    }
}
