using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests.Fundamentals
{
    [TestFixture]
    public class ReservationTests
    {
        [Test]
        public void CanBeCancelledBy_AdminCancelling_ReturnsTrue()
        {
            //Arrange
            var reservation = new Reservation();

            //Act
            var result = reservation.CanBeCancelled(new User { IsAdmin = true });

            //Asset
            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_SameUserCancelling_ReturnsTrue()
        {
            //Arrange
            var user = new User();
            var reservation = new Reservation() { MadeBy = user };

            //Act
            var result = reservation.CanBeCancelled(user);

            //Asset
            Assert.IsTrue(result);
        }

        [Test]
        public void CanBeCancelledBy_AnotherUserCancelling_ReturnsFalse()
        {
            //Arrange
            var reservation = new Reservation() { MadeBy = new User() };

            //Act
            var result = reservation.CanBeCancelled(new User { IsAdmin = false });

            //Asset
            Assert.IsFalse(result);
        }
    }
}
