using NUnit.Framework;
using Moq;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class OrderServiceTests
    {
        [Test]
        public void PlaceOrder_WhenCalled_StoreTheOrder()
        {
            //Inject the Mock into the order service
            var storage = new Mock<IStorage>();
            var service = new OrderService(storage.Object);

            //Place the order
            var order = new Order();
            service.PlaceOrder(order);

            //Verify the Storage Store method was called using the given order
            storage.Verify(s => s.Store(order));
        }
    }
}
