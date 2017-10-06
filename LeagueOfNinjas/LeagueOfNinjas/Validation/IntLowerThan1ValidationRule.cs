using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PROG5_LeagueOfNinjas.Validation
{
    public class IntLowerThan1ValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                return new ValidationResult(int.Parse(value.ToString()) >= 1, "This should be above 0.");
            }
            catch (Exception)
            {
                return new ValidationResult(false, "This is not a valid number.");
            }
        }
    }
}
