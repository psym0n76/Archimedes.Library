using System.Collections.Generic;
using System.ComponentModel;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.Price
{
    public interface IPriceAggregator
    {
        void Add(List<PriceDto> prices);

        bool SendPrice();

        HighLowPrices GetHighLowsLocked();
    }
}