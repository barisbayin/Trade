using Binance.Net;
using Binance.Net.Enums;
using Binance.Net.Objects;
using Business.Abstract;
using Business.Concrete;
using CryptoExchange.Net.Authentication;
using DataAccess.Abstract;
using DataAccess.Concrete;
using RemoteData.Binance.GeneralApi.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using BinanceWsManager = RemoteData.Binance.WebSocket.Concrete.BinanceWsManager;
using IBinanceWsService = RemoteData.Binance.WebSocket.Abstract.IBinanceWsService;

namespace KlineUpdater
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WindowWidth = 165;
            Console.WindowHeight = 50;

            //Console.WriteLine("    _____  .__                  __                     .___                              __                \r\n  /  _  \\ |  |    ____   _____/  |_____________     __| _/____   _____ _____    _______/  |_  ___________ \r\n /  /_\\  \\|  |   / ___\\ /  _ \\   __\\_  __ \\__  \\   / __ |/ __ \\ /     \\\\__  \\  /  ___/\\   __\\/ __ \\_  __ \\\r\n/    |    \\  |__/ /_/  >  <_> )  |  |  | \\// __ \\_/ /_/ \\  ___/|  Y Y  \\/ __ \\_\\___ \\  |  | \\  ___/|  | \\/\r\n\\____|__  /____/\\___  / \\____/|__|  |__|  (____  /\\____ |\\___  >__|_|  (____  /____  > |__|  \\___  >__|   \r\n        \\/     /_____/                         \\/      \\/    \\/      \\/     \\/     \\/            \\/       ");

            #region Entry 

            Console.WriteLine("\r\n                ▄▄▄       ██▓      ▄████  ▒█████  ▄▄▄█████▓ ██▀███   ▄▄▄      ▓█████▄ ▓█████  ███▄ ▄███▓ ▄▄▄        ██████ ▄▄▄█████▓▓█████  ██▀███  \r\n                ▒████▄    ▓██▒     ██▒ ▀█▒▒██▒  ██▒▓  ██▒ ▓▒▓██ ▒ ██▒▒████▄    ▒██▀ ██ ▓█   ▀ ▓██▒▀█▀ ██▒▒████▄    ▒██    ▒ ▓  ██▒ ▓▒▓█   ▀ ▓██ ▒ ██▒\r\n                ▒██  ▀█▄  ▒██░    ▒██░▄▄▄░▒██░  ██▒▒ ▓██░ ▒░▓██ ░▄█ ▒▒██  ▀█▄  ░██   █ ▒███   ▓██    ▓██░▒██  ▀█▄  ░ ▓██▄   ▒ ▓██░ ▒░▒███   ▓██ ░▄█ ▒\r\n                ░██▄▄▄▄██ ▒██░    ░▓█  ██▓▒██   ██░░ ▓██▓ ░ ▒██▀▀█▄  ░██▄▄▄▄██ ░██▄  █▒▓█  ▄  ▒██    ▒██ ░██▄▄▄▄██   ▒   ██▒░ ▓██▓ ░ ▒▓█  ▄ ▒██▀▀█▄  \r\n                ▓█    ▓██▒░██████▒░▒▓███▀▒░ ████▓▒░  ▒██▒ ░ ░██▓ ▒██▒ ▓█   ▓██▒░▒████▓ ░▒████▒▒██▒   ░██▒ ▓█   ▓██▒▒██████▒▒  ▒██▒ ░ ░▒████▒░██▓ ▒██▒\r\n                ▒▒    ▓▒█░░ ▒░▓  ░ ░▒   ▒ ░ ▒░▒░▒░   ▒ ░░   ░ ▒▓ ░▒▓░ ▒▒   ▓▒█░ ▒▒▓  ▒ ░░ ▒░ ░░ ▒░   ░  ░ ▒▒   ▓▒█░▒ ▒▓▒ ▒ ░  ▒ ░░   ░░ ▒░ ░░ ▒▓ ░▒▓░\r\n                ▒   ▒▒ ░░ ░ ▒  ░  ░   ░   ░ ▒ ▒░     ░      ░▒ ░ ▒░  ▒   ▒▒ ░ ░ ▒  ▒  ░ ░  ░░  ░      ░  ▒   ▒▒ ░░ ░▒  ░ ░    ░     ░ ░  ░  ░▒ ░ ▒░\r\n                ░   ▒     ░ ░   ░ ░   ░ ░ ░ ░ ▒    ░        ░░   ░   ░   ▒    ░ ░  ░    ░   ░      ░     ░   ▒   ░  ░  ░    ░         ░     ░░   ░ \r\n                ░  ░    ░  ░      ░     ░ ░              ░           ░  ░   ░       ░  ░       ░         ░  ░      ░              ░  ░   ░     \r\n                ░                                                                    \r\n            ");


            #endregion



            string symbolPair = "BTCUSDT";
            string interval = "FourHour";
            int indicatorParameterId = 12;

            IBinanceWsService binanceKlineWsService = new BinanceWsManager(new BinanceSocketClient());
            IBinanceFuturesUsdtKlineDal binanceFuturesUsdtKlineDal = new EfBinanceFuturesUsdtKlineDal();

            BinanceClient binanceClient = new BinanceClient(new BinanceClientOptions()
            {
                ApiCredentials = new ApiCredentials("API-KEY", "API-SECRET")
            });
             

            IBinanceKlineService binanceKlineService = new BinanceKlineManager(new EfBinanceFuturesUsdtKlineDal(), new BinanceApiManager(new BinanceClient()));


            var result = binanceKlineService.AddFuturesUsdtKlinesToDatabaseAsync(symbolPair, new List<string> { interval });

            Console.WriteLine(result.Result.Message);

            //Thread.Sleep(1000);


            IIndicatorService indicatorService = new IndicatorManager(
                new BinanceKlineManager(new EfBinanceFuturesUsdtKlineDal()),new EfIndicatorDal(),
                new IndicatorParameterManager(new EfIndicatorParameterDal()));


            var streamData = binanceKlineWsService.GetCurrentFuturesUsdtKlineDataAsync(symbolPair, (KlineInterval)Enum.Parse(typeof(KlineInterval), interval));



            while (indicatorParameterId==12)
            {
                Console.ForegroundColor = ConsoleColor.White;

                //Console.WriteLine("OpenTime: {4}, Open= {0}, High= {1}, Low={2}, Close= {3}, Volume= {5}, QuoteVolume= {6}", streamData.Result.Open, streamData.Result.High, streamData.Result.Low, streamData.Result.Close, streamData.Result.OpenTime, streamData.Result.BaseVolume, streamData.Result.QuoteVolume);
                Thread.Sleep(1500);



                if (streamData.Result.Open != 0)
                {
                    var lastKline = binanceFuturesUsdtKlineDal.GetAllAsync(x => x.SymbolPair == symbolPair && x.KlineInterval == interval).Result.LastOrDefault();

                    if (lastKline.OpenTime.Date == streamData.Result.OpenTime.Date && lastKline.OpenTime.TimeOfDay == streamData.Result.OpenTime.TimeOfDay)
                    {
                        streamData.Result.Id = lastKline.Id;
                        Console.ForegroundColor = ConsoleColor.White;

                        binanceFuturesUsdtKlineDal.UpdateAsync(streamData.Result);
                        Console.WriteLine("Kline updated! => OpenTime: {4}, Open= {0}, High= {1}, Low={2}, Close= {3}, Volume= {5}, QuoteVolume= {6}", streamData.Result.Open, streamData.Result.High, streamData.Result.Low, streamData.Result.Close, streamData.Result.OpenTime, streamData.Result.BaseVolume, streamData.Result.QuoteVolume);

                        var renkoResults = indicatorService.GetFuturesUsdtRenkoBricks(symbolPair, interval, indicatorParameterId).Data;

                        var renkoResult = renkoResults.LastOrDefault();

                        decimal currentProfit = 0;

                        if (renkoResult.IsUp == true)
                        {
                            var lastFalseRenkoBrick = renkoResults.LastOrDefault(x => x.IsUp == false);
                            var firstTrueRenkoAfterTheLastFalse = renkoResults.Where(x => x.Id == lastFalseRenkoBrick.Id + 1).FirstOrDefault();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Last False Brick Details:  OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}", lastFalseRenkoBrick.Date, lastFalseRenkoBrick.Open, lastFalseRenkoBrick.Close, lastFalseRenkoBrick.IsUp);
                            Console.WriteLine("First True Brick After The Last False Brick Details:  OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}", firstTrueRenkoAfterTheLastFalse.Date, firstTrueRenkoAfterTheLastFalse.Open, firstTrueRenkoAfterTheLastFalse.Close, firstTrueRenkoAfterTheLastFalse.IsUp);
                            Console.ForegroundColor = ConsoleColor.DarkGreen;

                            currentProfit = Math.Round(streamData.Result.Close / firstTrueRenkoAfterTheLastFalse.Close * 100 - 100, 2);
                        }
                        else if (renkoResult.IsUp == false)
                        {
                            var lastTrueRenkoBrick = renkoResults.LastOrDefault(x => x.IsUp == true);
                            var firstFalseRenkoAfterTheLastFalse = renkoResults.Where(x => x.Id == lastTrueRenkoBrick.Id + 1).FirstOrDefault();
                            Console.ForegroundColor = ConsoleColor.DarkGreen;

                            Console.WriteLine("Last True Brick Details:  OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}", lastTrueRenkoBrick.Date, lastTrueRenkoBrick.Open, lastTrueRenkoBrick.Close, lastTrueRenkoBrick.IsUp);
                            Console.WriteLine("First True Brick After The Last False Brick Details:  OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}", firstFalseRenkoAfterTheLastFalse.Date, firstFalseRenkoAfterTheLastFalse.Open, firstFalseRenkoAfterTheLastFalse.Close, firstFalseRenkoAfterTheLastFalse.IsUp);
                            Console.ForegroundColor = ConsoleColor.Red;

                            currentProfit = Math.Round(streamData.Result.Close / firstFalseRenkoAfterTheLastFalse.Close * 100 - 100, 2);
                        }

                        Console.WriteLine("SymbolPair: {0}, Interval: {1}, OpenTime: {2}, Open: {3}, Close: {4}, BrickSide: {5}", renkoResult.SymbolPair, renkoResult.KlineInterval, renkoResult.Date, renkoResult.Open, renkoResult.Close, renkoResult.IsUp);

                        Console.WriteLine("##########   Current Profit = %" + currentProfit+ "   ##########");
                        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------");
                    }
                    else
                    {
                        streamData.Result.Id = null;
                        binanceFuturesUsdtKlineDal.AddAsync(streamData.Result);
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine("Kline inserted! =>OpenTime: {4}, Open= {0}, High= {1}, Low={2}, Close= {3}, Volume= {5}, QuoteVolume= {6}", streamData.Result.Open, streamData.Result.High, streamData.Result.Low, streamData.Result.Close, streamData.Result.OpenTime, streamData.Result.BaseVolume, streamData.Result.QuoteVolume);
                        Console.ForegroundColor = ConsoleColor.DarkYellow;

                        var renkoResults = indicatorService.GetFuturesUsdtRenkoBricks(symbolPair, interval, indicatorParameterId).Data;

                        var renkoResult = renkoResults.LastOrDefault();

                        decimal currentProfit = 0;

                        if (renkoResult.IsUp == true)
                        {
                            var lastFalseRenkoBrick = renkoResults.LastOrDefault(x => x.IsUp == false);
                            var firstTrueRenkoAfterTheLastFalse = renkoResults.Where(x => x.Id == lastFalseRenkoBrick.Id + 1).FirstOrDefault();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Last False Brick Details:  OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}", lastFalseRenkoBrick.Date, lastFalseRenkoBrick.Open, lastFalseRenkoBrick.Close, lastFalseRenkoBrick.IsUp);
                            Console.WriteLine("First True Brick After The Last False Brick Details:  OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}", firstTrueRenkoAfterTheLastFalse.Date, firstTrueRenkoAfterTheLastFalse.Open, firstTrueRenkoAfterTheLastFalse.Close, firstTrueRenkoAfterTheLastFalse.IsUp);
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            currentProfit = Math.Round(streamData.Result.Close / firstTrueRenkoAfterTheLastFalse.Close * 100 - 100, 2);

                        }
                        else if (renkoResult.IsUp == false)
                        {
                            var lastTrueRenkoBrick = renkoResults.LastOrDefault(x => x.IsUp == true);
                            var firstFalseRenkoAfterTheLastFalse = renkoResults.Where(x => x.Id == lastTrueRenkoBrick.Id + 1).FirstOrDefault();
                            Console.ForegroundColor = ConsoleColor.DarkGreen;

                            Console.WriteLine("Last True Brick Details:  OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}", lastTrueRenkoBrick.Date, lastTrueRenkoBrick.Open, lastTrueRenkoBrick.Close, lastTrueRenkoBrick.IsUp);
                            Console.WriteLine("First True Brick After The Last False Brick Details:  OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}", firstFalseRenkoAfterTheLastFalse.Date, firstFalseRenkoAfterTheLastFalse.Open, firstFalseRenkoAfterTheLastFalse.Close, firstFalseRenkoAfterTheLastFalse.IsUp);
                            Console.ForegroundColor = ConsoleColor.Red;
                            currentProfit = Math.Round(streamData.Result.Close / firstFalseRenkoAfterTheLastFalse.Close * 100 - 100, 2);
                        }

                        Console.WriteLine("SymbolPair: {0}, Interval: {1}, OpenTime: {2}, Open: {3}, Close: {4}, BrickSide: {5}", renkoResult.SymbolPair, renkoResult.KlineInterval, renkoResult.Date, renkoResult.Open, renkoResult.Close, renkoResult.IsUp);

                        Console.WriteLine("##########Current Profit = %" + currentProfit + " ##########");
                        Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------");

                    }
                }
            }
        }
    }
}
