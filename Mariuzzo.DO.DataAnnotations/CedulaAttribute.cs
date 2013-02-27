using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Mariuzzo.DO.DataAnnotations
{
    /// <summary>
    /// The <code>CedulaAttribute</code> class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class CedulaAttribute : ValidationAttribute
    {
        /// <summary>
        /// Determines if a string value is a valid Cédula.
        /// </summary>
        /// <param name="value">The string to validate.</param>
        /// <returns><code>true</code> if the string value is a valid Cédula, otherwise <code>false</code>.</returns>
        public override bool IsValid(object value)
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
