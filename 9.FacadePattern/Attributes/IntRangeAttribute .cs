using System.ComponentModel.DataAnnotations;

namespace _9.FacadePattern.Attributes
{
    public class IntRangeAttribute : ValidationAttribute
    {
        private readonly int _minValue;
        private readonly int _maxValue;

        public IntRangeAttribute(int minValue, int maxValue)
        {
            _minValue = minValue;
            _maxValue = maxValue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success; // Null values are considered valid
            }

            int intValue;
            if (!int.TryParse(value.ToString(), out intValue))
            {
                return new ValidationResult($"The field {validationContext.DisplayName} must be an integer.");
            }

            if (intValue < _minValue || intValue > _maxValue)
            {
                return new ValidationResult($"The field {validationContext.DisplayName} must be between {_minValue} and {_maxValue}.");
            }

            return ValidationResult.Success;
        }
    }

}
