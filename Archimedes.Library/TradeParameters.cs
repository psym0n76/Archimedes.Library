using System;
using System.Collections.Generic;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library
{
    public class TradeParameters
    {
        public decimal EntryPrice { get; set; }
        public string BuySell { get; set; }


        public int SpreadAsPips { get; set; }
        public decimal Spread => Convert.ToDecimal(SpreadAsPips) / 10000;


        public int RiskReward { get; set; }
        public int TradeCounter { get; set; }

        public string Market { get; set; }


        public decimal TargetPrice(int i)
        {
            return EntryPrice + (BuySell == "SELL" ? -Spread * i : Spread * i);
        }

        public decimal SetStopPrice()
        {
            return EntryPrice - (BuySell == "SELL" ? -Spread : Spread);
        }

        public List<TransactionPriceTargetDto> ProfitTargets => SetPriceTargets();
        public List<TransactionPriceTargetDto> StopTargets => SetStopTargets();
        public string RiskRewardProfile { get; set; }

        private List<TransactionPriceTargetDto> SetStopTargets()
        {
            var stopTargets = new List<TransactionPriceTargetDto>
            {
                new TransactionPriceTargetDto()
                {
                    EntryPrice = EntryPrice,
                    Closed = false,
                    TargetPrice = SetStopPrice(),
                    LastUpdated = DateTime.Now
                }
            };

            return stopTargets;
        }

        private List<TransactionPriceTargetDto> SetPriceTargets()
        {
            var priceTargets = new List<TransactionPriceTargetDto>();

            for (var tradeIndex = 1; tradeIndex <= TradeCounter; tradeIndex++)
            {
                priceTargets.Add(new TransactionPriceTargetDto()
                {
                    EntryPrice = EntryPrice,
                    Closed = false,
                    TargetPrice = TargetPrice(tradeIndex),
                    LastUpdated = DateTime.Now
                });
            }

            return priceTargets;
        }
    }
}