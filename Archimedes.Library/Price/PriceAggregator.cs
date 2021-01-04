using System.Collections.Concurrent;
using System.Collections.Generic;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.Price
{
    public class PriceAggregator : IPriceAggregator
    {
        private static readonly object LockingObject = new object();
        private readonly ConcurrentQueue<PriceDto> _pricesQueue = new ConcurrentQueue<PriceDto>();
        private readonly int _aggregatorCount;
        private int _aggregatorCounter;

        public PriceAggregator(int aggregatorCount)
        {
            _aggregatorCount = aggregatorCount;
        }


        public void Add(List<PriceDto> prices)
        {
            foreach (var price in prices)
            {
                _pricesQueue.Enqueue(price);
                _aggregatorCounter++;
            }
        }

        private void ResetAggregator()
        {
            _aggregatorCounter = 0;
        }

        public bool SendPrice()
        {
            return _aggregatorCounter == _aggregatorCount;
        }

        public HighLowPrices GetHighLowsLocked()
        {
            lock (LockingObject)
            {
                return GetHighLows();
            }
        }

        private HighLowPrices GetHighLows()
        {
            var highLowPrices = new HighLowPrices();

            if (_pricesQueue.TryPeek(out var current))
            {
                highLowPrices.BidLow = current.Bid;
                highLowPrices.BidHigh = current.Bid;
                highLowPrices.AskLow = current.Ask;
                highLowPrices.AskHigh = current.Ask;
            }

            else
            {
                return new HighLowPrices();
            }

            for (var i = 1; i <= _aggregatorCount; i++)
            {
                if (!_pricesQueue.TryDequeue(out var price)) continue;

                if (price.Bid >= highLowPrices.BidHigh)
                {
                    highLowPrices.BidHigh = price.Bid;
                    highLowPrices.BidHighTimestamp = price.TimeStamp;
                }

                if (price.Ask >= highLowPrices.AskHigh)
                {
                    highLowPrices.AskHigh = price.Ask;
                    highLowPrices.AskHighTimestamp = price.TimeStamp;
                }

                if (price.Bid <= highLowPrices.BidLow)
                {
                    highLowPrices.BidLow = price.Bid;
                    highLowPrices.BidLowTimestamp = price.TimeStamp;
                }

                if (price.Ask <= highLowPrices.AskLow)
                {
                    highLowPrices.AskLow = price.Ask;
                    highLowPrices.AskLowTimestamp = price.TimeStamp;
                }
            }

            ResetAggregator();
            return highLowPrices;
        }
    }
}