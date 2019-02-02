using NUnit.Framework;
using TestNinja.Mocking;
using Moq;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _VideoService;
        private Mock<IFileReader> _FileReader;

        [SetUp]
        public void Setup()
        {
            //Create the Mock object and inject it into the video service
            _FileReader = new Mock<IFileReader>();
            _VideoService = new VideoService(_FileReader.Object);
        }

        [Test]
        public void ReadVideoTitle_EmptyFile_ReturnError()
        {
            //Arrange
            _FileReader.Setup(fr => fr.Read("video.txt")).Returns("");

            //Act
            var result = _VideoService.ReadVideoTitle();
            
            //Assert
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }
    }
}
