using System.Diagnostics;
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

            subject.HandleMessage += Subject_HandleMessage;

            subject.Subscribe("CandleQueue");

        }

        private void Subject_HandleMessage(string args)
        {
            Debug.Print(args);
        }

        private static IConsumer GetSubjectUnderTest1()
        {
            return new Consumer("",1,"");
        }

        [Test]
       [Ignore("integration test")]
        public void Should_CreateQueue_PublishMessage()
        {
            var subject = GetSubjectUnderTest();

            var req = new RequestCandle(){Text = "test"};

            for (var i = 0; i < 5; i++)
            {
                subject.PublishMessage(req,"CandleQueue");
            }
        }

        private static IProducer<RequestCandle> GetSubjectUnderTest()
        {
            return new Producer<RequestCandle>("localhost",5673,"");
        }
    }
}