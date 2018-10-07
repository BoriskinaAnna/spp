using System;
using BusinesLayer.Attributes;
using BusinesLayer.Models;
using NUnit.Framework;

namespace BusinesLayer.Test
{
    [TestFixture]
    public class StringLengthAttributeTest
    {
        [Test]
        public void Strind_Length_Less_Than_3()
        {
            var validationService = new StringLengthAttribute(3, "test");
            var actual = validationService.IsValid("ds");

            Assert.AreEqual(actual.ValidationResult, ValidationResult.Success);
            Assert.AreEqual(actual.ErrorMessage, null);
        }

        [Test]
        public void Strind_Length_More_Than_3()
        {
            var validationService = new StringLengthAttribute(3, "test");
            var actual = validationService.IsValid("dsjhjh");

            Assert.AreEqual(actual.ValidationResult, ValidationResult.StringLengthError);
            Assert.AreEqual(actual.ErrorMessage, "The length of the test property is more than 3");
        }

        [Test]
        public void String_Is_Included_In_The_Interval()
        {
            var validationService = new StringLengthAttribute(3, 7, "test");
            var actual = validationService.IsValid("dsjhjh");

            Assert.AreEqual(actual.ValidationResult, ValidationResult.Success);
            Assert.AreEqual(actual.ErrorMessage, null);
        }

        [Test]
        public void String_Is_Not_Included_In_The_Interval()
        {
            var validationService = new StringLengthAttribute(3, 7, "test");
            var actual = validationService.IsValid("dsjhdlfgfdkjjdfjh");

            Assert.AreEqual(actual.ValidationResult, ValidationResult.StringLengthError);
            Assert.AreEqual(actual.ErrorMessage, "The length of the test property is not included between 3 and 7");
        }

        [Test]
        public void Param_Is_Not_String()
        {
            var validationService = new StringLengthAttribute(3, "test");
            Assert.Throws<ArgumentException>(() => validationService.IsValid(234));
        }

        [Test]
        public void Max_Value_Of_Range_Is_Less_Than_Min_Value_Of_Range()
        {
            Assert.Throws<ArgumentException>(() => new StringLengthAttribute(3, 2, "test"));
        }
    }
}
