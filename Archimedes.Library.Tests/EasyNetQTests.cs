using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Archimedes.Library.Domain;
using Archimedes.Library.Message;
using EasyNetQ;
using NUnit.Framework;

namespace Archimedes.Library.Tests
{
    [TestFixture]
    public class EasyNetQTests
    {
        [Test]
        public  void Should_Subscribe_To_PropertiesDto_Queue()
        {

            var prop = new TestObject()
            {
                TestName = "Test2",
                TestNames = new List<string>(),
                Dates = new List<DateRange>{new DateRange(){EndDate = new DateTime(2010,07,05),StartDate = new DateTime(2010,07,05)}}
                
            };

            var requestCandle = new RequestCandle( )
            {
                Market = "Test2",
                Status = "Status",
                Text = "Test2",
                EndDate = new DateTime(2010,07,05),
                StartDate = new DateTime(2010,07,05),
                MaxIntervals = 1000,
                TimeFrame = "Min",
                Interval = 1
            };



            var result = new RequestCandle( );

             Task.Run(() =>
             {
                 using (var bus = RabbitHutch.CreateBus("host=localhost:5673"))
                 {
                     bus.Subscribe<RequestCandle>("", @interfaceType =>
                     {
                         if (@interfaceType is RequestCandle props)
                         {
                             result = props;
                         }
                     });


                     while (true)
                     {
                         Thread.Sleep(5);
                     }
                 }
             });

            Thread.Sleep(1000);

            using (var bus2 = RabbitHutch.CreateBus("host=localhost:5673"))
            {
                for (var i = 0; i < 10; i++)
                {
                    bus2.Publish(requestCandle);
                    Thread.Sleep(500);
                }
            }

            Assert.AreEqual("Status",result.Status);

        }

        public class TestObject
        {
            public string TestName { get; set; }
            public List<string> TestNames { get; set; }

            public List<DateRange> Dates { get; set; }
        }

    }
}



