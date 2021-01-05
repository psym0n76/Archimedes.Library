using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.Price
{
    public interface IPriceAggregator
    {
        void Add(List<PriceDto> prices);

        bool SendPrice();

        int AggregatorCount();

        Dictionary<string, PriceDto> GetHighLows();

        PriceDto GetLowBidAndAskHigh();
    }
}