/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2018 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Dev2.Common.ExtMethods
{
    public static class StringExtension
    {
        static readonly Regex IsAlphaRegex = new Regex("^[a-zA-Z ]*$", RegexOptions.Compiled);
        static readonly Regex IsAlphaNumericRegex = new Regex("^[0-9a-zA-Z]*$", RegexOptions.Compiled);

        static readonly Regex IsEmailRegex = new Regex(@"\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        static readonly Regex IsBinaryField = new Regex("^[01]+$");
        static readonly Regex IsHex1 = new Regex(@"\A\b[0-9a-fA-F]+\b\Z");
        static readonly Regex IsHex2 = new Regex(@"\A\b(0[xX])?[0-9a-fA-F]+\b\Z");

        public static bool ContainsUnicodeCharacter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return false;
            }
            const int maxAnsiCode = 255;
            return input.Any(c => c > maxAnsiCode);
        }
        
        public static bool IsAlpha(this string payload)
        {
            if (string.IsNullOrEmpty(payload))
            {
                return false;
            }

            var result = IsAlphaRegex.IsMatch(payload);

            return result;
        }

        public static bool IsWholeNumber(this string payload) => IsWholeNumber(payload, out int value);

        public static bool IsWholeNumber(this string payload, out int value) => int.TryParse(payload, out value) && value >= 0;
        public static bool IsRealNumber(this string payload, out int value) => int.TryParse(payload, out value);

        public static bool IsNumeric(this string payload) => IsNumeric(payload, out decimal value);

        public static bool IsNumeric(this string payload, out decimal value)
        {
            if (string.IsNullOrEmpty(payload))
            {
                value = 0;
                return false;
            }

            var evalString = payload;

            if (payload[0] == '-')
            {
                evalString = payload.Substring(1, payload.Length - 1);
            }

            var current = CultureInfo.CurrentCulture.NumberFormat;
            if (evalString.Any(c => !char.IsDigit(c)
                                    && c != current.NumberDecimalSeparator[0]))
            {
                value = 0;
                return false;
            }

            return decimal.TryParse(payload, out value);
        }

        public static bool IsAlphaNumeric(this string payload) => !string.IsNullOrEmpty(payload) &&
                   (IsAlpha(payload) || IsNumeric(payload) || IsAlphaNumericRegex.IsMatch(payload));

        public static bool IsEmail(this string payload)
        {
            if (string.IsNullOrEmpty(payload))
            {
                return false;
            }

            var result = IsEmailRegex.IsMatch(payload);

            return result;
        }

        public static bool IsBinary(this string payload) => IsBinaryField.IsMatch(payload);

        public static bool IsBase64(this string payload)
        {
            var result = false;
            try
            {                
                Convert.FromBase64String(payload);                
                result = true;
            }            
            catch (Exception)            
            {
                // if error is thrown we know it is not a valid base64 string
            }

            return result;
        }
        
        public static bool IsHex(this string payload)
        {
            var result = IsHex1.IsMatch(payload) || IsHex2.IsMatch(payload);

            if (payload.Length % 2 != 0)
            {
                result = false;
            }
            return result;
        }
        
        public static string ReverseString(this string s)
        {
            var arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
        
        public static string TryAddKeyboardAccellerator(this string input)
        {
            const string Accellerator = "_";            
            if (input.Contains(Accellerator))
            {
                return input;
            }
            return Accellerator + input;
        }
    
        public static string RemoveWhiteSpace(this string value)
        {
            var cleanString = new StringBuilder(value.Trim()).Replace(" ", "");
            return cleanString.ToString();
        }
    }
}