using NUnit.Framework;

namespace Archimedes.Library.Tests
{
    [TestFixture]
    public class TradeDynamicsTests
    {
        const decimal Capital = 20000m;
        const int Trades = 2;
        const decimal MarketPrice = 1.282835m;
        const decimal Risk = 1m;
        const decimal SpreadAsPip = 7.5m;

        [Test]
        public void Should_Return_TotalTradeValue()
        {
            var subject = GetTradeDynamics();
            Assert.AreEqual(200,subject.TotalTradeValue);
        }

        [Test]
        public void Should_Return_TradeValue()
        {
            var subject = GetTradeDynamics();
            Assert.AreEqual(100, subject.TradeValue);
        }

        
        [Test]
        [Ignore("tem")]
        public void Should_Return_PipCost()
        {
            var subject = GetTradeDynamics();
            Assert.AreEqual(0.0779101384m, subject.PipPrice);
        }

        
        [Test]
        public void Should_Return_PipValue()
        {
            var subject = GetTradeDynamics();
            Assert.AreEqual(2565.67, subject.PipAmount);
        }
        
        
        [Test]
        public void Should_Return_Lots()
        {
            var subject = GetTradeDynamics();
            Assert.AreEqual(342, subject.Lots);
        }

        [Test]
        public void Should_Return_LotsPerTrade()
        {
            var subject = GetTradeDynamics();
            Assert.AreEqual(171, subject.LotsPerTrade);
        }

        [Test]
        public void Should_return_PipValue()
        {
            var subject = GetTradeDynamics();
            var pipValue = subject.PipValue(7.5m);
            Assert.AreEqual(199.95,pipValue);
        }

        private static TradeDynamics GetTradeDynamics()
        {
            return new TradeDynamics(Capital, Trades, Risk, MarketPrice, SpreadAsPip);
        }
    }
}