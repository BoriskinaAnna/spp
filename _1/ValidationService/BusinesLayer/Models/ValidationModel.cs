using System;

namespace BusinesLayer.Models
{
    public class ValidationModel
    {
        public ValidationResult ValidationResult { get; }

        public string ErrorMessage { get; }


        public ValidationModel
        (
             ValidationResult validationResult,
             String errorMessage
        )
        {
            ValidationResult = validationResult;
            ErrorMessage = errorMessage;
        }

        public ValidationModel
        (
             ValidationResult validationResult
        )
        {
            ValidationResult = validationResult;
        }
    }
}
