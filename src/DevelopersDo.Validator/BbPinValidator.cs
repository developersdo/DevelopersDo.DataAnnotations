using System;
using System.Globalization;

namespace DevelopersDo.Validator
{
    public class BbPinValidator : IValidator
    {
        public bool IsValid(object value)
        {
            var str = value as String;

            if (String.IsNullOrEmpty(str))
                return true;

            if (str.Length != 8)
                return false;

            uint bbpin;
            return UInt32.TryParse(str, NumberStyles.HexNumber, null, out bbpin);
        }
    }
}
