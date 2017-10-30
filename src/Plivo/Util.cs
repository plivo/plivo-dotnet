using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
// using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Plivo
{
    /// <summary>
    /// Util.
    /// </summary>
    public class Util
    {
        /// <summary>
        /// XPlivoSignature
        /// </summary>
        public class XPlivoSignature
        {
            /// <summary>
            /// Verify the signature
            /// </summary>
            /// <param name="uri"></param>
            /// <param name="plivoHttpParams"></param>
            /// <param name="xPlivoSignature"></param>
            /// <param name="authToken"></param>
            /// <returns></returns>
            public static bool Verify(string uri, Dictionary<string, object> plivoHttpParams, string xPlivoSignature, string authToken)
            {
                return false;
            }
        }

        /// <summary>
        /// HtmlEntity.
        /// </summary>
        public class HtmlEntity
        {
            /// <summary>
            /// Escapes unicode characters in input string
            /// </summary>
            /// <param name="inputText"></param>
            /// <returns></returns>
            public static string Convert(string inputText)
            {
                StringBuilder builder = new StringBuilder();
                foreach (char c in inputText)
                {
                    if ((int)c > 127)
                    {
                        builder.Append("&#");
                        builder.Append((int)c);
                        builder.Append(";");
                    }
                    else
                    {
                        builder.Append(c);
                    }
                }
                return builder.ToString();
            }
        }
        
        /// <summary>
        /// Compare the specified json and a.
        /// </summary>
        /// <returns>The compare.</returns>
        /// <param name="json">Json.</param>
        /// <param name="a">The alpha component.</param>
        public static string Compare(string json, object a)
        {
            return
                CompareObjects(
                    JObject.Parse(json),
                    JObject.Parse(
                        JsonConvert.SerializeObject(a))).ToString();
        }

        /// <summary>
        /// Compares the objects changing the case of source from snakecase to Pascal case
        /// </summary>
        /// <returns>The objects.</returns>
        /// <param name="source">Source.</param>
        /// <param name="target">Target.</param>
        public static StringBuilder CompareObjects(JObject source, JObject target)
        {
            StringBuilder returnString = new StringBuilder();
            foreach (KeyValuePair<string, JToken> sourcePair in source)
            {
                if (sourcePair.Value.Type == JTokenType.Object)
                {
                    if (target.GetValue(SnakeCaseToPascalCase(sourcePair.Key)) == null)
                    {
                        returnString.Append("Key " + SnakeCaseToPascalCase(sourcePair.Key)
                                            + " not found" + ", ");
                    }
                    else
                    {
                        returnString.Append(CompareObjects(sourcePair.Value.ToObject<JObject>(),
                            target.GetValue(SnakeCaseToPascalCase(sourcePair.Key)).ToObject<JObject>()));
                    }
                }
                else if (sourcePair.Value.Type == JTokenType.Array)
                {
                    if (target.GetValue(SnakeCaseToPascalCase(sourcePair.Key)) == null)
                    {
                        returnString.Append("Key " + SnakeCaseToPascalCase(sourcePair.Key)
                                            + " not found" + ", ");
                    }
                    else
                    {
                        returnString.Append(CompareArrays(sourcePair.Value.ToObject<JArray>(),
                            target.GetValue(SnakeCaseToPascalCase(sourcePair.Key)).ToObject<JArray>(), 
                            SnakeCaseToPascalCase(sourcePair.Key)));
                    }
                }
                else
                {
                    JToken expected = sourcePair.Value;
                    var actual = target.SelectToken(SnakeCaseToPascalCase(sourcePair.Key));
                    if (actual == null)
                    {
                        returnString.Append("Key " + SnakeCaseToPascalCase(sourcePair.Key)
                                            + " not found" + ", ");
                    }
                    else
                    {
                        if (!JToken.DeepEquals(expected, actual))
                        {
                            returnString.Append("Key " + SnakeCaseToPascalCase(sourcePair.Key) + ": "
                                                + sourcePair.Value + " !=  "
                                                + target.Property(SnakeCaseToPascalCase(sourcePair.Key)).Value
                                                + ", ");
                        }
                    }
                }
            }
            return returnString;
        }

        /// <summary>
        /// Deep compare two JObjects. If they don't match, returns text diffs
        /// </summary>
        /// <returns>The raw objects.</returns>
        /// <param name="source">Source.</param>
        /// <param name="target">Target.</param>
        public static StringBuilder CompareRawObjects(JObject source, JObject target)
        {
            StringBuilder returnString = new StringBuilder();
            foreach (KeyValuePair<string, JToken> sourcePair in source)
            {
                if (sourcePair.Value.Type == JTokenType.Object)
                {
                    if (target.GetValue((sourcePair.Key)) == null)
                    {
                        returnString.Append("Key " + (sourcePair.Key)
                                            + " not found" + ", ");
                    }
                    else
                    {
                        returnString.Append(CompareObjects(sourcePair.Value.ToObject<JObject>(),
                            target.GetValue((sourcePair.Key)).ToObject<JObject>()));
                    }
                }
                else if (sourcePair.Value.Type == JTokenType.Array)
                {
                    if (target.GetValue((sourcePair.Key)) == null)
                    {
                        returnString.Append("Key " + (sourcePair.Key)
                                            + " not found" + ", ");
                    }
                    else
                    {
                        returnString.Append(CompareArrays(sourcePair.Value.ToObject<JArray>(),
                            target.GetValue((sourcePair.Key)).ToObject<JArray>(), 
                            (sourcePair.Key)));
                    }
                }
                else
                {
                    JToken expected = sourcePair.Value;
                    var actual = target.SelectToken((sourcePair.Key));
                    if (actual == null)
                    {
                        returnString.Append("Key " + (sourcePair.Key)
                                            + " not found" + ", ");
                    }
                    else
                    {
                        if (!JToken.DeepEquals(expected, actual))
                        {
                            returnString.Append("Key " + (sourcePair.Key) + ": "
                                                + sourcePair.Value + " !=  "
                                                + target.Property((sourcePair.Key)).Value
                                                + ", ");
                        }
                    }
                }
            }
            return returnString;
        }

        /// <summary>
        /// Deep compare two NewtonSoft JArrays. If they don't match, returns text diffs
        /// </summary>
        /// <param name="source">The expected results</param>
        /// <param name="target">The actual results</param>
        /// <param name="arrayName">The name of the array to use in the text diff</param>
        /// <returns>string string</returns>
        private static StringBuilder CompareArrays(JArray source, JArray target, string arrayName = "")
        {
            var returnString = new StringBuilder();
            for (var index = 0; index < source.Count; index++)
            {

                var expected = source[index];
                if (expected.Type == JTokenType.Object)
                {
                    var actual = (index >= target.Count) ? new JObject() : target[index];
                    returnString.Append(CompareObjects(expected.ToObject<JObject>(),
                        actual.ToObject<JObject>()));
                }
                else
                {

                    var actual = (index >= target.Count) ? "" : target[index];
                    if (!JToken.DeepEquals(expected, actual))
                    {
                        if (String.IsNullOrEmpty(arrayName))
                        {
                            returnString.Append("Index " + index + ": " + expected
                                                + " != " + actual + ", ");
                        }
                        else
                        {
                            returnString.Append("Key " + arrayName
                                                + "[" + index + "]: " + expected
                                                + " != " + actual + ", ");
                        }
                    }
                }
            }
            return returnString;
        }

        /// <summary>
        /// Compare two json strings
        /// </summary>
        /// <returns>The compare.</returns>
        /// <param name="expectedJson">Expected json.</param>
        /// <param name="actualJson">Actual json.</param>
        public static IEnumerable<JProperty> DoCompare(string expectedJson, string actualJson)
        {
            // convert JSON to object
            JObject xptJson = JObject.Parse(expectedJson);
            JObject actJson = JObject.Parse(actualJson);

            // read properties
            var xptProps = xptJson.Properties().ToList();
            var actProps = actJson.Properties().ToList();

            // find missing properties
            var missingProps = xptProps.Where(expected => actProps.All(actual => CamelCaseToSnakeCase(actual.Name) != expected.Name));

            return missingProps;
        }

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
                new [] {"_"},
                StringSplitOptions.None
            ).Select(
                s => s == "" ? "_" :char.ToUpperInvariant(s[0]) + s.Substring(1, s.Length - 1)).Aggregate(string.Empty, (s1, s2) => s1 + s2);
        }
    }
}
