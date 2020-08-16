using System.Diagnostics;
using Archimedes.Library.RabbitMq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

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

            subject.Subscribe("CandleQueue", "Archimedes_DEV",5673);



        }

        private void Subject_HandleMessage(RabbitMqMessageArgs args)
        {
            Debug.Print(args.Message);
        }

        private IConsumer GetSubjectUnderTest1()
        {
            return new Consumer();
        }

        [Test]
        [Ignore("integration test")]
        public void Should_CreateQueue_PublishMessage()
        {
            var subject = GetSubjectUnderTest();

            for (int i = 0; i < 5; i++)
            {
                subject.PublishMessage("CandleQueue","Archimedes_DEV","TestMessage " + i);
                subject.PublishMessage("CandleQueue","Archimedes_DEV","TestMessage " + i);
                subject.PublishMessage("CandleQueue","Archimedes_DEV","TestMessage " + i); 
            }
        }

        private IProducer GetSubjectUnderTest()
        {
            return new Producer();
        }
    }
}