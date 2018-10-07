using System;
using BusinesLayer.Contracts;
using BusinesLayer.Models;

namespace BusinesLayer.Attributes 
{
    /// <summary>
    /// Used for specifying a range constraint
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class IntValueRangeAttribute : System.Attribute, IValidationAttribute
    {
        /// <summary>
        /// Gets the minimum value for the range
        /// </summary>
        public int Min { get; private set; }

        /// <summary>
        /// Gets the maximum value for the range
        /// </summary>
        public int Max { get; private set; }

        private readonly string _errorMessage;

        /// <summary>
        /// Constructor that takes int minimum and maximum values, property name
        /// </summary>
        /// <param name="min">The minimum value, inclusive</param>
        /// <param name="max">The maximum value, inclusive</param>
        /// <param name="propertyName">Name of property for validation</param>
        /// <exception cref="ArgumentException"> is thrown if the maximum value is less than minimum value.</exception>
        public IntValueRangeAttribute (int min, int max, string propertyName)
        {
            if (max < min)
            {
                throw new ArgumentException("Maximum can not be less that minimum");
            }

            Min = min;
            Max = max;
            _errorMessage = String.Format
           (
                "The value of the {0} property is not included between {1} and {2}",
                propertyName, Min, Max
            );
        }

        /// <summary>
        /// Constructor that takes int maximum value and property name
        /// </summary>
        /// <param name="max">The maximum value, inclusive</param>
        /// <param name="propertyName">Name of property for validation</param>
        public IntValueRangeAttribute(int max, string propertyName)
        {
            Max = max;
            _errorMessage = String.Format
            (
                "The value of the {0} property is more than {1}",
                propertyName, Max
            );
        }

        /// <summary>
        /// Returns true if the value falls between min and max, inclusive.
        /// </summary>
        /// <param name="value">The value to test for validity.</param>
        /// <returns><c>true</c> means the <paramref name="value"/> is valid</returns>
        /// <exception cref="ArgumentException"> is thrown if the current is not int.</exception>
        public ValidationModel IsValid(object value)
        {
            int? number = value as int?;

            if(number == null)
            {
                throw new ArgumentException("This Attribute is for int values");
            }

            if (number <= Min || number >= Max)
            {
                return new ValidationModel( ValidationResult.IntValueRangeError, _errorMessage);
            }

            return new ValidationModel(ValidationResult.Success);
        }
    }
}
