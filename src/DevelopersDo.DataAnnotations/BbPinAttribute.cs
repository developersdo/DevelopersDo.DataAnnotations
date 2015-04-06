using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DevelopersDo.Validator;

namespace DevelopersDo.DataAnnotations
{
    /// <summary>
    /// The <code>BbPinAttribute</code> class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class BbPinAttribute : ValidationAttribute
    {
        private readonly IValidator _validator;
        public BbPinAttribute()
        {
            _validator = new BbPinValidator();
        }
        /// <summary>
        /// Determine if a string value is a valid BlackBerry PIN number.
        /// </summary>
        /// <param name="value">The string to validate.</param>
        /// <returns><code>true</code> if the string value is a valid BlackBerry PIN number, otherwise <code>false</code>.</returns>
        public override bool IsValid(object value)
        {
            return _validator.IsValid(value);
        }
    }
}
