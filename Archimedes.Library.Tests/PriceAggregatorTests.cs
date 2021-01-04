using System;
using System.Collections.Generic;
using System.Linq;
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
            var price = subject.GetHighLows();


            Assert.AreEqual(1.6m, price["BidLow"].Bid);
        }


        [Test]
        public void Should_ReturnLowestBidPrice_FromFivePrices_FromConcurrentQueueOfSix()
        {
            var subject = GetSubjectUnderTest(5);

            AddSixPricesToQueue(subject);

            var price = subject.GetHighLows();

            Assert.AreEqual(1.2m, price["BidLow"].Bid);
        }

        [Test]
        public void Should_ReturnLowestBidPrice_FromSixPrices_FromConcurrentQueueOfSix()
        {
            var subject = GetSubjectUnderTest(6);

            AddSixPricesToQueue(subject);

            var price = subject.GetHighLows();

            Assert.AreEqual(1.1m, price["BidLow"].Bid);
        }

        [Test]
        public void Should_ReturnLowestAskPrice_FromFivePrices_FromConcurrentQueueOfSix()
        {
            var subject = GetSubjectUnderTest(5);

            AddSixPricesToQueue(subject);

            var price = subject.GetHighLows();

            Assert.AreEqual(1.3m, price["AskLow"].Ask);
        }

        [Test]
        public void Should_ReturnLowestAskPrice_FromSixPrices_FromConcurrentQueueOfSix()
        {
            var subject = GetSubjectUnderTest(6);

            AddSixPricesToQueue(subject);

            var price = subject.GetHighLows();

            Assert.AreEqual(1.3m, price["AskLow"].Ask);
        }


        [Test]
        public void Should_ReturnLowestAskPrice_FromOnePrice_FromConcurrentQueueOfOne()
        {
            var subject = GetSubjectUnderTest(5);

            subject.Add(AddPriceToList(1.5m, 1.6m));

            var price = subject.GetHighLows();

            Assert.AreEqual(1.5m, price["AskLow"].Ask);
        }

        [Test]
        public void Should_ReturnLowestBidPrice_FromOnePrice_FromConcurrentQueueOfOne()
        {
            var subject = GetSubjectUnderTest(5);

            subject.Add(AddPriceToList(1.5m, 1.6m));

            var price = subject.GetHighLows();

            Assert.AreEqual(1.6m, price["BidLow"].Bid);
        }











        [Test]
        public void Should_ReturnHighestBidPrice_ConcurrentQueue()
        {
            var subject = GetSubjectUnderTest(5);

            var prices = AddPriceToList(1.5m, 1.6m);

            subject.Add(prices);
            var price = subject.GetHighLows();

            Assert.AreEqual(1.6m, price["BidHigh"].Bid);

        }

        [Test]
        public void Should_ReturnHighestBidPrice_FromFivePrices_FromConcurrentQueueOfSix()
        {
            var subject = GetSubjectUnderTest(5);

            AddSixPricesToQueue(subject);

            var price = subject.GetHighLows();

            Assert.AreEqual(1.6m, price["BidHigh"].Bid);
        }

        [Test]
        public void Should_ReturnHighestBidPrice_FromSixPrices_FromConcurrentQueueOfSix()
        {
            var subject = GetSubjectUnderTest(6);

            AddSixPricesToQueue(subject);

            var price = subject.GetHighLows();

            Assert.AreEqual(1.6m, price["BidHigh"].Bid);
        }

        [Test]
        public void Should_ReturnHighestAskPrice_FromFivePrices_FromConcurrentQueueOfSix()
        {
            var subject = GetSubjectUnderTest(5);

            AddSixPricesToQueue(subject);

            var price = subject.GetHighLows();

            Assert.AreEqual(1.7m, price["AskHigh"].Ask);
        }

        [Test]
        public void Should_ReturnHighestAskPrice_FromSixPrices_FromConcurrentQueueOfSix()
        {
            var subject = GetSubjectUnderTest(6);

            AddSixPricesToQueue(subject);

            var price = subject.GetHighLows();

            Assert.AreEqual(1.7m, price["AskHigh"].Ask);
        }


        [Test]
        public void Should_ReturnHighestAskPrice_FromOnePrice_FromConcurrentQueueOfOne()
        {
            var subject = GetSubjectUnderTest(5);

            subject.Add(AddPriceToList(1.5m, 1.6m));

            var price = subject.GetHighLows();

            Assert.AreEqual(1.5m, price["AskHigh"].Ask);
        }

        [Test]
        public void Should_ReturnHighestBidPrice_FromOnePrice_FromConcurrentQueueOfOne()
        {
            var subject = GetSubjectUnderTest(5);

            subject.Add(AddPriceToList(1.5m, 1.6m));

            var price = subject.GetHighLows();

            Assert.AreEqual(1.6m, price["BidHigh"].Bid);
        }


        [Test]
        public void Should_ReturnOrderList_FromSixPrices_FromConcurrentQueueOfSix()
        {
            var subject = GetSubjectUnderTest(6);

            AddSixPricesToQueue(subject,100);

            var price = subject.GetHighLows();

            var first = price.First();
            var last = price.Last();
            
            Assert.IsTrue(first.Value.TimeStamp < last.Value.TimeStamp);
        }


        private static void AddSixPricesToQueue(IPriceAggregator subject, int delay = 0)
        {
            subject.Add(AddPriceToList(1.5m, 1.6m, delay));
            subject.Add(AddPriceToList(1.4m, 1.5m, delay));
            subject.Add(AddPriceToList(1.5m, 1.4m, delay));
            subject.Add(AddPriceToList(1.7m, 1.3m, delay));
            subject.Add(AddPriceToList(1.3m, 1.2m, delay));
            subject.Add(AddPriceToList(1.3m, 1.1m, delay)); //last entry
        }

        private static List<PriceDto> AddPriceToList(decimal ask, decimal bid, int delay = 0)
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

            Thread.Sleep(delay);
            return prices;
        }


        private IPriceAggregator GetSubjectUnderTest(int iterations)
        {
            return new PriceAggregator(iterations);
        }
    }
}