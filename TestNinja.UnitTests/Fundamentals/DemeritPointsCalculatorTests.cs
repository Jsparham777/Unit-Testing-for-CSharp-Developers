using NUnit.Framework;
using System;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    public class DemeritPointsCalculatorTests
    {
        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIsOutOfRange_ThrowsArgumentOutOfRangeException(int speed)
        {
            //Arrange
            var calculator = new DemeritPointsCalculator();

            //Assert
            Assert.That(() => calculator.CalculateDemeritPoints(speed), 
                Throws.Exception.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(64, 0)]
        [TestCase(65, 0)]
        [TestCase(66, 0)]
        [TestCase(70, 1)]
        [TestCase(75, 2)]
        public void CalculateDemeritPoints_WhenCalled_ReturnDemeritPoints(int speed, int expectedResult)
        {
            //Arrange
            var calculator = new DemeritPointsCalculator();

            //Act
            var points = calculator.CalculateDemeritPoints(speed);

            //Assert
            Assert.That(points, Is.EqualTo(expectedResult));
        }
    }
}
