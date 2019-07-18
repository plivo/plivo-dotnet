using System;
using System.Linq;

namespace Plivo.Utilities
{
    public static class StringUtilities
    {
        /// <summary>
        /// Convert pascal case to snake case.
        /// </summary>
        /// <returns>The case to snake case.</returns>
        /// <param name="name">Name.</param>
        public static string PascalCaseToSnakeCase(string name)
        {
            return string.Concat(
                (char.ToLowerInvariant(name[0]) + name.Substring(1)).ToCharArray().Select(
                    (x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString().ToLower() : x.ToString()));
        }

        /// <summary>
        /// Converts camel case to snake case.
        /// </summary>
        /// <returns>The case to snake case.</returns>
        /// <param name="name">Name.</param>
        public static string CamelCaseToSnakeCase(string name)
        {
            return string.Concat(
                name.ToCharArray().Select(
                    (x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString().ToLower() : x.ToString()));
        }

        /// <summary>
        /// Converts snake case to pascal case.
        /// </summary>
        /// <returns>The case to pascal case.</returns>
        /// <param name="name">Name.</param>
        public static string SnakeCaseToPascalCase(string name)
        {
            return name.Split(
                    new[] {"_"},
                    StringSplitOptions.None
                ).Select(
                    s => s == "" ? "_" : char.ToUpperInvariant(s[0]) + s.Substring(1, s.Length - 1))
                .Aggregate(string.Empty, (s1, s2) => s1 + s2);
        }
    }
}