using System;
using System.ComponentModel.DataAnnotations;
using Mariuzzo.DO.Validator;

namespace Mariuzzo.DO.DataAnnotations
{
    /// <summary>
    /// The <code>RNCAttribute</code> class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class RNCAttribute : ValidationAttribute
    {
        private readonly IValidator _rncValidator = new RNCValidator();

        /// <summary>
        /// Determines if a string value is a valid RNC.
        /// </summary>
        /// <param name="value">The string to validate.</param>
        /// <returns><code>true</code> if the string value is a valid RNC, otherwise <code>false</code>.</returns>
        public override bool IsValid(object value)
        {
            return _rncValidator.IsValid(value);
        }
    }
}
