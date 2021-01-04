using System;
using System.Collections.Generic;
using System.Threading;
using Archimedes.Library.Message.Dto;
using Archimedes.Library.Price;
using NUnit.Framework;

namespace Archimedes.Library.Tests
{
    [TestFixture]
    public class PriceAggregatorTests
    {
        [Test]
        public void Should_LowestBidPrice_ConcurrentQueue()
        {
            var subject = GetSubjectUnderTest(5);

            var prices = AddPriceToList(1.5m, 1.6m);

            subject.Add(prices);
            var price = subject.GetHighLowsLocked();
            

            Assert.AreEqual(1.6m, price.BidLow);
        }

        
        [Test]
        public void Should_ReturnLowestBidPrice_FromFivePrices_FromConcurrentQueueOfSix()
        {
            var subject = GetSubjectUnderTest(5);

            AddSixPricesToQueue(subject);

            var price = subject.GetHighLowsLocked();

            Assert.AreEqual(1.2m, price.BidLow);
        }

        [Test]
        public void Should_ReturnLowestBidPrice_FromSixPrices_FromConcurrentQueueOfSix()
        {
            var subject = GetSubjectUnderTest(6);

            AddSixPricesToQueue(subject);

            var price = subject.GetHighLowsLocked();

            Assert.AreEqual(1.1m, price.BidLow);
        }

        [Test]
        public void Should_ReturnLowestAskPrice_FromFivePrices_FromConcurrentQueueOfSix()
        {
            var subject = GetSubjectUnderTest(5);

            AddSixPricesToQueue(subject);

            var price = subject.GetHighLowsLocked();

            Assert.AreEqual(1.3m, price.AskLow);
        }

        [Test]
        public void Should_ReturnLowestAskPrice_FromSixPrices_FromConcurrentQueueOfSix()
        {
            var subject = GetSubjectUnderTest(6);

            AddSixPricesToQueue(subject);

            var price = subject.GetHighLowsLocked();

            Assert.AreEqual(1.3m, price.AskLow);
        }


        [Test]
        public void Should_ReturnLowestAskPrice_FromOnePrice_FromConcurrentQueueOfOne()
        {
            var subject = GetSubjectUnderTest(5);

            subject.Add(AddPriceToList(1.5m,1.6m));

            var price = subject.GetHighLowsLocked();

            Assert.AreEqual(1.5m, price.AskLow);
        }

        [Test]
        public void Should_ReturnLowestBidPrice_FromOnePrice_FromConcurrentQueueOfOne()
        {
            var subject = GetSubjectUnderTest(5);

            subject.Add(AddPriceToList(1.5m, 1.6m));

            var price = subject.GetHighLowsLocked();

            Assert.AreEqual(1.6m, price.BidLow);
        }











        [Test]
        public void Should_ReturnHighestBidPrice_ConcurrentQueue()
        {
            var subject = GetSubjectUnderTest(5);

            var prices = AddPriceToList(1.5m, 1.6m);

            subject.Add(prices);
            var price = subject.GetHighLowsLocked();

            Assert.AreEqual(1.6m, price.BidHigh);

        }

        [Test]
        public void Should_ReturnHighestBidPrice_FromFivePrices_FromConcurrentQueueOfSix()
        {
            var subject = GetSubjectUnderTest(5);

            AddSixPricesToQueue(subject);

            var price = subject.GetHighLowsLocked();

            Assert.AreEqual(1.6m, price.BidHigh);
        }

        [Test]
        public void Should_ReturnHighestBidPrice_FromSixPrices_FromConcurrentQueueOfSix()
        {
            var subject = GetSubjectUnderTest(6);

            AddSixPricesToQueue(subject);

            var price = subject.GetHighLowsLocked();

            Assert.AreEqual(1.6m, price.BidHigh);
        }

        [Test]
        public void Should_ReturnHighestAskPrice_FromFivePrices_FromConcurrentQueueOfSix()
        {
            var subject = GetSubjectUnderTest(5);

            AddSixPricesToQueue(subject);

            var price = subject.GetHighLowsLocked();

            Assert.AreEqual(1.7m, price.AskHigh);
        }

        [Test]
        public void Should_ReturnHighestAskPrice_FromSixPrices_FromConcurrentQueueOfSix()
        {
            var subject = GetSubjectUnderTest(6);

            AddSixPricesToQueue(subject);

            var price = subject.GetHighLowsLocked();

            Assert.AreEqual(1.7m, price.AskHigh);
        }


        [Test]
        public void Should_ReturnHighestAskPrice_FromOnePrice_FromConcurrentQueueOfOne()
        {
            var subject = GetSubjectUnderTest(5);

            subject.Add(AddPriceToList(1.5m, 1.6m));

            var price = subject.GetHighLowsLocked();

            Assert.AreEqual(1.5m, price.AskHigh);
        }

        [Test]
        public void Should_ReturnHighestBidPrice_FromOnePrice_FromConcurrentQueueOfOne()
        {
            var subject = GetSubjectUnderTest(5);

            subject.Add(AddPriceToList(1.5m, 1.6m));

            var price = subject.GetHighLowsLocked();

            Assert.AreEqual(1.6m, price.BidHigh);
        }


















        private static void AddSixPricesToQueue(IPriceAggregator subject)
        {
            subject.Add(AddPriceToList(1.5m, 1.6m));
            subject.Add(AddPriceToList(1.4m, 1.5m));
            subject.Add(AddPriceToList(1.5m, 1.4m));
            subject.Add(AddPriceToList(1.7m, 1.3m));
            subject.Add(AddPriceToList(1.3m, 1.2m));
            subject.Add(AddPriceToList(1.3m, 1.1m)); //last entry
        }

        private static List<PriceDto> AddPriceToList(decimal ask, decimal bid ,bool b = true)
        {
            var prices = new List<PriceDto>()
            {
                new PriceDto()
                {
                    Ask = ask,
                    Bid = bid,
                    TimeStamp = DateTime.Now
                }
            };

            if (b)
            {
                Thread.Sleep(100);
            }
            
            return prices;
        }


        private IPriceAggregator GetSubjectUnderTest(int iterations)
        {
            return new PriceAggregator(iterations);
        }
    }
}