using System;
using BusinesLayer.Attributes;
using NUnit.Framework;
using BusinesLayer.Models;

namespace BusinesLayer.Test
{
    [TestFixture]
    class IntRangeAttribute
    {
        [Test]
        public void Value_Less_Than_3()
        {
            var validationService = new IntValueRangeAttribute(3, "hello");
            var actual = validationService.IsValid(2);

            Assert.AreEqual(actual.ValidationResult, ValidationResult.Success);
            Assert.AreEqual(actual.ErrorMessage, null);
        }

        [Test]
        public void Value_More_Than_3()
        {
            var validationService = new IntValueRangeAttribute(3, "hello");
            var actual = validationService.IsValid(6);

            Assert.AreEqual(actual.ValidationResult, ValidationResult.IntValueRangeError);
            Assert.AreEqual(actual.ErrorMessage, "The value of the hello property is more than 3");
        }

        [Test]
        public void Value_Is_Included_In_The_Interval()
        {
            var validationService = new IntValueRangeAttribute(3, 7, "hello");
            var actual = validationService.IsValid(5);

            Assert.AreEqual(actual.ValidationResult, ValidationResult.Success);
            Assert.AreEqual(actual.ErrorMessage, null);
        }

        [Test]
        public void Value_Is_Not_Included_In_The_Interval()
        {
            var validationService = new IntValueRangeAttribute(3, 7, "hello");
            var actual = validationService.IsValid(9);

            Assert.AreEqual(actual.ValidationResult, ValidationResult.IntValueRangeError);
            Assert.AreEqual(actual.ErrorMessage, "The value of the hello property is not included between 3 and 7");
        }

        [Test]
        public void Param_Is_Not_Int()
        {
            var validationService = new IntValueRangeAttribute(3, "hello");
            Assert.Throws<ArgumentException>(() => validationService.IsValid("sdsd"));
        }

        [Test]
        public void Max_Value_Of_Range_Is_Less_Than_Min_Value_Of_Range()
        {
            Assert.Throws<ArgumentException>(() => new IntValueRangeAttribute(3, 2, "hello"));
        }
    }
}
