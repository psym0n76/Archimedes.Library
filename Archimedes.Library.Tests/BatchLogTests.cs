using System.Threading;
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

            var id = logger.Start();
            Thread.Sleep(1230);

            logger.Update(id,"update 1");
            Thread.Sleep(102);

            logger.Update(id,"update 2");
            Thread.Sleep(130);

            logger.Update(id,"update 3");
            Thread.Sleep(100);

            logger.Update(id, "update 4");
            Thread.Sleep(100);

            logger.Update(id, "update 5ddddddddddddd");
            Thread.Sleep(107);

            var result = logger.Print(id);

            Assert.NotNull(result);

        }
    }
}