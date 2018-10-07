using BusinesLayer.Attributes;
using BusinesLayer.Contracts;
using Moq;
using NLog;
using NUnit.Framework;
using ValidationService.Test.TestEntities;

namespace BusinesLayer.Test
{ 
    [TestFixture]
    class LoggerTest
    {
        [Test]
        public void Test_Logger()
        {
            var loggerMock = new Mock<ILogger>();
            var user = new User("Nastya", "qwerty", 5);
            IValidationService<User> validationService = new ValidationService<User>(loggerMock.Object);
            var validationResult = validationService.Validate(user);
            loggerMock.Setup(x => x.Warn(It.IsAny<string>()));
            loggerMock.Verify(x => x.Warn(It.IsAny<string>()), Times.Exactly(1));
        }
    }
}