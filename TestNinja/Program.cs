using TestNinja.Mocking;

namespace TestNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new VideoService();
            var title = service.ReadVideoTitle(new FileReader());

            //Instead of newing up the objects here, use a dependency injection framework (NInject)
        }
    }
}
