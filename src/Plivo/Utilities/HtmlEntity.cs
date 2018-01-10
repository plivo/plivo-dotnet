using System.Text;

namespace Plivo.Utilities
{
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
}
