using System;
using Archimedes.Library.Message;
using NUnit.Framework;

namespace Archimedes.Library.Tests
{
    [TestFixture]
    public class RequestCandleTests
    {
        [TestCase("2020-04-20T12:00:00", "2020-04-20T10:00:00", 5, "minute", 24)]
        [TestCase("2020-04-20T12:00:00", "2020-04-20T11:55:00", 5, "minute", 1)]
        [TestCase("2020-04-20T12:00:00", "2020-04-20T12:00:00", 5, "minute", 0)]
        [TestCase("2020-04-20T12:00:00", "2020-04-20T08:00:00", 4, "hour", 1)]
        [TestCase("2020-04-20T12:00:00", "2020-04-20T04:00:00", 4, "hour", 2)]
        [TestCase("2020-04-20T12:00:00", "2020-04-20T12:00:00", 4, "hour", 0)]
        public void Should_Count_intervals_that_match_expected(DateTime toDate, DateTime fromDate, int interval,
            string timeFrame,
            int expected)
        {
            var subject = new RequestCandle(fromDate, toDate,7666)
            {
                Interval = interval,
                TimeFrame = timeFrame,
            };

            var result = subject.IntervalCount();

            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase("2020-04-20T10:00:00", "2020-04-20T12:00:00", 5, "minute", "2020-04-20T10:00:00", "2020-04-20T12:00:00")]
        public void Should_create_a_collection_of_start_and_end_Date(DateTime fromDate, DateTime toDate, int interval,
            string timeFrame, DateTime expectedFromDate, DateTime expectedToDate)
        {
            var subject = new RequestCandle(fromDate, toDate,100){Interval = interval,TimeFrame = timeFrame};

            var result = subject.DateRanges;

            Assert.That(result.Count, Is.EqualTo(1));

            Assert.That(result[0].DateFrom, Is.EqualTo(expectedFromDate));
            Assert.That(result[0].DateTo, Is.EqualTo(expectedToDate));
        }

        [Test]
        public void Should_create_a_collection_of_start_and_end_Dates_first()
        {
            var fromDate = new DateTime(2020,04,20,10,00,00);
            var toDate = new DateTime(2020,04,20,10,55,00);

            var subject = new RequestCandle(fromDate, toDate,10){Interval = 5,TimeFrame = "minute"};

            var result = subject.DateRanges;

            Assert.That(result.Count, Is.EqualTo(2));

            Assert.That(result[0].DateFrom, Is.EqualTo(fromDate));
            Assert.That(result[0].DateTo, Is.EqualTo(new DateTime(2020,04,20,10,50,00)));
        }

        [Test]
        public void Should_create_a_collection_of_start_and_end_Dates_second()
        {

            var fromDate = new DateTime(2020,04,20,10,00,00);
            var toDate = new DateTime(2020,04,20,10,55,00);

            var subject = new RequestCandle(fromDate, toDate,10){Interval = 5,TimeFrame = "minute"};

            var result = subject.DateRanges;

            Assert.That(result.Count, Is.EqualTo(2));

            Assert.That(result[1].DateFrom, Is.EqualTo(new DateTime(2020,04,20,10,50,00)));
            Assert.That(result[1].DateTo, Is.EqualTo(new DateTime(2020,04,20,10,55,00)));
        }
    }
}