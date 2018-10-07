using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BusinesLayer.Contracts;
using BusinesLayer.Models;
using NLog;

namespace BusinesLayer
{
    /// <summary>
    /// Class that implements functionality of validation service
    /// </summary>
    /// <typeparam name="T">Type of object that should be validate</typeparam>
    public class ValidationService<T> : IValidationService<T> where T : class
    {
        private readonly ILogger _logger;


        /// <summary>
        /// Standart .ctor of <see cref="ValidationService{T}"/> class
        /// </summary>
        public ValidationService ()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public ValidationService(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentException($"Any {nameof(logger)} did not find");
        }

        /// <summary>
        /// Public method for object validation
        /// </summary>
        /// <param name="obj">Object needed to be validated</param>
        /// <returns><see cref="ValidationResult"/> object that represent the result of validation</returns>
        /// <exception cref="ValidationModel">Throws when <param name="value"></param> is equal to null</exception>
        public List<ValidationModel> Validate(T obj)
        {
            List<ValidationModel> errors = new List<ValidationModel>();

            IList<PropertyInfo> properties = obj.GetType().GetProperties
            (
                BindingFlags.Public
                | BindingFlags.NonPublic
                | BindingFlags.Instance
                | BindingFlags.Static
            );

            foreach (PropertyInfo property in properties)
            {
                IList<Attribute> attributes = property.GetCustomAttributes().ToList();
               
                foreach (Attribute attribute in attributes)
                {
                    IValidationAttribute customAttribute = 
                        attribute as IValidationAttribute;

                    if (customAttribute != null)
                    {
                        ValidationModel result =
                            customAttribute.IsValid(property.GetValue(obj));

                        if (result.ValidationResult != ValidationResult.Success)
                        {
                            errors.Add(new ValidationModel(
                                result.ValidationResult,
                                result.ErrorMessage
                            ));
                            _logger.Warn(result.ErrorMessage);
                        }
                    }
                }
            }
            return errors;
        }
    }
}
