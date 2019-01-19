using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {
        [Test]
        public void Log_WhenCalled_ToSetTheLastErrorProperty()
        {
            var logger = new ErrorLogger();

            logger.Log("a");

            Assert.That(logger.LastError, Is.EqualTo("a"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string error)
        {
            var logger = new ErrorLogger();

            Assert.That(() => logger.Log(error), Throws.ArgumentNullException);

            //Assert.That(() => logger.Log(error), Throws.Exception.TypeOf<DivideByZeroException>)
        }

        [Test]
        public void Log_ValidError_RaiseErrorLoggedEvent()
        {
            //Arrange
            var logger = new ErrorLogger();

            var id = Guid.Empty;
            //Subscribe to the event handler (sender = source of the event, args = event arguments)
            //The lambda expression represents the event handler. When the event is raised the id will be assigned.
            logger.ErrorLogged += (sender, args) => { id = args; };

            //Act
            logger.Log("a");

            //Assert
            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}
