using System.Collections.Generic;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.Candles
{
    public interface ICandleHistoryLoader
    {
        List<Candle> Load(List<CandleDto> candles);
    }
}