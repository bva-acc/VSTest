using System.Reflection;

namespace VSTest.Core;

public static class AssemblyExtensions
{
    public static IEnumerable<GenericDependency> EnumerateGenericImplementationsOf(
        this Assembly assembly,
        Type serviceType)
    {
        return assembly
            .GetTypes()
            .Where(t => !t.IsAbstract)
            .SelectMany(
                t => t.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == serviceType)
                    .Select(i => new GenericDependency
                    {
                        Implementation = t,
                        TypeParameters = i.GetGenericArguments().ToArray(),
                        Service = i
                    }));
    }
}