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

            Regex regex = new Regex(@"(\d{3}\-\d{7}\-\d{1})|(\d{11})");
            if (regex.Matches(str).Count == 0)
            {
                return false;
            }

            str = Regex.Replace(str, @"[^\d]", String.Empty);

            // Do check digit.
            int sum = 0;
            for (int i = 0; i < 10; ++i)
            {
                int n = ((i + 1) % 2 != 0 ? 1 : 2) * int.Parse(str.Substring(i, 1));
                sum += (n <= 9 ? n : n % 10 + 1);
            }
            int dig = ((10 - sum % 10) % 10);

            return dig.Equals(int.Parse(str.Substring(10, 1)));
        }
    }
}