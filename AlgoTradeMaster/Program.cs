﻿using Binance.Net;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using RemoteData.Binance.WebSocket.Abstract;
using RemoteData.Binance.WebSocket.Concrete;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Binance.Net.Enums;
using Binance.Net.Objects;
using CryptoExchange.Net.Authentication;
using DataAccess.Abstract;
using Entity.Concrete.Entities;
using RemoteData.Binance.GeneralApi.Concrete;
using BinanceWsManager = RemoteData.Binance.WebSocket.Concrete.BinanceWsManager;
using IBinanceWsService = RemoteData.Binance.WebSocket.Abstract.IBinanceWsService;

namespace AlgoTradeMasterRenko
{
    class Program
    {
        static async Task Main(string[] args)

        {

            #region EntryCodes

            Console.WindowWidth = 165;
            Console.WindowHeight = 50;


            Console.WriteLine("\r\n                ▄▄▄       ██▓      ▄████  ▒█████  ▄▄▄█████▓ ██▀███   ▄▄▄      ▓█████▄ ▓█████  ███▄ ▄███▓ ▄▄▄        ██████ ▄▄▄█████▓▓█████  ██▀███  \r\n                ▒████▄    ▓██▒     ██▒ ▀█▒▒██▒  ██▒▓  ██▒ ▓▒▓██ ▒ ██▒▒████▄    ▒██▀ ██ ▓█   ▀ ▓██▒▀█▀ ██▒▒████▄    ▒██    ▒ ▓  ██▒ ▓▒▓█   ▀ ▓██ ▒ ██▒\r\n                ▒██  ▀█▄  ▒██░    ▒██░▄▄▄░▒██░  ██▒▒ ▓██░ ▒░▓██ ░▄█ ▒▒██  ▀█▄  ░██   █ ▒███   ▓██    ▓██░▒██  ▀█▄  ░ ▓██▄   ▒ ▓██░ ▒░▒███   ▓██ ░▄█ ▒\r\n                ░██▄▄▄▄██ ▒██░    ░▓█  ██▓▒██   ██░░ ▓██▓ ░ ▒██▀▀█▄  ░██▄▄▄▄██ ░██▄  █▒▓█  ▄  ▒██    ▒██ ░██▄▄▄▄██   ▒   ██▒░ ▓██▓ ░ ▒▓█  ▄ ▒██▀▀█▄  \r\n                ▓█    ▓██▒░██████▒░▒▓███▀▒░ ████▓▒░  ▒██▒ ░ ░██▓ ▒██▒ ▓█   ▓██▒░▒████▓ ░▒████▒▒██▒   ░██▒ ▓█   ▓██▒▒██████▒▒  ▒██▒ ░ ░▒████▒░██▓ ▒██▒\r\n                ▒▒    ▓▒█░░ ▒░▓  ░ ░▒   ▒ ░ ▒░▒░▒░   ▒ ░░   ░ ▒▓ ░▒▓░ ▒▒   ▓▒█░ ▒▒▓  ▒ ░░ ▒░ ░░ ▒░   ░  ░ ▒▒   ▓▒█░▒ ▒▓▒ ▒ ░  ▒ ░░   ░░ ▒░ ░░ ▒▓ ░▒▓░\r\n                ▒   ▒▒ ░░ ░ ▒  ░  ░   ░   ░ ▒ ▒░     ░      ░▒ ░ ▒░  ▒   ▒▒ ░ ░ ▒  ▒  ░ ░  ░░  ░      ░  ▒   ▒▒ ░░ ░▒  ░ ░    ░     ░ ░  ░  ░▒ ░ ▒░\r\n                ░   ▒     ░ ░   ░ ░   ░ ░ ░ ░ ▒    ░        ░░   ░   ░   ▒    ░ ░  ░    ░   ░      ░     ░   ▒   ░  ░  ░    ░         ░     ░░   ░ \r\n                ░  ░    ░  ░      ░     ░ ░              ░           ░  ░   ░       ░  ░       ░         ░  ░      ░              ░  ░   ░     \r\n                ░                                                                    \r\n            ");


            #endregion

            #region Instances

            ITradeFlowService tradeFlowService = new TradeFlowManager(new EfTradeFlowDal());
            ITradeParameterService tradeParameterService = new TradeParameterManager(new EfTradeParameterDal());
            IIndicatorParameterService indicatorParameterService = new IndicatorParameterManager(new EfIndicatorParameterDal());
            IApiInformationService apiInformationService = new ApiInformationManager(new EfApiInformationDal());
            IBinanceKlineService binanceKlineService = new BinanceKlineManager(new EfBinanceFuturesUsdtKlineDal(), new BinanceApiManager(new BinanceClient()));

            IBinanceWsService binanceKlineWsService = new BinanceWsManager(new BinanceSocketClient());
            IBinanceFuturesUsdtKlineDal binanceFuturesUsdtKlineDal = new EfBinanceFuturesUsdtKlineDal();

            IIndicatorService indicatorService = new IndicatorManager(
                new BinanceKlineManager(new EfBinanceFuturesUsdtKlineDal()), new EfIndicatorDal(),
                new IndicatorParameterManager(new EfIndicatorParameterDal()));

            #endregion

            var tradeFlow = tradeFlowService.GetSelectedTradeFlow().Data;

            if (tradeFlow == null)
            {
                Console.WriteLine("There is no selected TradeFlow!");
                Console.ReadLine();

            }

            var tradeParameter = tradeParameterService.GetTradeParameterEntityById(tradeFlow.TradeParameterId).Data;
            var indicatorParameter = indicatorParameterService.GetIndicatorParameterEntityById(tradeParameter.IndicatorParameterId).Data;
            var apiInformation = apiInformationService.GetDecryptedApiInformationById(tradeParameter.ApiInformationId).Data;

            Console.Title = "ALGOTRADEMASTER-RENKO: " + tradeParameter.SymbolPair.ToUpper() + " | " + tradeParameter.Interval.ToUpper() + " | " + indicatorParameter.KlineEndType.ToUpper() + " | " + indicatorParameter.Parameter1 + " | " + apiInformation.ApiTitle.ToUpper();



            #region Preparing For Trade

            BinanceClient binanceClient = new BinanceClient(new BinanceClientOptions()
            {
                ApiCredentials = new ApiCredentials(apiInformation.ApiKey, apiInformation.SecretKey)
            });



            await tradeFlowService.UpdateTradeFlowAsync(tradeFlow);


            tradeFlow.InUse = true;
            tradeFlow.IsSelected = false;
            tradeFlow.LookingForPosition = true;

            var result = binanceKlineService.AddFuturesUsdtKlinesToDatabaseAsync(tradeParameter.SymbolPair, new List<string> { tradeParameter.Interval });

            Console.WriteLine(result.Result.Message);

            #endregion


            var streamData = binanceKlineWsService.GetCurrentFuturesUsdtKlineDataAsync(tradeParameter.SymbolPair, (KlineInterval)Enum.Parse(typeof(KlineInterval), tradeParameter.Interval));



            while (tradeFlow.InUse == true)
            {

                Console.ForegroundColor = ConsoleColor.White;

                Thread.Sleep(1000);


                if (streamData.Result.Open != 0)
                {

                    var lastKline = await UpdateOrInsertKlineData(binanceFuturesUsdtKlineDal, tradeParameter, streamData);


                    if (tradeFlow.LookingForPosition == true)
                    {

                        Console.WriteLine("Trade Status: Looking For Position");
                    }



                    var renkoResults = indicatorService.GetFuturesUsdtRenkoBricks(tradeParameter.SymbolPair, tradeParameter.Interval, tradeParameter.IndicatorParameterId).Data;

                    var lastRenkoBrick = renkoResults.LastOrDefault();
                    //var lastTrueRenkoBrick = renkoResults.LastOrDefault(x => x.IsUp == true);
                    //var lastFalseRenkoBrick = renkoResults.LastOrDefault(x => x.IsUp == false);

                    decimal currentProfit = 0;

                    switch (lastRenkoBrick.IsUp)
                    {
                        case true:
                            {
                                var lastFalseRenkoBrick = renkoResults.LastOrDefault(x => x.IsUp == false);
                                var firstTrueRenkoAfterTheLastFalse = renkoResults.Where(x => x.Id == lastFalseRenkoBrick.Id + 1).FirstOrDefault();

                                var trueRenkoCount = Convert.ToInt32(lastRenkoBrick.Id) - Convert.ToInt32(firstTrueRenkoAfterTheLastFalse.Id);

                                if (trueRenkoCount >= 0 || trueRenkoCount < 3)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("LONG POSITION AREA: {0} - {1}",firstTrueRenkoAfterTheLastFalse.Open,lastRenkoBrick.Close);
                                }
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Last False Brick Details:  OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}", lastFalseRenkoBrick.Date, lastFalseRenkoBrick.Open, lastFalseRenkoBrick.Close, lastFalseRenkoBrick.IsUp);
                                Console.WriteLine("First True Brick After The Last False Brick Details:  OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}", firstTrueRenkoAfterTheLastFalse.Date, firstTrueRenkoAfterTheLastFalse.Open, firstTrueRenkoAfterTheLastFalse.Close, firstTrueRenkoAfterTheLastFalse.IsUp);
                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                currentProfit = Math.Round(streamData.Result.Close / firstTrueRenkoAfterTheLastFalse.Close * 100 - 100, 2);
                                break;
                            }
                        case false:
                            {
                                var lastTrueRenkoBrick = renkoResults.LastOrDefault(x => x.IsUp == true);
                                var firstFalseRenkoAfterTheLastFalse = renkoResults.Where(x => x.Id == lastTrueRenkoBrick.Id + 1).FirstOrDefault();

                                var falseRenkoCount = Convert.ToInt32(lastRenkoBrick.Id) - Convert.ToInt32(firstFalseRenkoAfterTheLastFalse.Id);

                                if (falseRenkoCount >= 0 || falseRenkoCount < 3)
                                {
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("SHORT POSITION AREA: {0} - {1}", firstFalseRenkoAfterTheLastFalse.Open, lastRenkoBrick.Close);
                                }

                                Console.ForegroundColor = ConsoleColor.DarkGreen;

                                Console.WriteLine("Last True Brick Details:  OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}", lastTrueRenkoBrick.Date, lastTrueRenkoBrick.Open, lastTrueRenkoBrick.Close, lastTrueRenkoBrick.IsUp);
                                Console.WriteLine("First True Brick After The Last False Brick Details:  OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}", firstFalseRenkoAfterTheLastFalse.Date, firstFalseRenkoAfterTheLastFalse.Open, firstFalseRenkoAfterTheLastFalse.Close, firstFalseRenkoAfterTheLastFalse.IsUp);
                                Console.ForegroundColor = ConsoleColor.Red;

                                currentProfit = Math.Round(streamData.Result.Close / firstFalseRenkoAfterTheLastFalse.Close * 100 - 100, 2);
                                break;
                            }
                    }

                    Console.WriteLine("SymbolPair: {0}, Interval: {1}, OpenTime: {2}, Open: {3}, Close: {4}, BrickSide: {5}", lastRenkoBrick.SymbolPair, lastRenkoBrick.KlineInterval, lastRenkoBrick.Date, lastRenkoBrick.Open, lastRenkoBrick.Close, lastRenkoBrick.IsUp);

                    Console.WriteLine("##########   Current Profit = %" + currentProfit + "   ##########");
                    Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------");

                }
            }
        }

        private static async Task<BinanceFuturesUsdtKlineEntity> UpdateOrInsertKlineData(IBinanceFuturesUsdtKlineDal binanceFuturesUsdtKlineDal,
            TradeParameterEntity tradeParameter, Task<BinanceFuturesUsdtKlineEntity> streamData)
        {
            var lastKline = (await binanceFuturesUsdtKlineDal.GetAllAsync(x =>
                x.SymbolPair == tradeParameter.SymbolPair && x.KlineInterval == tradeParameter.Interval)).LastOrDefault();

            if (lastKline.OpenTime.Date == streamData.Result.OpenTime.Date &&
                lastKline.OpenTime.TimeOfDay == streamData.Result.OpenTime.TimeOfDay)
            {
                streamData.Result.Id = lastKline.Id;
                Console.ForegroundColor = ConsoleColor.DarkGreen;

                await binanceFuturesUsdtKlineDal.UpdateAsync(streamData.Result);
                Console.WriteLine(
                    "Kline updated! => Time:{7}, OpenTime: {4}, Open= {0}, High= {1}, Low={2}, Close= {3}, Volume= {5}, QuoteVolume= {6}",
                    streamData.Result.Open, streamData.Result.High, streamData.Result.Low,
                    streamData.Result.Close, streamData.Result.OpenTime, streamData.Result.BaseVolume,
                    streamData.Result.QuoteVolume, DateTime.UtcNow);

                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                streamData.Result.Id = null;
                await binanceFuturesUsdtKlineDal.AddAsync(streamData.Result);
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.WriteLine(
                    "Kline inserted! => Time:{7}, OpenTime: {4}, Open= {0}, High= {1}, Low={2}, Close= {3}, Volume= {5}, QuoteVolume= {6}",
                    streamData.Result.Open, streamData.Result.High, streamData.Result.Low,
                    streamData.Result.Close, streamData.Result.OpenTime, streamData.Result.BaseVolume,
                    streamData.Result.QuoteVolume, DateTime.UtcNow);

                Console.ForegroundColor = ConsoleColor.White;
            }

            return lastKline;
        }
    }
}
