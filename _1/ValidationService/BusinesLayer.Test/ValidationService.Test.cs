using System.Collections.Generic;
using BusinesLayer.Attributes;
using BusinesLayer.Models;
using BusinesLayer.Contracts;
using NUnit.Framework;
using ValidationService.Test.TestEntities;

namespace BusinesLayer.Test
{ 
    [TestFixture]
    class ValidationServiceTest
    {
        [Test]
        public void Correct_Object()
        {
            IValidationService<User> validationService = new ValidationService<User>();
            var actual = validationService.Validate(new User("asa", "2", 8));

            Assert.AreEqual(actual, new List<ValidationModel>());
        }

        [Test]
        public void Incorrect_Object_Property_Has_Required_Exception()
        {
            IValidationService<User> validationService = new ValidationService<User>();
            var actual = validationService.Validate(new User(null, "2", 8));

            Assert.AreEqual(actual[0].ValidationResult, ValidationResult.RequiredError);
            Assert.AreEqual(actual[0].ErrorMessage, "The value of the Obj property is required");
        }

        [Test]
        public void Incorrect_Object_Field_Has_String_Lenght_Exception()
        {
            IValidationService<User> validationService = new ValidationService<User>();
            var actual = validationService.Validate(new User("aas", "assssssss", 8));
            
            Assert.AreEqual(actual[0].ValidationResult, ValidationResult.StringLengthError);
            Assert.AreEqual(actual[0].ErrorMessage, "The length of the Str property is more than 2");
        }

        [Test]
        public void Incorrect_Object_Field_Has_Int_Range_Exception()
        {
            IValidationService<User> validationService = new ValidationService<User>();
            List<ValidationModel> actual = validationService.Validate(new User("aas", "s", 120));

            Assert.AreEqual(actual[0].ValidationResult, ValidationResult.IntValueRangeError);
            Assert.AreEqual(actual[0].ErrorMessage, "The value of the Num property is not included between 1 and 10");
        }
    }
}
