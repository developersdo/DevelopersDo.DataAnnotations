using System;
using System.Text.RegularExpressions;

namespace DevelopersDo.Validator
{
    public class RNCValidator : IValidator
    {
        public bool IsValid(object value)
        {
            var str = value as String;
            if (String.IsNullOrEmpty(str))
            {
                return true;
            }

            var regex = new Regex(@"^(1|4|5)-?[0-9]{2}-?[0-9]{5}-?[0-9]{1}$");
            if (!regex.IsMatch(str))
            {
                return false;
            }

            str = Regex.Replace(str, @"[^\d]", String.Empty);

            // Do check digit.
            return CheckDigit(str);
        }

        private bool CheckDigit(string str)
        {
            var baseDigs = new int[] { 7, 9, 8, 6, 5, 4, 3, 2 };
            int result = 0;
            int digit = 0;

            for (int i = 0; i < 8; i++)
                result += baseDigs[i] * (int)Char.GetNumericValue(str[i]);

            result = result % 11;

            if (result == 0)
                digit = 2;
            else if (result == 1)
                digit = 1;
            else
                digit = 11 - result;

            return digit == (int)Char.GetNumericValue(str[8]);
        }
    }
}