using System;
using System.Text.RegularExpressions;

namespace DevelopersDo.Validator
{
    public class RNCValidator : IValidator
    {
        private static readonly Regex RncRegex = new Regex(@"^(1|4|5)-?[0-9]{2}-?[0-9]{5}-?[0-9]{1}$", RegexOptions.Compiled);
        private static readonly Regex NonDigitRegex = new Regex(@"[^\d]", RegexOptions.Compiled);
        private static readonly int[] BaseDigits = { 7, 9, 8, 6, 5, 4, 3, 2 };

        public bool IsValid(object value)
        {
            var str = value as String;
            
            if (String.IsNullOrEmpty(str))
                return true;

            if (!RncRegex.IsMatch(str))
                return false;

            str = NonDigitRegex.Replace(str, String.Empty);

            // Do check digit algorithm.
            return CheckDigit(str);
        }

        private static bool CheckDigit(string str)
        {
            var result = 0;
            int digit;

            for (var i = 0; i < 8; i++)
                result += BaseDigits[i] * (int)Char.GetNumericValue(str[i]);

            result = result % 11;

            switch (result)
            {
                case 0:
                    digit = 2;
                    break;
                case 1:
                    digit = 1;
                    break;
                default:
                    digit = 11 - result;
                    break;
            }

            return digit == (int)Char.GetNumericValue(str[8]);
        }
    }
}