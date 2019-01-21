using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [Test]
        public void GetOutput_InputIsDivisibleBy3And5_ReturnFizzBuzz()
        {
            //Act
            var result = FizzBuzz.GetOutput(15);

            //Assert
            Assert.That(result, Is.EqualTo("FizzBuzz"));
        }

        [Test]
        public void GetOutput_InputIsDivisibleBy3Only_ReturnFizz()
        {
            //Act
            var result = FizzBuzz.GetOutput(3);

            //Assert
            Assert.That(result, Is.EqualTo("Fizz"));
        }

        [Test]
        public void GetOutput_InputIsDivisibleBy5Only_ReturnBuzz()
        {
            //Act
            var result = FizzBuzz.GetOutput(5);

            //Assert
            Assert.That(result, Is.EqualTo("Buzz"));
        }

        [Test]
        public void GetOutput_InputIsNotDivisibleBy3Or5_ReturnTheSameNumber()
        {
            //Act
            var result = FizzBuzz.GetOutput(1);

            //Assert
            Assert.That(result, Is.EqualTo("1"));
        }
    }
}
