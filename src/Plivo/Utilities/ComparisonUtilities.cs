using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Plivo.Utilities
{
    public static class ComparisonUtilities
    {
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
                    if (target.GetValue(StringUtilities.SnakeCaseToPascalCase(sourcePair.Key)) == null)
                    {
                        returnString.Append("Key " + StringUtilities.SnakeCaseToPascalCase(sourcePair.Key)
                                                   + " not found" + ", ");
                    }
                    else
                    {
                        returnString.Append(CompareObjects(sourcePair.Value.ToObject<JObject>(),
                            target.GetValue(StringUtilities.SnakeCaseToPascalCase(sourcePair.Key))
                                .ToObject<JObject>()));
                    }
                }
                else if (sourcePair.Value.Type == JTokenType.Array)
                {
                    if (target.GetValue(StringUtilities.SnakeCaseToPascalCase(sourcePair.Key)) == null)
                    {
                        returnString.Append("Key " + StringUtilities.SnakeCaseToPascalCase(sourcePair.Key)
                                                   + " not found" + ", ");
                    }
                    else
                    {
                        returnString.Append(CompareArrays(sourcePair.Value.ToObject<JArray>(),
                            target.GetValue(StringUtilities.SnakeCaseToPascalCase(sourcePair.Key)).ToObject<JArray>(),
                            StringUtilities.SnakeCaseToPascalCase(sourcePair.Key)));
                    }
                }
                else
                {
                    JToken expected = sourcePair.Value;
                    var actual = target.SelectToken(StringUtilities.SnakeCaseToPascalCase(sourcePair.Key));
                    if (actual == null)
                    {
                        actual = target.SelectToken(sourcePair.Key);
                    }
                    if (actual == null)
                    {
                        returnString.Append("Key " + StringUtilities.SnakeCaseToPascalCase(sourcePair.Key)
                                                   + " not found" + ", ");
                    }
                    else
                    {
                        if (!JToken.DeepEquals(expected, actual))
                        {
                            returnString.Append("Key " + StringUtilities.SnakeCaseToPascalCase(sourcePair.Key) + ": "
                                                + sourcePair.Value + " !=  "
                                                + target.Property(StringUtilities.SnakeCaseToPascalCase(sourcePair.Key))
                                                    .Value
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
        public static StringBuilder CompareArrays(JArray source, JArray target, string arrayName = "")
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
            var missingProps = xptProps.Where(expected =>
                actProps.All(actual => StringUtilities.CamelCaseToSnakeCase(actual.Name) != expected.Name));

            return missingProps;
        }
    }
}