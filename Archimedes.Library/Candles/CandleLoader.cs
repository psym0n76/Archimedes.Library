using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.Candles
{
    public class CandleLoader : ICandleLoader
    {
        public List<Candle> Load(string market, string granularity, int granularityInterval, List<CandleDto> candlesByGranularityMarket)
        {
            var candles = new ConcurrentBag<Candle>();
            var elapsedTime = new Stopwatch();
            var result = new List<Candle>();
            elapsedTime.Start();

            Parallel.ForEach(candlesByGranularityMarket,
                currentCandle => { Process(granularityInterval, currentCandle, candlesByGranularityMarket, candles); });

            // convert ConcurrentBag to a List to force ordering
            result.AddRange(candles.OrderBy(a => a.TimeStamp));
            return result;
        }

        private static void Process(int granularityInterval, CandleDto currentCandle, List<CandleDto> candlesByGranularityMarket, ConcurrentBag<Candle> candles)
        {
            var candle = LoadCandle(currentCandle);

            var taskFutureCandles = Task.Run(() =>
            {
                candle.FutureCandles.AddRange(GetCandles(candlesByGranularityMarket, currentCandle, granularityInterval, granularityInterval));
            });

            var taskPastCandles = Task.Run(() =>
            {
                candle.PastCandles.AddRange(GetCandles(candlesByGranularityMarket, currentCandle, -granularityInterval, granularityInterval)
                    .OrderByDescending(a => a.TimeStamp));
            });

            Task.WaitAll(taskPastCandles, taskFutureCandles);

            candles.Add(candle);
        }

        private static Candle LoadCandle(CandleDto dto)
        {
            var candle = new Candle(
                new Open(dto.BidOpen, dto.AskOpen),
                new High(dto.BidHigh, dto.AskHigh),
                new Low(dto.BidLow, dto.AskLow),
                new Close(dto.BidClose, dto.AskClose),
                dto.Market, dto.Granularity, dto.TimeStamp);
            return candle;
        }

        private static IEnumerable<Candle> GetCandles(IEnumerable<CandleDto> candleHistory, CandleDto currentCandle,
            int granularityInterval, int granularityNumber)
        {
            List<CandleDto> historyCandles;

            if (granularityInterval > 0)
            {
                //forward in time
                historyCandles = candleHistory.Where(a =>
                    a.FromDate > currentCandle.FromDate &&
                    a.FromDate <= currentCandle.FromDate.AddMinutes(granularityInterval * granularityNumber)).ToList();
            }
            else
            {
                historyCandles = candleHistory.Where(a =>
                    a.FromDate > currentCandle.FromDate.AddMinutes(granularityInterval * granularityNumber) &&
                    a.FromDate < currentCandle.FromDate).ToList();
            }


            return historyCandles.Select(hist =>
                new Candle(
                    new Open(hist.BidOpen, hist.AskOpen),
                    new High(hist.BidHigh, hist.AskHigh),
                    new Low(hist.BidLow, hist.AskLow),
                    new Close(hist.BidClose, hist.AskClose),
                    hist.Market, hist.Granularity, hist.TimeStamp)).ToList();
        }
    }
}