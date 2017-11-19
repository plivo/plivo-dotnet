using System.Collections.Generic;

namespace Plivo.Utilities
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
}
