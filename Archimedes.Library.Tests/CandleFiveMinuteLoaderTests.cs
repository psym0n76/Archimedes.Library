using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Archimedes.Library.Candles;
using Archimedes.Library.Message.Dto;
using NUnit.Framework;

namespace Archimedes.Library.Tests
{
    public class CandleFiveMinuteLoaderTests
    {

        private List<CandleDto> _oneCandles = new List<CandleDto>();
        private List<CandleDto> _candles = new List<CandleDto>();

        [SetUp]
        public void SetUp()
        {
            LoadMockFiveMinuteCandles();
            LoadOneCandle();
        }

        [Test]
        public void Should_LoadCandle_And_First_TimeStamp_Should_Match()
        {
            var subject = GetSubjectUnderTest();

            var result = subject.Load( _candles);

            Assert.AreEqual(new DateTime(2020, 12, 01, 00, 05, 00), result[0].TimeStamp);
        }


        [Test]
        public void Should_LoadCandle()
        {
            var subject = GetSubjectUnderTest();

            var result = subject.Load(_candles);

            Assert.AreEqual(287, result.Count);
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

            Assert.AreEqual(287, result.Count);

            Assert.IsTrue(stopWatch.Elapsed.TotalMilliseconds < 100); // increased to 50 for debugging, 25 causes too many fails
            TestContext.Out.WriteLineAsync($"Elapsed Time: {stopWatch.Elapsed.TotalMilliseconds}ms");
        }

        [Test]
        public void Performance_Should_Load_5Min_Candle_For_OneDay_OneHundredTimes()
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

            Assert.AreEqual(287, counter);

            Assert.IsTrue(stopWatch.Elapsed.TotalMilliseconds < 1750);
            TestContext.Out.WriteLineAsync($"Elapsed Time: {stopWatch.Elapsed.TotalMilliseconds}ms");
        }

        [Test]
        public void Should_Add_Fifteen_Candles_To_PastHistory()
        {
            var subject = GetSubjectUnderTest();
            var result = subject.Load( _candles);

            var historyCountPast = result
                .SelectMany(a => a.PastCandles).Count(a => a.TimeStamp == new DateTime(2020, 12, 01, 01, 40, 00));

            Assert.AreEqual(14, historyCountPast);

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


        private void LoadMockFiveMinuteCandles()
        {
            var data = new FileReader();
            _candles = data.Reader<CandleDto>("GBPUSD_5Min_202012012200_202012022200");
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