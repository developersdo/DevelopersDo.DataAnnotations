using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace DevelopersDo.DataAnnotations
{
    /// <summary>
    /// The <code>MSISDNAttribute</code> class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class MSISDNAttribute : ValidationAttribute
    {
        private static readonly String[] DefaultPrefixes = { "809", "829", "849" };
        private static readonly Regex MSISDNRegex = new Regex(@"(\d{3}\-\d{3}\-\d{4})|(\d{10})", RegexOptions.Compiled);

        public String[] Prefixes { get; set; }

        /// <summary>
        /// Determine if a string value is a valid Dominican phone number.
        /// </summary>
        /// <param name="value">The string to validate.</param>
        /// <returns><code>true</code> if the string value is a valid BlackBerry PIN number, otherwise <code>false</code>.</returns>
        public override bool IsValid(object value)
        {
            var str = value as String;
            
            if (String.IsNullOrEmpty(str))
                return true;

            if (MSISDNRegex.Matches(str).Count == 0)
                return false;

            str = new string(str.Where(Char.IsDigit).ToArray());
            return (Prefixes ?? DefaultPrefixes).Any(p => str.StartsWith(p));
        }
    }
}
