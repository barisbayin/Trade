using Binance.Net;
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
using RemoteData.Binance.GeneralApi.Abstract;
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

            #region Objects1

            var tradeFlow = (await tradeFlowService.GetSelectedTradeFlowAsync()).Data;

            if (tradeFlow == null)
            {
                Console.WriteLine("There is no selected TradeFlow!");
                Console.ReadLine();

            }

            var tradeParameter = (await tradeParameterService.GetTradeParameterEntityByIdAsync(tradeFlow.TradeParameterId)).Data;

            var indicatorParameter = (await indicatorParameterService.GetIndicatorParameterEntityByIdAsync(tradeParameter.IndicatorParameterId)).Data;

            var apiInformation = apiInformationService.GetDecryptedApiInformationById(tradeParameter.ApiInformationId).Data;




            #endregion

            #region Object Related Instances


            IBinanceApiService binanceApiService = new BinanceApiManager(new BinanceClient(), apiInformation.ApiKey, apiInformation.SecretKey);

            IBinanceExchangeInformationService binanceExchangeInformationService = new BinanceExchangeInformationManager(new EfBinanceFuturesUsdtSymbolDal(), binanceApiService);

            #endregion

            #region Objects2

            var symbolPairInformation = (await
                binanceExchangeInformationService.GetFuturesUsdtSymbolInformationBySymbolPairAsync(tradeParameter
                    .SymbolPair)).Data;

            #endregion


            #region Controls & Settings

            Console.Title = "ALGOTRADEMASTER-RENKO: " + tradeParameter.SymbolPair.ToUpper() + " | " + tradeParameter.Interval.ToUpper() + " | " + indicatorParameter.KlineEndType.ToUpper() + " | " + "BRICK SIZE: " + indicatorParameter.Parameter1 + " | " + apiInformation.ApiTitle.ToUpper();

            var leverageSet = await binanceApiService.SetLeverageForFuturesUsdtSymbolPairAsync(tradeParameter.SymbolPair, tradeParameter.Leverage);

            Console.WriteLine(leverageSet.Message);


            #endregion





            #region Preparing For Trade

            await binanceExchangeInformationService.AddFuturesUsdtSymbolInformationAsync();

            await tradeFlowService.UpdateTradeFlowAsync(tradeFlow);


            tradeFlow.InUse = true;
            tradeFlow.IsSelected = false;
            tradeFlow.LookingForPosition = true;

            var result = binanceKlineService.AddFuturesUsdtKlinesToDatabaseAsync(tradeParameter.SymbolPair, new List<string> { tradeParameter.Interval });

            Console.WriteLine(result.Result.Message);

            #endregion


            var streamData = await binanceKlineWsService.GetCurrentFuturesUsdtKlineDataAsync(tradeParameter.SymbolPair, (KlineInterval)Enum.Parse(typeof(KlineInterval), tradeParameter.Interval));


            FuturesUsdtRenkoBrick lastRenkoBrick = new FuturesUsdtRenkoBrick();
            FuturesUsdtRenkoBrick lastFalseRenkoBrick = new FuturesUsdtRenkoBrick();
            FuturesUsdtRenkoBrick lastTrueRenkoBrick = new FuturesUsdtRenkoBrick();
            FuturesUsdtRenkoBrick firstTrueRenkoAfterTheLastFalse = new FuturesUsdtRenkoBrick();
            FuturesUsdtRenkoBrick firstFalseRenkoAfterTheLastTrue = new FuturesUsdtRenkoBrick();

            long iteration = 0;

            while (tradeFlow.InUse == true)
            {
                int trueRenkoCount = -1;
                int falseRenkoCount = -1;

                Console.ForegroundColor = ConsoleColor.White;

                Thread.Sleep(1000);


                if (streamData.Open != 0)
                {
                    Console.WriteLine("UTC Time: {0}", DateTime.UtcNow);

                    var lastKline = await UpdateOrInsertKlineData(binanceFuturesUsdtKlineDal, tradeParameter, streamData);

                    var renkoResults = indicatorService.GetFuturesUsdtRenkoBricks(tradeParameter.SymbolPair, tradeParameter.Interval, tradeParameter.IndicatorParameterId).Data;

                    lastRenkoBrick = renkoResults.LastOrDefault();
                    //var lastTrueRenkoBrick = renkoResults.LastOrDefault(x => x.IsUp == true);
                    //var lastFalseRenkoBrick = renkoResults.LastOrDefault(x => x.IsUp == false);

                    decimal currentProfit = 0;

                    switch (lastRenkoBrick.IsUp)
                    {
                        case true:
                            {
                                lastFalseRenkoBrick = renkoResults.LastOrDefault(x => x.IsUp == false);
                                firstTrueRenkoAfterTheLastFalse = renkoResults.Where(x => x.Id == lastFalseRenkoBrick.Id + 1).FirstOrDefault();

                                trueRenkoCount = Convert.ToInt32(lastRenkoBrick.Id) - Convert.ToInt32(firstTrueRenkoAfterTheLastFalse.Id) + 1;

                                Console.ForegroundColor = ConsoleColor.White;

                                Console.WriteLine("============================================================================================================================================================");

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("Current PRICE/IN BRICK:  OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}, Price In BrickNumber: {4}", streamData.OpenTime, streamData.Open, streamData.Close, lastRenkoBrick.IsUp, trueRenkoCount + 1);

                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("Current COMPLETED Brick: OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}, BrickNumber: {4}", lastRenkoBrick.Date, lastRenkoBrick.Open, lastRenkoBrick.Close, lastRenkoBrick.IsUp, trueRenkoCount);

                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("First TRUE Brick:        OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}", firstTrueRenkoAfterTheLastFalse.Date, firstTrueRenkoAfterTheLastFalse.Open, firstTrueRenkoAfterTheLastFalse.Close, firstTrueRenkoAfterTheLastFalse.IsUp);

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Last FALSE Brick:        OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}", lastFalseRenkoBrick.Date, lastFalseRenkoBrick.Open, lastFalseRenkoBrick.Close, lastFalseRenkoBrick.IsUp);

                                Console.ForegroundColor = ConsoleColor.White;

                                Console.WriteLine("============================================================================================================================================================");

                                currentProfit = Math.Round(streamData.Close / firstTrueRenkoAfterTheLastFalse.Close * 100 - 100, 2);
                                break;
                            }
                        case false:
                            {
                                lastTrueRenkoBrick = renkoResults.LastOrDefault(x => x.IsUp == true);
                                firstFalseRenkoAfterTheLastTrue = renkoResults.Where(x => x.Id == lastTrueRenkoBrick.Id + 1).FirstOrDefault();

                                falseRenkoCount = Convert.ToInt32(lastRenkoBrick.Id) - Convert.ToInt32(firstFalseRenkoAfterTheLastTrue.Id) + 1;

                                Console.ForegroundColor = ConsoleColor.White;

                                Console.WriteLine("============================================================================================================================================================");

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("Current PRICE/IN BRICK:  OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}, Price In BrickNumber: {4}", streamData.OpenTime, streamData.Open, streamData.Close, lastRenkoBrick.IsUp, falseRenkoCount + 1);

                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("Current COMPLETED Brick: OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}, BrickNumber: {4}", lastRenkoBrick.Date, lastRenkoBrick.Open, lastRenkoBrick.Close, lastRenkoBrick.IsUp, falseRenkoCount);

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("First FALSE Brick:       OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}", firstFalseRenkoAfterTheLastTrue.Date, firstFalseRenkoAfterTheLastTrue.Open, firstFalseRenkoAfterTheLastTrue.Close, firstFalseRenkoAfterTheLastTrue.IsUp);

                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Last TRUE Brick:         OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}", lastTrueRenkoBrick.Date, lastTrueRenkoBrick.Open, lastTrueRenkoBrick.Close, lastTrueRenkoBrick.IsUp);

                                Console.ForegroundColor = ConsoleColor.White;

                                Console.WriteLine("============================================================================================================================================================");

                                currentProfit = Math.Round(streamData.Close / firstFalseRenkoAfterTheLastTrue.Close * 100 - 100, 2);
                                break;
                            }
                    }

                    if (tradeFlow.LookingForPosition == true && tradeFlow.ReadyToOpenOrder == false && tradeFlow.FollowUpOfOpenPosition == false)
                    {

                        Console.WriteLine("Trade Status: LOOKING FOR POSITION!");

                        if (trueRenkoCount >= 1 && trueRenkoCount < 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("LONG POSITION AREA: {0} - {1}", firstTrueRenkoAfterTheLastFalse.Open, firstTrueRenkoAfterTheLastFalse.Open + indicatorParameter.Parameter1 * 2);

                            tradeFlow.LookingForPosition = false;
                            tradeFlow.ReadyToOpenOrder = true;
                        }
                        if (falseRenkoCount >= 0 && falseRenkoCount < 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("SHORT POSITION AREA: {0} - {1}", firstFalseRenkoAfterTheLastTrue.Open, firstFalseRenkoAfterTheLastTrue.Open + indicatorParameter.Parameter1 * 2);

                            tradeFlow.LookingForPosition = false;
                            tradeFlow.ReadyToOpenOrder = true;
                        }
                    }

                    if (tradeFlow.ReadyToOpenOrder == true && tradeFlow.PlacingOrders == false && tradeFlow.FollowUpOfOpenPosition == false)
                    {
                        Console.WriteLine("Trade Status: READY TO OPEN ORDER!");

                        if (trueRenkoCount >= 1 && trueRenkoCount < 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("LONG POSITION ORDER ZONE: {0} - {1}", firstTrueRenkoAfterTheLastFalse.Open, firstTrueRenkoAfterTheLastFalse.Open + indicatorParameter.Parameter1 * 2);

                            tradeFlow.LookingForPosition = false;
                            tradeFlow.PlacingOrders = true;
                        }
                        else
                        {
                            tradeFlow.LookingForPosition = true;
                            tradeFlow.ReadyToOpenOrder = false;
                        }

                        if (falseRenkoCount >= 1 && falseRenkoCount < 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("SHORT POSITION ORDER ZONE: {0} - {1}", firstFalseRenkoAfterTheLastTrue.Open, firstFalseRenkoAfterTheLastTrue.Open + indicatorParameter.Parameter1 * 2);

                            tradeFlow.LookingForPosition = false;
                            tradeFlow.PlacingOrders = true;
                        }
                        else
                        {
                            tradeFlow.LookingForPosition = true;
                            tradeFlow.ReadyToOpenOrder = false;
                        }

                    }

                    if (tradeFlow.PlacingOrders && tradeFlow.FollowUpOfOpenPosition == false)
                    {
                        Console.WriteLine("Trade Status: PLACING ORDERS!");

                        decimal price1 = 0M;
                        decimal price2 = 0M;

                        decimal quantity1 = 0M;
                        decimal quantity2 = 0M;

                        if (trueRenkoCount >= 1 && trueRenkoCount < 3)
                        {
                            price1 = Math.Round(Convert.ToDecimal(firstTrueRenkoAfterTheLastFalse.Open + indicatorParameter.Parameter1 / 2), symbolPairInformation.PricePrecision);
                            price2 = Math.Round(Convert.ToDecimal(firstTrueRenkoAfterTheLastFalse.Open + indicatorParameter.Parameter1 + indicatorParameter.Parameter1 / 2), symbolPairInformation.PricePrecision);

                            quantity1 = Math.Round(Convert.ToDecimal(tradeParameter.MaximumAmountLimit * tradeParameter.MaxAmountPercentage * tradeParameter.Leverage / 2 / price1), symbolPairInformation.QuantityPrecision);
                            quantity2 = Math.Round(Convert.ToDecimal(tradeParameter.MaximumAmountLimit * tradeParameter.MaxAmountPercentage * tradeParameter.Leverage / 2 / price2), symbolPairInformation.QuantityPrecision);

                            var order1 = binanceApiService.PlaceFuturesUsdtLimitOrder(tradeParameter.SymbolPair, "Buy",
                                quantity1, "Long", price1);
                            var order2 = binanceApiService.PlaceFuturesUsdtLimitOrder(tradeParameter.SymbolPair, "Buy",
                                quantity2, "Long", price2);

                            Console.WriteLine("Order 1: " + order1.Result.Message);
                            Console.WriteLine("Order 2: " + order2.Result.Message);

                            if (order1.Result.Success && order2.Result.Success)
                            {
                                tradeFlow.PlacingOrders = false;
                                tradeFlow.FollowUpOfOpenPosition = true;
                            }
                            else
                            {
                                tradeFlow.LookingForPosition = true;
                                tradeFlow.ReadyToOpenOrder = false;
                                tradeFlow.FollowUpOfOpenPosition = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Order placement conditions have changed. Looking for position phase is started again.");
                            tradeFlow.LookingForPosition = true;
                            tradeFlow.ReadyToOpenOrder = false;
                            tradeFlow.FollowUpOfOpenPosition = false;
                        }



                        if (falseRenkoCount >= 1 && falseRenkoCount < 3)
                        {
                            price1 = Math.Round(Convert.ToDecimal(firstFalseRenkoAfterTheLastTrue.Open - indicatorParameter.Parameter1 / 2), symbolPairInformation.PricePrecision);
                            price2 = Math.Round(Convert.ToDecimal(firstFalseRenkoAfterTheLastTrue.Open - indicatorParameter.Parameter1 - indicatorParameter.Parameter1 / 2), symbolPairInformation.PricePrecision);

                            quantity1 = Math.Round(Convert.ToDecimal(tradeParameter.MaximumAmountLimit * tradeParameter.MaxAmountPercentage * tradeParameter.Leverage / 2 / price1), symbolPairInformation.QuantityPrecision, MidpointRounding.ToZero);
                            quantity2 = Math.Round(Convert.ToDecimal(tradeParameter.MaximumAmountLimit * tradeParameter.MaxAmountPercentage * tradeParameter.Leverage / 2 / price2), symbolPairInformation.QuantityPrecision, MidpointRounding.ToZero);

                            var order1 = binanceApiService.PlaceFuturesUsdtLimitOrder(tradeParameter.SymbolPair, "Sell",
                                quantity1, "Short", price1);
                            var order2 = binanceApiService.PlaceFuturesUsdtLimitOrder(tradeParameter.SymbolPair, "Sell",
                                quantity2, "Short", price2);

                            Console.WriteLine("Order 1: " + order1.Result.Message);
                            Console.WriteLine("Order 2: " + order2.Result.Message);

                            if (order1.Result.Success && order2.Result.Success)
                            {
                                tradeFlow.PlacingOrders = false;
                            }
                            else
                            {
                                tradeFlow.LookingForPosition = true;
                                tradeFlow.ReadyToOpenOrder = false;
                                tradeFlow.FollowUpOfOpenPosition = false;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Order placement conditions have changed. Looking for position phase is started again.");
                            tradeFlow.LookingForPosition = true;
                            tradeFlow.ReadyToOpenOrder = false;
                            tradeFlow.FollowUpOfOpenPosition = false;
                        }
                    }


                    Console.WriteLine("##########   Current Profit = %" + currentProfit + "   ##########");
                    iteration++;
                    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> ITERATION: {0}", iteration);

                }


            }
        }

        private static async Task<BinanceFuturesUsdtKlineEntity> UpdateOrInsertKlineData(IBinanceFuturesUsdtKlineDal binanceFuturesUsdtKlineDal,
            TradeParameterEntity tradeParameter, BinanceFuturesUsdtKlineEntity streamData)
        {
            var lastKline = (await binanceFuturesUsdtKlineDal.GetAllAsync(x =>
                x.SymbolPair == tradeParameter.SymbolPair && x.KlineInterval == tradeParameter.Interval)).LastOrDefault();

            if (lastKline.OpenTime.Date == streamData.OpenTime.Date &&
                lastKline.OpenTime.TimeOfDay == streamData.OpenTime.TimeOfDay)
            {
                streamData.Id = lastKline.Id;
                Console.ForegroundColor = ConsoleColor.DarkGreen;

                await binanceFuturesUsdtKlineDal.UpdateAsync(streamData);

                Console.WriteLine(
                    "Kline updated! => OpenTime: {4}, Open= {0}, High= {1}, Low={2}, Close= {3}, Volume= {5}, QuoteVolume= {6}",
                    streamData.Open, streamData.High, streamData.Low,
                    streamData.Close, streamData.OpenTime, streamData.BaseVolume,
                    streamData.QuoteVolume);

                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                streamData.Id = null;
                await binanceFuturesUsdtKlineDal.AddAsync(streamData);

                Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.WriteLine(
                    "Kline inserted! => OpenTime: {4}, Open= {0}, High= {1}, Low={2}, Close= {3}, Volume= {5}, QuoteVolume= {6}",
                    streamData.Open, streamData.High, streamData.Low,
                    streamData.Close, streamData.OpenTime, streamData.BaseVolume,
                    streamData.QuoteVolume);

                Console.ForegroundColor = ConsoleColor.White;
            }

            return lastKline;
        }
    }
}
