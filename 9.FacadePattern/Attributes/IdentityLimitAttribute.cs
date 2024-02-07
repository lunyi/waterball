using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace _9.FacadePattern.Attributes
{
    public class IdentityLimitAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            string strValue = value.ToString();

            // Regex pattern to match a capital letter followed by exactly 9 numbers
            string pattern = @"^[A-Z]\d{9}$";

            return Regex.IsMatch(strValue, pattern);
        }

        public override string FormatErrorMessage(string name)
        {
            return $"The {name} field must start with a capital letter followed by exactly 9 numbers.";
        }
    }
}
