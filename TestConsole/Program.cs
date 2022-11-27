using Binance.Net;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using RemoteData.Binance.GeneralApi.Abstract;
using RemoteData.Binance.GeneralApi.Concrete;
using System;
using System.Collections.Generic;
using System.Threading;
using Binance.Net.Enums;
using Business.Helpers;
using Business.Tasks.Triggers;
using Entity.Concrete.Entities;
using RemoteData.Binance.WebSocket.Abstract;
using RemoteData.Binance.WebSocket.Concrete;
using System.Configuration;
using System.Threading.Tasks;
using Binance.Net.Objects;
using Skender.Stock.Indicators;
using IBinanceWsService = RemoteData.Binance.WebSocket.Abstract.IBinanceWsService;

namespace TestConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {


            BinanceClient binanceClient = new BinanceClient(new BinanceClientOptions());

            #region BuySellRatio
            /*
            var buySell = binanceClient.FuturesUsdt.Market.GetTakerBuySellVolumeRatioAsync("ETHUSDT", PeriodInterval.FifteenMinutes, 100).Result;

            foreach (var item in buySell.Data)
            {
                if (item.BuySellRatio < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Buy Sell Ratio: {0}", item.BuySellRatio);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Buy Sell Ratio: {0}", item.BuySellRatio);
                }

            }

            var longShort = binanceClient.FuturesUsdt.Market.GetTopLongShortAccountRatioAsync("ETHUSDT", PeriodInterval.FifteenMinutes, 100, DateTime.Now.AddDays(-3), DateTime.Now).Result;

            foreach (var item in longShort.Data)
            {
                if (item.LongShortRatio < 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Date: {0}, Buy Sell Ratio: {1}, Longs: {2}, Shorts: {3}", item.Timestamp, item.LongShortRatio, item.LongAccount, item.ShortAccount);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Date: {0}, Buy Sell Ratio: {1}, Longs: {2}, Shorts: {3}", item.Timestamp, item.LongShortRatio, item.LongAccount, item.ShortAccount);
                }
            }
            */
            #endregion

            IBinanceKlineService _binanceKlineService = new BinanceKlineManager(new EfBinanceFuturesUsdtKlineDal(),
                new BinanceApiManager(binanceClient));

            //await _binanceKlineService.AddFuturesUsdtKlinesToDatabaseAsync("ETHUSDT", new List<string> { "FourHour" });
            await _binanceKlineService.AddFuturesUsdtKlinesToDatabaseAsync("DOGEUSDT", new List<string> { "FifteenMinutes" });
            await _binanceKlineService.AddFuturesUsdtKlinesToDatabaseAsync("1000SHIBUSDT", new List<string> { "FifteenMinutes" });

            var btcKlines = _binanceKlineService.GetCurrencyKlinesToCalculateIndicatorAsync("DOGEUSDT", "FifteenMinutes", 1000).Result.Data;
            var ethKlines = _binanceKlineService.GetCurrencyKlinesToCalculateIndicatorAsync("1000SHIBUSDT", "FifteenMinutes", 1000).Result.Data;

            var wavesKlines = _binanceKlineService.GetCurrencyKlinesToCalculateIndicatorAsync("WAVESUSDT", "FourHour", 1000).Result.Data;


            IEnumerable<CorrResult> results = btcKlines.GetCorrelation(ethKlines, 20);

            foreach (var result in results.RemoveWarmupPeriods(20))
            {
                Console.WriteLine($"Date: {result.Date} | Correlation: {result.Correlation} | Covariance: {result.Covariance} | Rsquared: {result.RSquared} | A: {result.VarianceA} | B: {result.VarianceB}");

            }

            for (int i = 0; i <= 10; i++)
            {
                
            }

            Console.ReadLine();
        }
    }
}
