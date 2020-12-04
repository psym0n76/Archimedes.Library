using System.Diagnostics;
using System.Threading;
using Archimedes.Library.Message;
using Archimedes.Library.RabbitMq;
using NUnit.Framework;

namespace Archimedes.Library.Tests
{
    [TestFixture]
    public class RabbitMqTests
    {
        [Test]
        [Ignore("integration test")]
        public void Should_CreateQueue_SubscribeMessage()
        {

            var subject = GetSubjectUnderTest1();

            subject.HandleMessage += Subject_HandleMessage1;
            subject.Subscribe(new CancellationToken());

        }

        private void Subject_HandleMessage1(object sender, MessageHandlerEventArgs args)
        {
            throw new System.NotImplementedException();
        }


        private static IConsumer GetSubjectUnderTest1()
        {
            return new Consumer("",1,"","");
        }
    }
}