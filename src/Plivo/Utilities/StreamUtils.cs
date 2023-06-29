using System.Collections.Generic;
using Plivo.Exception;

namespace Plivo.Utilities
{
    public class StreamUtils
    {
        public static bool ValidParamString(string paramName, string paramValue = null, bool mandatory = false, List<string> expectedValues = null)
        {
            if (mandatory && paramValue == null)
            {
                throw new PlivoValidationException(paramName + " is a required parameter");
            }
            if (paramValue == null)
            {
                return true;
            }
            if (expectedValues == null)
            {
                return true;
            }
            if (!expectedValues.Contains(paramValue))
            {
                throw new PlivoValidationException(paramName + ": Expected one of " + string.Join(" ", expectedValues) + " but received " + paramValue + " instead");
            }
            return true;
        }
    }
}