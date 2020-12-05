using System;
using System.Collections.Generic;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.Candles
{
    public class CandleToPrice
    {
        public List<PriceDto> ExtractRandomPrices(CandleDto candle, int quantity, int multiplier)
        {
            var prices = new List<PriceDto>();
            var random = new Random();

            var bidHigh = (int) candle.BidHigh * multiplier;
            var bidLow = (int) candle.BidLow * multiplier;

            for (var i = 1; i <= quantity; i++)
            {
                if (i == 1)
                {
                    prices.Add(new PriceDto() {Ask = candle.BidOpen, Bid = candle.BidOpen});
                    continue;
                }

                if (i == quantity)
                {
                    prices.Add(new PriceDto() {Ask = candle.BidClose, Bid = candle.BidClose});
                    break;
                }

                decimal randomPrice = random.Next(bidHigh, bidLow);

                prices.Add(new PriceDto() {Ask = randomPrice / multiplier, Bid = randomPrice / multiplier});
            }

            return prices;
        }
    }
}