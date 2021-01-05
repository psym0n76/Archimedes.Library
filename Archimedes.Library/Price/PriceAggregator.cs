using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
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

        public int AggregatorCount()
        {
            return _aggregatorCount;
        }

        public Dictionary<string, PriceDto> GetHighLows()
        {
            lock (LockingObject)
            {
                var ordered = GetHighLow().OrderBy(z => z.Value.TimeStamp)
                    .ToDictionary(x => x.Key, x => x.Value);
                return ordered;
            }
        }

        private Dictionary<string, PriceDto> GetHighLow()
        {
            var dict = new Dictionary<string, PriceDto>();

            var bidHigh = new PriceDto();
            var bidLow = new PriceDto();
            var askHigh = new PriceDto();
            var askLow = new PriceDto();

            if (_pricesQueue.TryPeek(out var current))
            {
                bidHigh.Bid = current.Bid;
                bidLow.Bid = current.Bid;
                askHigh.Ask = current.Ask;
                askLow.Ask = current.Ask;
            }

            else
            {
                return new Dictionary<string, PriceDto>();
            }

            for (var i = 1; i <= _aggregatorCount; i++)
            {
                if (!_pricesQueue.TryDequeue(out var price)) continue;

                if (price.Bid >= bidHigh.Bid)
                {
                    bidHigh = price;
                    dict["BidHigh"] = bidHigh;
                }

                if (price.Ask >= askHigh.Ask)
                {
                    askHigh = price;
                    dict["AskHigh"] = askHigh;
                }

                if (price.Bid <= bidLow.Bid)
                {
                    bidLow = price;
                    dict["BidLow"] = bidLow;
                }

                if (price.Ask <= askLow.Ask)
                {
                    askLow = price;
                    dict["AskLow"] = askLow;
                }
            }

            ResetAggregator();
            return dict;
        }


        public PriceDto GetLowBidAndAskHigh()
        {
            var hlPrice = new PriceDto();

            if (_pricesQueue.TryPeek(out var current))
            {
                hlPrice.Bid = current.Bid;
                hlPrice.Ask = current.Ask;
            }

            else
            {
                return new PriceDto();
            }

            for (var i = 1; i <= _aggregatorCount; i++)
            {
                if (!_pricesQueue.TryDequeue(out var price)) continue;


                if (price.Ask <= hlPrice.Ask)
                {
                    hlPrice.Ask = price.Ask;
                    hlPrice.TimeStamp = price.TimeStamp;
                }

                if (price.Bid >= hlPrice.Bid)
                {
                    hlPrice.Bid = price.Bid;
                    hlPrice.TimeStamp = price.TimeStamp;
                }
            }

            ResetAggregator();
            return hlPrice;
        }

    }
}