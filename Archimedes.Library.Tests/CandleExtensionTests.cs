﻿using System;
using Archimedes.Library.Candles;
using Archimedes.Library.Enums;
using NUnit.Framework;

namespace Archimedes.Library.Tests
{
    [TestFixture]
    public class CandleExtensionTests
    {
        [Test]
        public void Should_Load_And_Identify_RedCandle()
        {
            var subject = GetRedEngulfCandle();
            var result = subject.Color();

            Assert.AreEqual(Colour.Red,result);
        }

        [Test]
        public void Should_Load_And_NotIdentify_RedCandle()
        {
            var subject = GetRedEngulfCandle();
            var result = subject.Color();

            Assert.AreNotEqual(Colour.Green,result);
        }

        [Test]
        public void Should_Load_And_Identify_GreenCandle()
        {
            var subject = GetGreenEngulfCandle();
            var result = subject.Color();

            Assert.AreEqual(Colour.Green,result);
        }

        [Test]
        public void Should_Load_And_NotIdentify_GreenCandle()
        {
            var subject = GetGreenEngulfCandle();
            var result = subject.Color();

            Assert.AreNotEqual(Colour.Red,result);
        }


        [Test]
        public void Should_Return_BidOpen_When_Top_IsCalled_WithRedCandle()
        {
            var subject = GetRedEngulfCandle();
            var candleColour = subject.Color();
            var result = subject.Top().Bid;

            Assert.AreEqual(Colour.Red,candleColour);
            Assert.AreEqual(subject.Open.Bid,result);
        }

        [Test]
        public void Should_NotReturn_BidClose_When_Top_IsCalled_WithRedCandle()
        {
            var subject = GetRedEngulfCandle();
            var candleColour = subject.Color();
            var result = subject.Top().Bid;

            Assert.AreEqual(Colour.Red,candleColour);
            Assert.AreNotEqual(subject.Close.Bid,result);
        }

        [Test]
        public void Should_Return_BidClose_When_Bottom_IsCalled_WithRedCandle()
        {
            var subject = GetRedEngulfCandle();
            var candleColour = subject.Color();
            var result = subject.Bottom().Bid;

            Assert.AreEqual(Colour.Red,candleColour);
            Assert.AreEqual(subject.Close.Bid,result);
        }

        [Test]
        public void Should_NotReturn_BidClose_When_Bottom_IsCalled_WithRedCandle()
        {
            var subject = GetRedEngulfCandle();
            var candleColour = subject.Color();
            var result = subject.Bottom().Bid;

            Assert.AreEqual(Colour.Red,candleColour);
            Assert.AreNotEqual(subject.Open.Bid,result);
        }

        [Test]
        public void Should_Return_BidClose_When_Top_IsCalled_WithGreenCandle()
        {
            var subject = GetGreenEngulfCandle();
            var candleColour = subject.Color();
            var result = subject.Top().Bid;

            Assert.AreEqual(Colour.Green,candleColour);
            Assert.AreEqual(subject.Close.Bid,result);
        }

        [Test]
        public void Should_NotReturn_BidOpen_When_Top_IsCalled_WithGreenCandle()
        {
            var subject = GetGreenEngulfCandle();
            var candleColour = subject.Color();
            var result = subject.Top().Bid;

            Assert.AreEqual(Colour.Green,candleColour);
            Assert.AreNotEqual(subject.Open.Bid,result);
        }

        [Test]
        public void Should_Return_BidOpen_When_Bottom_IsCalled_WithGreenCandle()
        {
            var subject = GetGreenEngulfCandle();
            var candleColour = subject.Color();
            var result = subject.Bottom().Bid;

            Assert.AreEqual(Colour.Green,candleColour);
            Assert.AreEqual(subject.Open.Bid,result);
        }

        [Test]
        public void Should_NotReturn_BidClose_When_Bottom_IsCalled_WithGreenCandle()
        {
            var subject = GetGreenEngulfCandle();
            var candleColour = subject.Color();
            var result = subject.Bottom().Bid;

            Assert.AreEqual(Colour.Green,candleColour);
            Assert.AreNotEqual(subject.Close.Bid,result);
        }

        [Test]
        public void Should_NotReturn_EngulfingCandle()
        {
            var subject = GetRedNearlyFullEngulfCandle();
            var result = subject.Type();
            Assert.AreNotEqual(CandleType.Engulfing,result);

        }

        [Test]
        public void Should_NotReturn_DojiCandle()
        {
            var subject = GetRedNearlyFullEngulfCandle();
            var result = subject.Type();
            Assert.AreNotEqual(CandleType.Doji,result);

        }



        [Test]
        public void Should_Return_BodyFillRate_From_GreenCandle()
        {
            var subject = GetRedNearlyFullEngulfCandle();
            var result = subject.BodyFillRate();
            Assert.AreEqual(0.97,result);
        }

        [Test]
        public void Should_Return_BodyFillRate_From_RedCandle()
        {
            var subject = GetRedEngulfCandle();
            var result = subject.BodyFillRate();
            Assert.AreEqual(0.7,result);
        }








        private Candle GetRedEngulfCandle()
        {

            var redEngulfCandle = new Candle(
                new Open(1.2915m, 1.2921m),
                new High(1.2916m, 1.2922m),
                new Low(1.2906m, 1.2918m),
                new Close(1.2908m, 1.2918m),
                "GBP/USD", "15Min", new DateTime(2020,10,07,22,45,00));

            return redEngulfCandle;
        }

        private Candle GetRedNearlyFullEngulfCandle()
        {
            var redEngulfCandle = new Candle(
                new Open(1.2952m, 1.2953m),
                new High(1.2953m, 1.2954m),
                new Low(1.2921m, 1.2922m),
                new Close(1.2921m, 1.2922m),
                "GBP/USD", "15Min", new DateTime(2020,10,08,10,30,00));

            return redEngulfCandle;
        }

        private Candle GetGreenEngulfCandle()
        {
            var getGreenEngulfCandle = new Candle(
                new Open(1.2908m, 1.2918m),
                new High(1.2921m, 1.2922m),
                new Low(1.2908m, 1.2917m),
                new Close(1.2918m, 1.2920m),
                "GBP/USD", "15Min", new DateTime(2020,10,07,23,00,00));

            return getGreenEngulfCandle;
        }

        private Candle GetNearlyDojiCandle()
        {
            var redEngulfCandle = new Candle(
                new Open(1.2927m, 1.2928m),
                new High(1.2927m, 1.2928m),
                new Low(1.2919m, 1.292m),
                new Close(1.2926m, 1.2927m),
                "GBP/USD", "15Min", new DateTime(2020,10,08,16,15,00));

            return redEngulfCandle;
        }
    }
}