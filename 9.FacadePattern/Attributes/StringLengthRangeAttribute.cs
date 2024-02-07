using System.ComponentModel.DataAnnotations;

namespace _9.FacadePattern.Attributes
{
    public class StringLengthRangeAttribute : ValidationAttribute
    {
        private readonly int _minLength;
        private readonly int _maxLength;

        public StringLengthRangeAttribute(int minLength, int maxLength)
        {
            _minLength = minLength;
            _maxLength = maxLength;
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true; // Null values are considered valid
            }

            string strValue = value.ToString();
            int length = strValue.Length;

            return length >= _minLength && length <= _maxLength;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"The field {name} must be a string with a length between {_minLength} and {_maxLength} characters.";
        }
    }
}
