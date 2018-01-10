using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Plivo
{
    /// <summary>
    /// Util.
    /// </summary>
    public static class Util
    {
        /// <summary>
        /// XPlivoSignature
        /// </summary>
        public static class XPlivoSignature
        {
            /// <summary>
            /// Verify the signature
            /// </summary>
            /// <param name="uri"></param>
            /// <param name="plivoHttpParams"></param>
            /// <param name="xPlivoSignature"></param>
            /// <param name="authToken"></param>
            /// <returns></returns>
            [System.Obsolete("Util.XPlivoSignature.Verify is deprecated. Use Utilities.XPlivoSignature.Verify instead.")]
            public static bool Verify(string uri, Dictionary<string, object> plivoHttpParams, string xPlivoSignature, string authToken)
            {
                return Utilities.XPlivoSignature.Verify(uri, plivoHttpParams, xPlivoSignature, authToken);
            }
        }

        /// <summary>
        /// HtmlEntity.
        /// </summary>
        public static class HtmlEntity
        {
            /// <summary>
            /// Escapes unicode characters in input string
            /// </summary>
            /// <param name="inputText"></param>
            /// <returns></returns>
            [System.Obsolete("Util.HtmlEntity.Convert is deprecated. Use Utilities.HtmlEntity.Convert instead.")]
            public static string Convert(string inputText)
            {
                return Utilities.HtmlEntity.Convert(inputText);
            }
        }

        /// <summary>
        /// Compare the specified json and a.
        /// </summary>
        /// <returns>The compare.</returns>
        /// <param name="json">Json.</param>
        /// <param name="a">The alpha component.</param>
        [System.Obsolete("Util.Compare is deprecated. Use Utilities.ComparisonUtilities.Compare instead.")]
        public static string Compare(string json, object a)
        {
            return Utilities.ComparisonUtilities.Compare(json, a);
        }

        /// <summary>
        /// Compares the objects changing the case of source from snakecase to Pascal case
        /// </summary>
        /// <returns>The objects.</returns>
        /// <param name="source">Source.</param>
        /// <param name="target">Target.</param>
        [System.Obsolete("Util.CompareObjects is deprecated. Use Utilities.ComparisonUtilities.CompareObjects instead.")]
        public static StringBuilder CompareObjects(JObject source, JObject target)
        {
            return Utilities.ComparisonUtilities.CompareObjects(source, target);
        }

        /// <summary>
        /// Deep compare two JObjects. If they don't match, returns text diffs
        /// </summary>
        /// <returns>The raw objects.</returns>
        /// <param name="source">Source.</param>
        /// <param name="target">Target.</param>
        [System.Obsolete("Util.CompareRawObjects is deprecated. Use Utilities.ComparisonUtilities.CompareRawObjects instead.")]
        public static StringBuilder CompareRawObjects(JObject source, JObject target)
        {
            return Utilities.ComparisonUtilities.CompareRawObjects(source, target);
        }

        /// <summary>
        /// Deep compare two NewtonSoft JArrays. If they don't match, returns text diffs
        /// </summary>
        /// <param name="source">The expected results</param>
        /// <param name="target">The actual results</param>
        /// <param name="arrayName">The name of the array to use in the text diff</param>
        /// <returns>string string</returns>
        [System.Obsolete("Util.CompareArrays is deprecated. Use Utilities.ComparisonUtilities.CompareArrays instead.")]
        private static StringBuilder CompareArrays(JArray source, JArray target, string arrayName = "")
        {
            return Utilities.ComparisonUtilities.CompareArrays(source, target, arrayName);
        }

        /// <summary>
        /// Compare two json strings
        /// </summary>
        /// <returns>The compare.</returns>
        /// <param name="expectedJson">Expected json.</param>
        /// <param name="actualJson">Actual json.</param>
        [System.Obsolete("Util.DoCompare is deprecated. Use Utilities.ComparisonUtilities.DoCompare instead.")]
        public static IEnumerable<JProperty> DoCompare(string expectedJson, string actualJson)
        {
            return Utilities.ComparisonUtilities.DoCompare(expectedJson, actualJson);
        }

        /// <summary>
        /// Convert pascal case to snake case.
        /// </summary>
        /// <returns>The case to snake case.</returns>
        /// <param name="name">Name.</param>
        [System.Obsolete("Util.PascalCaseToSnakeCase is deprecated. Use Utilities.StringUtilities.PascalCaseToSnakeCase instead.")]
        public static string PascalCaseToSnakeCase(string name)
        {
            return Utilities.StringUtilities.PascalCaseToSnakeCase(name);
        }

        /// <summary>
        /// Converts camel case to snake case.
        /// </summary>
        /// <returns>The case to snake case.</returns>
        /// <param name="name">Name.</param>
        [System.Obsolete("Util.CamelCaseToSnakeCase is deprecated. Use Utilities.StringUtilities.CamelCaseToSnakeCase instead.")]
        public static string CamelCaseToSnakeCase(string name)
        {
            return Utilities.StringUtilities.CamelCaseToSnakeCase(name);
        }

        /// <summary>
        /// Converts snake case to pascal case.
        /// </summary>
        /// <returns>The case to pascal case.</returns>
        /// <param name="name">Name.</param>
        [System.Obsolete("Util.SnakeCaseToPascalCase is deprecated. Use Utilities.StringUtilities.SnakeCaseToPascalCase instead.")]
        public static string SnakeCaseToPascalCase(string name)
        {
            return Utilities.StringUtilities.SnakeCaseToPascalCase(name);
        }
    }
}