using System;
using System.ComponentModel.DataAnnotations;
using DevelopersDo.Validator;

namespace DevelopersDo.DataAnnotations
{
    /// <summary>
    /// The <code>CedulaAttribute</code> class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class CedulaAttribute : ValidationAttribute
    {
        
        private readonly IValidator _cedulaValidator = new CedulaValidator();
     
        /// <summary>
        /// Determines if a string value is a valid Cédula.
        /// </summary>
        /// <param name="value">The string to validate.</param>
        /// <returns><code>true</code> if the string value is a valid Cédula, otherwise <code>false</code>.</returns>
        public override bool IsValid(object value)
        {
            return _cedulaValidator.IsValid(value);
        }
    
    }
}
