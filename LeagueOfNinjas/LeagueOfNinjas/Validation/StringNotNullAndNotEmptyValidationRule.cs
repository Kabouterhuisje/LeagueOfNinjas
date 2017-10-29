using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LeagueOfNinjas.Validation
{
    public class StringNotNullAndNotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return new ValidationResult(!String.IsNullOrEmpty(value.ToString()), "This field can not be empty.");
        }
    }
}
