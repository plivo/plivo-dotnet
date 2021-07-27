using System.Collections.Generic;
using System.Linq;
using System;
using System.Text.RegularExpressions;

using Plivo.Exception;

namespace Plivo.Utilities
{
    public class MpcUtils
    {
        public static void ValidSubAccount(string accountId)
        {
            if (accountId.Length != 20)
            {
                throw new PlivoValidationException("Subaccount Id should be of length 20");
            }
            if (accountId.Substring(0, 2) != "SA")
            {
                Console.WriteLine(accountId.Substring(0, 3));
                throw new PlivoValidationException("Subaccount Id should start with 'SA' ");
            }
        }

        public static bool ValidMultipleDestinationNos(string paramName, string paramValue, string role, char delimiter, int limit)
        {
            if (paramValue.Split(delimiter).Count() > 1 && role.ToLower() != "agent")
            {
                throw new PlivoValidationException("Multiple " + paramName + " values given for role " + role);
            }
            else if (paramValue.Split(delimiter).Count() >= limit)
            {
                throw new PlivoValidationException("No of " + paramName + " values provided should be lesser than " +
                                                   Convert.ToString(limit));
            }
            else
            {
                return true;
            }
        }

        public static bool ValidMultipleDestinationIntegers(string paramName, string paramValue)
        {
            string[] values = paramValue.Split('<');
            int n;
            for (int i=0;i<values.Length;i++)
            {
                if (!(int.TryParse(values[i], out n)))
                {
                    throw new PlivoValidationException(paramName + "Destination Values must be of type int");
                }
            }
            return true;
        }

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
        
        public static bool ValidParamInt(string paramName, uint? paramValue = null, bool mandatory = false, List<uint?> expectedValues = null)
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

        public static bool MultiValidParam(string paramName, string paramValue,bool mandatory = false, bool makeLowerCase = false, List<string> expectedValues = null, char separator = ',')
        {
            if (mandatory && paramValue == null)
            {
                throw new PlivoValidationException(paramName + " is a required parameter");
            }
            if (paramValue == null)
            {
                return true;
            }
            if (makeLowerCase)
            {
                paramValue = paramValue.ToLower();
            }
            else
            {
                paramValue = paramValue.ToUpper();
            }
            string[] values = paramValue.Split(separator);
            foreach (string value in values)
            {
                if (!expectedValues.Contains(value.Trim()))
                {
                    throw new PlivoValidationException(paramName + ": Expected one of " + string.Join(" ", expectedValues) + " but received " + value + " instead");
                }
            }
            return true;
        }

        public static bool ValidUrl(string paramName, string paramValue, bool mandatory = false)
        {
            if (mandatory && paramValue == null)
            {
                throw new PlivoValidationException(paramName + " is a required parameter");
            }
            if (paramValue == null)
            {
                return true;
            }
            string Pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            Regex rgx = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (!rgx.IsMatch(paramValue))
            {
                throw new PlivoValidationException("Invalid URL : Doesn't satisfy the URL format");
            }
            else
            {
                return true;
            }
        }

        public static bool IsOneAmongStringUrl(string paramName, string paramValue, bool mandatory = false,
            List<string> expectedValues = null)
        {
            if (mandatory && paramValue == null)
            {
                throw new PlivoValidationException(paramName + " is a required parameter");
            }
            if (paramValue == null)
            {
                return true;
            }
            if (expectedValues.Contains(paramValue.ToLower()) || expectedValues.Contains(paramValue.ToUpper()))
            {
                return true;
            }
            else if(ValidUrl(paramName, paramValue))
            {
                return true;
            }
            else
            {
                throw new PlivoValidationException(paramName + " neither a valid URL nor in the expected values");
            }
        }

        public static bool ValidDateFormat(string paramName, string paramValue, bool mandatory = false)
        {
            if (mandatory && paramValue == null)
            {
                throw new PlivoValidationException(paramName + " is a required parameter");
            }
            if (paramValue == null)
            {
                return true;
            }
            string Pattern = @"^(\d{4}\-\d{2}\-\d{2}\ \d{2}\:\d{2}(\:\d{2}(\.\d{1,6})?)?)$";
            Regex rgx = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            if (!rgx.IsMatch(paramValue))
            {
                throw new PlivoValidationException("Invalid Datetime : Doesn't satisfy the datetime format");
            }
            else
            {
                return true;
            }
        }

        public static bool ValidRange(string paramName, uint? paramValue, bool mandatory = false, uint? lowerBound = null, uint? upperBound = null)
        {
            if (mandatory && paramValue == null)
            {
                throw new PlivoValidationException(paramName + " is a required parameter");
            }
            if (paramValue == null)
            {
                return true;
            }
            if (lowerBound != null && upperBound != null)
            {
                if (paramValue < lowerBound || paramValue > upperBound)
                {
                    throw new PlivoValidationException(paramName + " ranges between " + Convert.ToString(lowerBound) + " and " + Convert.ToString(upperBound));
                }

                if (paramValue >= lowerBound && paramValue <= upperBound)
                {
                    return true;
                }
            }
            else if(lowerBound != null)
            {
                if (paramValue < lowerBound)
                {
                    throw new PlivoValidationException(paramName + " should be greater than " +
                                                       Convert.ToString(lowerBound));
                }

                if (paramValue >= lowerBound)
                {
                    return true;
                }
            }
            else if(upperBound != null)
            {
                if (paramValue > upperBound)
                {
                    throw new PlivoValidationException(paramName + " should be lesser than " +
                                                       Convert.ToString(upperBound));
                }

                if (paramValue <= upperBound)
                {
                    return true;
                }
            }
            else
            {
                throw new PlivoValidationException("Any one or both of lower and upper bound should be provided");
            }
            return true;
        }
    }
}