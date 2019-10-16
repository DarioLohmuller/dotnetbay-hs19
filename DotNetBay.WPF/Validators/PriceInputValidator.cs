using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DotNetBay.WPF.Validators
{
    class PriceInputValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Regex regex = new Regex("[^0-9]+");
            try
            {
                bool isMatch = regex.IsMatch((string)value);
                if(isMatch) return ValidationResult.ValidResult;
            }
            catch (ArgumentNullException e)
            {
                return new ValidationResult(false, "Value must not be null.");
            }
            return new ValidationResult(false, "Value has to be a numeric value.");
        }
    }
}
