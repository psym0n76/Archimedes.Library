using System.Collections.Generic;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.Candles
{
    public interface ICandleLoader
    {
        List<Candle> Load(List<CandleDto> candlesByGranularityMarket);
    }
}