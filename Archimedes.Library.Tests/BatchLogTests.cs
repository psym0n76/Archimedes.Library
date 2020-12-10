using Archimedes.Library.Logger;
using NUnit.Framework;

namespace Archimedes.Library.Tests
{
    [TestFixture]
    public class BatchLogTests
    {
        [Test]
        public void Should_Start_Test_Logger()
        {
            var logger = new BatchLog();

            logger.Start();
            logger.Update("update 1");
            logger.Update("update 2");
            logger.Update("update 3");

            var result = logger.Print();

            Assert.NotNull(result);

        }
    }
}