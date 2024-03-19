namespace VSTest.Core;

public class GenericDependency
{
    public Type[] TypeParameters { get; init; }
    public Type Service { get; init; }
    public Type Implementation { get; init; }
}