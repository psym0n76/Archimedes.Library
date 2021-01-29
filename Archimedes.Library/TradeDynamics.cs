using System;

namespace Archimedes.Library
{
    public class TradeDynamics
    {
        private readonly decimal _capital;
        private readonly int _trades;
        private readonly decimal _riskAsPercentage;
        private readonly decimal _marketPrice;
        private readonly decimal _spreadAsPip;

        public TradeDynamics(decimal capital, int trades, decimal riskAsPercentage, decimal marketPrice,
            decimal spreadAsPip)
        {
            _capital = capital;
            _trades = trades;
            _riskAsPercentage = riskAsPercentage / 100;
            _marketPrice = marketPrice;
            _spreadAsPip = spreadAsPip;
        }

        public decimal TotalTradeValue => _riskAsPercentage * _capital;
        
        public decimal TradeValue => TotalTradeValue / _trades;

        public decimal PipPrice => Math.Round((1 / _marketPrice) / 10, 10);

        public decimal PipAmount => Math.Round((TotalTradeValue / PipPrice), 2);

        public decimal PipValue(decimal pips)
        {
            return Math.Round(PipPrice * Lots * pips, 2);
        }

        public decimal Lots => Math.Round(PipAmount / _spreadAsPip);

        public decimal LotsPerTrade => Math.Round(PipAmount / _spreadAsPip / _trades);
    }
}