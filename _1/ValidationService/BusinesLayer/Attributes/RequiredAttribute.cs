using System;
using BusinesLayer.Contracts;
using BusinesLayer.Models;

namespace BusinesLayer.Attributes
{
    /// <summary>
    /// Validation attribute to indicate a property that a property value is required.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class RequiredAttribute : System.Attribute, IValidationAttribute
    {
        /// <summary>
        /// Gets or sets a flag indicating whether the attribute should allow empty strings.
        /// </summary>
        public bool AllowEmptyStrings { get; set; }

        private readonly string _errorMessage;


        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="propertyName">Name of property for validation</param>
        public RequiredAttribute (string propertyName)
        {
            _errorMessage = String.Format
           (
               "The value of the {0} property is required",
               propertyName
           );
        }

        /// <summary>
        /// Override of <see cref="ValidationAttribute.IsValid(object)"/>
        /// </summary>
        /// <param name="value">The value to test</param>
        /// <returns><c>false</c> if the <paramref name="value"/> is null or an empty string. If <see cref="RequiredAttribute.AllowEmptyStrings"/>
        /// then <c>false</c> is returned only if <paramref name="vale"/> is null.</returns>
        public ValidationModel IsValid(object value)
        {
            if (value == null)
            {
                return new ValidationModel(ValidationResult.RequiredError, _errorMessage);
            }

            var stringValue = value as string;

            if (stringValue != null && !AllowEmptyStrings)
            {
                if(stringValue.Trim().Length != 0)
                {
                    return new ValidationModel(ValidationResult.Success);
                }
                return new ValidationModel(ValidationResult.RequiredError, _errorMessage);
            }

            return new ValidationModel(ValidationResult.Success);
        }
    }
}
