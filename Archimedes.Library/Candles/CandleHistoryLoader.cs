﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Archimedes.Library.Extensions;
using Archimedes.Library.Message.Dto;

namespace Archimedes.Library.Candles
{
    public class CandleHistoryLoader : ICandleHistoryLoader
    {
        public List<Candle> Load(List<CandleDto> candles)
        {

            if (candles.Count==0)
            {
                throw new ArgumentNullException(paramName: nameof(candles), "Attempting to Load Candles but the Candle collection is empty");
            }

            var concurrentBag = new ConcurrentBag<Candle>();
            var elapsedTime = new Stopwatch();
            var result = new List<Candle>();

            var granularityInterval = candles[0].Granularity.ExtractTimeInterval();

            if (granularityInterval == 0)
            {
                throw new ArgumentNullException(paramName: nameof(candles), $"Attempting to Load Candles but Granularity is missing {candles[0].Granularity}");
            }

            elapsedTime.Start();


            try
            {
                Parallel.ForEach(candles,
                    currentCandle => { Process(granularityInterval, currentCandle, candles, concurrentBag); });

                // convert ConcurrentBag to a List to force ordering
                result.AddRange(concurrentBag.OrderBy(a => a.TimeStamp));
                return result;
            }
            catch (Exception e)
            {
                throw new ArgumentNullException(paramName: nameof(candles), $"Attempting to Load Candles but unknown error {e.Message} {e.StackTrace}");
            }
        }

        private void Process(int granularityInterval, CandleDto currentCandle,
            List<CandleDto> candlesByGranularityMarket, ConcurrentBag<Candle> candles)
        {
            var candle = InstantiateCandle(currentCandle);

            var taskFutureCandles = Task.Run(() =>
            {
                candle.FutureCandles.AddRange(GetCandles(candlesByGranularityMarket, currentCandle,
                    granularityInterval, 15));
            });

            var taskPastCandles = Task.Run(() =>
            {
                candle.PastCandles.AddRange(
                    GetCandles(candlesByGranularityMarket, currentCandle, -granularityInterval, 15)
                        .OrderByDescending(a => a.TimeStamp));
            });

            Task.WaitAll(taskPastCandles, taskFutureCandles);

            candles.Add(candle);
        }

        public Candle InstantiateCandle(CandleDto dto)
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
            int granularityInterval, int candleCount)
        {
            List<CandleDto> historyCandles;

            if (granularityInterval > 0)
            {
                //forward in time
                historyCandles = candleHistory.Where(a =>
                    a.FromDate > currentCandle.FromDate &&
                    a.FromDate <= currentCandle.FromDate.AddMinutes(granularityInterval * candleCount


                    )).ToList();
            }
            else
            {
                historyCandles = candleHistory.Where(a =>
                    a.FromDate > currentCandle.FromDate.AddMinutes(granularityInterval * candleCount) &&
                    a.FromDate < currentCandle.FromDate).ToList();
            }

            if (!historyCandles.Any())
            {
                return new List<Candle>();
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