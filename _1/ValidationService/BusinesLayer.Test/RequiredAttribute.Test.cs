using BusinesLayer.Attributes;
using NUnit.Framework;
using BusinesLayer.Models;

namespace BusinesLayer.Test
{
    [TestFixture]
    class RequiredAttributeTest
    {
        [Test]
        public void Empty_String()
        {
            var validationService = new RequiredAttribute("test");
            var actual = validationService.IsValid("");

            Assert.AreEqual(actual.ValidationResult, ValidationResult.RequiredError);
            Assert.AreEqual(actual.ErrorMessage, "The value of the test property is required");
        }

        [Test]
        public void Filled_Strind()
        {
            var validationService = new RequiredAttribute("test");
            var actual = validationService.IsValid("dsjhjh");

            Assert.AreEqual(actual.ValidationResult, ValidationResult.Success);
            Assert.AreEqual(actual.ErrorMessage, null);
        }

        [Test]
        public void Null_Parameter()
        {
            var validationService = new RequiredAttribute("test");
            var actual = validationService.IsValid(null);

            Assert.AreEqual(actual.ValidationResult, ValidationResult.RequiredError);
            Assert.AreEqual(actual.ErrorMessage, "The value of the test property is required");
        }

        [Test]
        public void Int_Value()
        {
            var validationService = new RequiredAttribute("test");
            var actual = validationService.IsValid(234);

            Assert.AreEqual(actual.ValidationResult, ValidationResult.Success);
            Assert.AreEqual(actual.ErrorMessage, null);
        }
    }
}
