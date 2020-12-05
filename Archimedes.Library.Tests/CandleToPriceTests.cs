using System.Linq;
using Archimedes.Library.Candles;
using Archimedes.Library.Message.Dto;
using NUnit.Framework;

namespace Archimedes.Library.Tests
{
    [TestFixture]
    public class CandleToPriceTests
    {
        [Test]
        public void Should_Load_Candle()
        {
            var candle = new CandleToPrice();
            var testCandle = GetTestCandle();

            var result = candle.ExtractRandomPrices(testCandle, 100, 100000);

            Assert.AreEqual(100,result.Count);
        }

        [Test]
        public void Should_Load_Candle_OpenPrice_Match_OpenPrice()
        {
            var candle = new CandleToPrice();
            var testCandle = GetTestCandle();

            var result = candle.ExtractRandomPrices(testCandle, 100, 100000);

            Assert.AreEqual(testCandle.BidOpen, result.First().Bid);
        }

        [Test]
        public void Should_Load_Candle_ClosePrice_Match_ClosePrice()
        {
            var candle = new CandleToPrice();
            var testCandle = GetTestCandle();

            var result = candle.ExtractRandomPrices(testCandle, 100, 100000);

            Assert.AreEqual(testCandle.BidClose, result.Last().Bid);
        }

        [Test]
        public void Should_Load_Candle_ClosePrice_NotMatch_ClosePrice()
        {
            var candle = new CandleToPrice();
            var testCandle = GetTestCandle();

            var result = candle.ExtractRandomPrices(testCandle, 100, 100000);

            Assert.AreNotEqual(testCandle.BidOpen, result.Last().Bid);
        }

        private static CandleDto GetTestCandle()
        {
            var testCandle = new CandleDto()
            {
                BidOpen = 1.2915m,
                BidHigh = 1.2916m,
                BidLow = 1.2906m,
                BidClose = 1.2908m
            };
            return testCandle;
        }
    }
}



