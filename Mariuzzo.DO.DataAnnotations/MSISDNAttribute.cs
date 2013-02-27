using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace Mariuzzo.DO.DataAnnotations
{
    /// <summary>
    /// The <code>MSISDNAttribute</code> class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class MSISDNAttribute : ValidationAttribute
    {
        private readonly String[] _defaultPrefixes = { "809", "829", "849" };

        public String[] Prefixes { get; set; }

        /// <summary>
        /// Determine if a string value is a valid Dominican phone number.
        /// </summary>
        /// <param name="value">The string to validate.</param>
        /// <returns><code>true</code> if the string value is a valid BlackBerry PIN number, otherwise <code>false</code>.</returns>
        public override bool IsValid(object value)
        {
            var str = value as String;
            if (str == null)
            {
                return true;
            }

            if (String.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            Regex regex = new Regex(@"(\d{3}\-\d{3}\-\d{4})|(\d{10})");
            if (regex.Matches(str).Count == 0)
            {
                return false;
            }

            str = new string(str.Where(Char.IsDigit).ToArray());
            return (Prefixes ?? _defaultPrefixes).Any(p => str.StartsWith(p));
        }
    }
}
