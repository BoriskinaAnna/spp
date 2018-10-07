using System;
using BusinesLayer.Contracts;
using BusinesLayer.Models;

namespace BusinesLayer.Attributes
{
    /// <summary>
    /// Validation attribute to assert a string property,
    /// field or parameter does not exceed a maximum length
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class StringLengthAttribute : System.Attribute, IValidationAttribute
    {
        /// <summary>
        /// Gets the maximum acceptable length of the string
        /// </summary>
        public int MaximumLength { get; set; }

        /// <summary>
        /// Gets or sets the minimum acceptable length of the string
        /// </summary>
        public int MinimumLength { get; set; }

        private readonly string _errorMessage;


        /// <summary>
        /// Constructor that accepts the maximum length of the string and property name.
        /// </summary>
        /// <param name="maximumLength">The maximum length, inclusive.
        /// It may not be negative.</param>
        /// <param name="propertyName">Name of property for validation</param>
        /// /// <exception cref="ArgumentException"> is thrown if the maximum length is
        /// less or equals to 0.</exception>
        public StringLengthAttribute(int maximumLength, string propertyName)
        {
            if (maximumLength <= 0)
            {
                throw new ArgumentOutOfRangeException
                (
                    "Maximum length can not be less or equal to 0"
                );
            }

            MaximumLength = maximumLength;

            _errorMessage = String.Format
            (
                "The length of the {0} property is more than {1}",
                propertyName,
                MaximumLength
            );
        }

        /// <summary>
        /// Constructor that accepts the maximum length of the string and property name.
        /// </summary>
        /// <param name="minimumLength">The minimum length, inclusive.  It may not be more than maximum lenght.</param>
        /// <param name="maximumLength">The maximum length, inclusive.  It may not be negative.</param>
        /// <param name="propertyName">Name of property for validation</param>
        /// <exception cref="ArgumentException"> is thrown if the maximum length is less or equals to 0
        /// or if the maximum length is less than minimum length.</exception>
        public StringLengthAttribute(int minimumLength , int maximumLength, string propertyName)
        {
            if (maximumLength < 0)
            {
                throw new ArgumentOutOfRangeException("Maximum length can not be less or equal to 0");
            }

            if (maximumLength < minimumLength)
            {
                throw new ArgumentException("Maximum length can not be less that minimum length");
            }

            MaximumLength = maximumLength;
            MinimumLength = minimumLength;

            _errorMessage = String.Format
            (
                "The length of the {0} property is not included between {1} and {2}",
                propertyName,
                MinimumLength,
                MaximumLength
            );
        }

        /// <summary>
        /// Override of <see cref="ValidationAttribute.IsValid(object)"/>
        /// </summary>
        /// <remarks>This method returns <c>true</c> if the <paramref name="value"/> is null.  
        /// It is assumed the <see cref="RequiredAttribute"/> is used if the value may not be null.</remarks>
        /// <param name="value">The value to test.</param>
        /// <returns><c>true</c> if the value is null or less than or equal to the set maximum length</returns>
        /// <exception cref="ArgumentException"> is thrown if the current attribute is not string.</exception>
        public ValidationModel IsValid(object value)
        {
            string str = value as string;

            if (str == null)
            {
                throw new ArgumentException("This attribute is for strings");
            }

            if (value == null || (str.Length >= this.MinimumLength && str.Length <= this.MaximumLength))
            {
                return new ValidationModel(ValidationResult.Success);
            }
            
            return new ValidationModel(ValidationResult.StringLengthError, _errorMessage);
        }
    }
}

