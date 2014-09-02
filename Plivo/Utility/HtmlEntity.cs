using System.Text;

namespace Plivo.Utility
{
   public class HtmlEntity {
        public static string Convert(string inputText) {
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