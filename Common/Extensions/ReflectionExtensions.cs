using System.Reflection;

namespace Common.Extensions;

public static class ReflectionExtensions
{
    public static Type[] GetTypesInNamespace(this Assembly assembly, string nameSpace)
    {
        return
            assembly.GetTypes()
                .Where(t => string.Equals(t.Namespace, nameSpace, StringComparison.Ordinal))
                .ToArray();
    }
}