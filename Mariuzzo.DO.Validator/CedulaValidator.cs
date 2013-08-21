using System;
using System.Text.RegularExpressions;

namespace Mariuzzo.DO.Validator
{
    public class CedulaValidator: IValidator
    {
        public bool IsValid(object value)
        {
            var str = value as String;
            if (String.IsNullOrEmpty(str))
            {
                return true;
            }

            var regex = new Regex(@"^[0-9]{3}-?[0-9]{7}-?[0-9]{1}$");
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
            int sum = 0;
            for (int i = 0; i < 10; ++i)
            {
                int n = ((i + 1) % 2 != 0 ? 1 : 2) * (int)Char.GetNumericValue(str[i]);
                sum += (n <= 9 ? n : n % 10 + 1);
            }
            int dig = ((10 - sum % 10) % 10);

            return dig == (int)Char.GetNumericValue(str[10]);
        }
    }
}