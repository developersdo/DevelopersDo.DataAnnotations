using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Mariuzzo.DO.Validator;

namespace Mariuzzo.DO.DataAnnotations
{
    /// <summary>
    /// The <code>CedulaAttribute</code> class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class CedulaAttribute : ValidationAttribute
    {
        
        private readonly IValidator _cedulaValidator = new CedulaValidator();
        /// <summary>
        /// Verify some exceptions of valid Cédula that don't follow the Luhn Algorithm
        /// </summary>
        public bool IgnoreExceptions = true;
        /// <summary>
        /// Determines if a string value is a valid Cédula.
        /// </summary>
        /// <param name="value">The string to validate.</param>
        /// <returns><code>true</code> if the string value is a valid Cédula, otherwise <code>false</code>.</returns>
        public override bool IsValid(object value)
        {
            var str = value as String;
            return String.IsNullOrEmpty(str) || (!IgnoreExceptions && _validExceptions.Contains(str)) || _cedulaValidator.IsValid(value);
        }
        #region Cédulas that do not fill the criteria of the algorithm
        private readonly string[] _validExceptions =
        {
            "03121982479",
            "40200401324",
            "40200700675",
            "01400074875",
            "01400000282",
            "01200004166",
            "00800106971",
            "00500146023",
            "03600005006",
            "00200123640",
            "00200066461",
            "00111685651",
            "00109802472",
            "00114532330",
            "00414198021",
            "02500017580",
            "02800004558",
            "03200066940",
            "03103749672",
            "90001200901",
            "03200033116",
            "03300222958",
            "09700061422",
            "03800032522",
            "03900192284",
            "00301200901",
            "04700160012",
            "04400030228",
            "03401548588",
            "04600176999",
            "04700382339",
            "04700502946",
            "04900026260",
            "05300049899",
            "05900072869",
            "07100144181",
            "07600106353",
            "07700009346",
            "00100759932",
            "00103098181",
            "00211870608",
            "10000063683",
            "00200409772",
            "00108436337",
            "00105278289",
            "00105606543",
            "00103022479",
            "00114272360",
            "12345678912",
            "00121581800",
            "00119161853",
            "00121581750",
            "10621581792",
            "09421581768",
            "22321581834",
            "22721581818"
        };
        #endregion
    }
}
