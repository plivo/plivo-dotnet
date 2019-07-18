using System;
using System.Security.Cryptography;
using System.Text;

namespace Plivo.Utilities
{
    public static class XPlivoSignatureV2
    {
        /// <summary>
        /// Compute X-Plivo-Signature-V2
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="nonce"></param>
        /// <param name="authToken"></param>
        /// <returns></returns>
        public static string ComputeSignature(string uri, string nonce, string authToken)
        {
            var url = new Uri(uri);
            string absolutePath = url.AbsolutePath;

            string pathToAppend = "";

            int pathExists = uri.Replace(url.Scheme + "://" + url.Host, "")
                .IndexOf(absolutePath, StringComparison.CurrentCulture);

            if (pathExists > -1)
            {
                pathToAppend = absolutePath;
            }
            else
            {
                pathToAppend = absolutePath.Remove(absolutePath.Length - 1);
            }

            string baseUrl = url.Scheme + "://" + url.Host + pathToAppend;

            string payload = baseUrl + nonce;
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
        public static bool VerifySignature(string uri, string nonce, string xPlivoSignature, string authToken)
        {
            string computedSignature = ComputeSignature(uri, nonce, authToken);

            if (computedSignature == xPlivoSignature)
            {
                return true;
            }

            return false;
        }
    }
}