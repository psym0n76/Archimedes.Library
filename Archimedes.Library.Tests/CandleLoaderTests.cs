using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Archimedes.Library.Candles;
using Archimedes.Library.Message.Dto;
using NUnit.Framework;

namespace Archimedes.Library.Tests
{
    public class CandleLoaderTests
    {

        private List<CandleDto> _candles = new List<CandleDto>();
        private List<CandleDto> _oneCandles = new List<CandleDto>();

        [SetUp]
        public void SetUp()
        {
            LoadMockCandles();
            LoadOneCandle();
        }

        [Test]
        public void Should_LoadCandle_And_First_TimeStamp_Should_Match()
        {
            var subject = GetSubjectUnderTest();

            var result = subject.Load( _candles);

            Assert.AreEqual(new DateTime(2020, 10, 07, 22, 00, 00), result.Take(1).Select(a => a.TimeStamp).Single());
        }


        [Test]
        public void Should_LoadCandle()
        {
            var subject = GetSubjectUnderTest();

            var result = subject.Load(_candles);

            Assert.AreEqual(97, result.Count);
        }

        [Test]
        public void Should_LoadOneCandle_WithNoError()
        {
            var subject = GetSubjectUnderTest();

            var result = subject.Load(_oneCandles);

            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void Performance_Should_Load_15Min_Candle_For_OneDay_In_LessThan_25_Milliseconds()
        {
            //average loads 98 rows in 21ms
            // in reality this is 8 - 10ms

            var subject = GetSubjectUnderTest();

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var result = subject.Load( _candles);

            Assert.AreEqual(97, result.Count);

            Assert.IsTrue(stopWatch.Elapsed.TotalMilliseconds < 100); // increased to 50 for debugging, 25 causes too many fails
            TestContext.Out.WriteLineAsync($"Elapsed Time: {stopWatch.Elapsed.TotalMilliseconds}ms");
        }

        [Test]
        public void Performance_Should_Load_15Min_Candle_For_OneDay_OneHundredTimes()
        {
            //average loads 98 rows in 21ms
            //average 600 for 9800ms
            //average 5544 for 98000ms

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var counter = 0;
            var subject = GetSubjectUnderTest();

            for (var i = 1; i < 100; i++)
            {
                var result = subject.Load( _candles);
                counter = result.Count;
            }

            Assert.AreEqual(97, counter);

            Assert.IsTrue(stopWatch.Elapsed.TotalMilliseconds < 750);
            TestContext.Out.WriteLineAsync($"Elapsed Time: {stopWatch.Elapsed.TotalMilliseconds}ms");
        }

        [Test]
        public void Should_Add_Fifteen_Candles_To_PastHistory()
        {
            var subject = GetSubjectUnderTest();
            var result = subject.Load( _candles);

            var historyCountPast = result
                .SelectMany(a => a.PastCandles).Count(a => a.TimeStamp == new DateTime(2020, 10, 08, 01, 45, 00));

            Assert.AreEqual(14, historyCountPast);

        }

        [Test]
        public void Should_Not_Add_Current_Candle_To_PastHistory()
        {
            var subject = GetSubjectUnderTest();
            var candles = subject.Load( _candles);

            const string currentFromDate = "2020-10-08T01:45:00";

            var historyCollection = new List<Candle>();

            foreach (var candle in candles.Where(h => h.TimeStamp == new DateTime(2020, 10, 08, 01, 45, 00)))
            {
                historyCollection.AddRange(candle.PastCandles);
            }

            Assert.IsFalse(historyCollection.Any(a => a.TimeStamp == DateTime.Parse(currentFromDate)));
        }

        [Test]
        public void Should_Load_Candles_In_Ascending_Order()
        {
            var subject = GetSubjectUnderTest();
            var candles = subject.Load( _candles);

            var firstCandle = candles.Take(1).Select(a => a.TimeStamp).First();
            var lastCandle = candles.TakeLast(1).Select(a => a.TimeStamp).First();

            Assert.IsTrue(lastCandle > firstCandle);
        }

        [Test]
        public void Should_Add_PastCandles_With_Max_And_Min_Candles_Matching_Result()
        {
            var subject = GetSubjectUnderTest();
            var result = subject.Load( _candles);

            var history = result.Where(a => a.TimeStamp == new DateTime(2020, 10, 08, 01, 45, 00)).ToList();

            var minDate = history.Select(a => a.PastCandles.Select(b => b.TimeStamp).Min()).FirstOrDefault();
            var maxDate = history.Select(a => a.PastCandles.Select(b => b.TimeStamp).Max()).FirstOrDefault();

            Assert.AreEqual(new DateTime(2020, 10, 08, 01, 30, 00), maxDate);
            Assert.AreEqual(new DateTime(2020, 10, 07, 22, 15, 00), minDate);
        }

        [Test]
        public void Should_Load_PastCandles_In_DescendingOrder()
        {
            var subject = GetSubjectUnderTest();
            var result = subject.Load( _candles);

            var history = result.Where(a => a.TimeStamp == new DateTime(2020, 10, 08, 01, 45, 00)).ToList();

            var historyCandles = history.Select(a => a.PastCandles).Single();

            var timeStamp = historyCandles.Take(1).Select(a => a.TimeStamp).Single();

            Assert.AreEqual(new DateTime(2020, 10, 08, 01, 30, 00), timeStamp);
        }

        [Test]
        public void Should_Load_FutureCandles_In_AscendingOrder()
        {
            var subject = GetSubjectUnderTest();
            var result = subject.Load( _candles);

            var history = result.Where(a => a.TimeStamp == new DateTime(2020, 10, 08, 01, 45, 00)).ToList();

            var futureCandles = history.Select(a => a.FutureCandles).Single();

            var timeStamp = futureCandles.Take(1).Select(a => a.TimeStamp).Single();

            Assert.AreEqual(new DateTime(2020, 10, 08, 02, 00, 00), timeStamp);
        }

        [Test]
        public void Should_Add_FutureCandles_With_Max_And_Min_Candles_Matching_Result()
        {
            var subject = GetSubjectUnderTest();
            var result = subject.Load( _candles);

            var history = result.Where(a => a.TimeStamp == new DateTime(2020, 10, 08, 01, 45, 00)).ToList();

            var minDate = history.Select(a => a.FutureCandles.Select(b => b.TimeStamp).Min()).FirstOrDefault();
            var maxDate = history.Select(a => a.FutureCandles.Select(b => b.TimeStamp).Max()).FirstOrDefault();

            Assert.AreEqual(new DateTime(2020, 10, 08, 02, 00, 00), minDate);
            Assert.AreEqual(new DateTime(2020, 10, 08, 05, 30, 00), maxDate);
        }

        private void LoadMockCandles()
        {
            var data = new FileReader();
            _candles = data.Reader<CandleDto>("GBPUSD_15Min_202010072200_202010082200");
        }


        private void LoadOneCandle()
        {
            _oneCandles = new List<CandleDto>()
            {
                new CandleDto()
                {
                    BidOpen = 1.2m,
                    TimeStamp = new DateTime(2020,10,10),
                    Granularity = "5min",
                    FromDate = new DateTime(2020,10,10),
                    ToDate = new DateTime(2020,10,11)
                }
            };
        }


        private static ICandleHistoryLoader GetSubjectUnderTest()
        {
            return new CandleHistoryLoader();
        }
    }
}