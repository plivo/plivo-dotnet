using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Plivo.Utilities
{
    public static class XPlivoSignatureV3
    {
        /// <summary>
        /// Compute X-Plivo-Signature-V2
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="nonce"></param>
        /// <param name="authToken"></param>
        /// <returns></returns>
        public static string GenerateUrl(string uri, Dictionary<string, string> parameters, string method)
        {
            var parsedUrl = new Uri(uri);
            uri = parsedUrl.Scheme + "://" + parsedUrl.Host + parsedUrl.LocalPath;
            var parsedUrlQuery = Uri.UnescapeDataString(parsedUrl.Query);
            if (parameters.Any() || parsedUrl.Query.Length > 0)
            {
                uri += "?";
            }

            if (parsedUrl.Query.Length > 0)
            {
                if (method == "GET")
                {
                    var queryParamMap = getMapFromQueryString(parsedUrlQuery.TrimStart('?'));
                    foreach (var param in parameters.Keys)
                    {
                        queryParamMap.Add(param, parameters[param]);
                    }

                    foreach (KeyValuePair<string, string> kvp in queryParamMap)
                    {
                        Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                    }

                    uri += GetSortedQueryParamString(queryParamMap, true);
                }
                else
                {
                    uri += GetSortedQueryParamString(getMapFromQueryString(parsedUrlQuery.TrimStart('?')), true) +
                           "." + GetSortedQueryParamString(parameters, false);
                    uri = uri.TrimEnd('.');
                }
            }
            else
            {
                if (method == "GET")
                {
                    uri += GetSortedQueryParamString(parameters, true);
                }
                else
                {
                    uri += GetSortedQueryParamString(parameters, false);
                }
            }
            
            return uri;
        }

        public static Dictionary<string, string> getMapFromQueryString(string query)
        {
            Dictionary<string, string> mp = new Dictionary<string, string>();
            if (query.Length == 0)
            {
                return mp;
            }

            string[] keyValuePairs = query.Split('&');
            Array.Sort(keyValuePairs, StringComparer.Ordinal);
            foreach (var pairs in keyValuePairs)
            {
                var pair = pairs.Split(new[] {'='}, 2);
                if (pair.Count() == 2)
                {
                    mp[pair[0]] = pair[1];
                }
            }

            return mp;
        }

        public static string GetSortedQueryParamString(Dictionary<string, string> parameters, bool queryParams)
        {
            var url = "";
            var keys = parameters.Keys.ToList();
            keys.Sort(StringComparer.Ordinal);

            if (queryParams)
            {
                foreach (var key in keys)
                {
                    url += key + "=" + parameters[key] + "&";
                }

                url = url.TrimEnd('&');
            }
            else
            {
                foreach (var key in keys)
                {
                    url += key + parameters[key];
                }
            }

            return url;
        }

        public static string ComputeSignature(string uri, string nonce, string authToken,
            Dictionary<string, string> parameters, string method)
        {
            string payload = GenerateUrl(uri, parameters, method) + "." + nonce;
            var hash = new HMACSHA256(Encoding.UTF8.GetBytes(authToken));
            var computedHash = hash.ComputeHash(Encoding.UTF8.GetBytes(payload));
            return Convert.ToBase64String(computedHash);
        }

        /// <summary>
        /// Verify X-Plivo-Signature-V2
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="nonce"></param>
        /// <param name="xPlivoSignature"></param>
        /// <param name="authToken"></param>
        /// <returns></returns>
        public static bool VerifySignature(string uri, string nonce, string xPlivoSignature, string authToken,
            Dictionary<string, string> parameters, string method)
        {
            string computedSignature = ComputeSignature(uri, nonce, authToken, parameters, method);
            Console.WriteLine(computedSignature);
            var signatures = xPlivoSignature.Split(',');
            foreach (string signature in signatures)
            {
                if (computedSignature == signature)
                {
                    return true;
                }
            }

            return false;
        }
    }
}