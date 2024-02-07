using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace _9.FacadePattern.Attributes
{
    public class FloatRangeAttribute : ValidationAttribute
    {
        private readonly float _minValue;
        private readonly float _maxValue;

        public FloatRangeAttribute(float minValue, float maxValue)
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

            float floatValue;
            if (!float.TryParse(value.ToString(), out floatValue))
            {
                return new ValidationResult($"The field {validationContext.DisplayName} must be a float.");
            }

            if (floatValue < _minValue || floatValue > _maxValue)
            {
                return new ValidationResult($"The field {validationContext.DisplayName} must be between {_minValue} and {_maxValue}.");
            }

            return ValidationResult.Success;
        }
    }
}
