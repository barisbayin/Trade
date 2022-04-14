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
using Binance.Net.Interfaces.SubClients.Futures;
using Binance.Net.Objects;
using Binance.Net.Objects.Futures.FuturesData;
using CryptoExchange.Net.Authentication;
using DataAccess.Abstract;
using Entity.Concrete.Entities;
using Microsoft.EntityFrameworkCore.Internal;
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

            Console.WindowWidth = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["ConsoleWindowWidth"]);
            Console.WindowHeight = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["ConsoleWindowHeight"]);



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
                return;

            }

            var tradeParameter = (await tradeParameterService.GetTradeParameterEntityByIdAsync(tradeFlow.TradeParameterId)).Data;

            var indicatorParameter = (await indicatorParameterService.GetIndicatorParameterEntityByIdAsync(tradeParameter.IndicatorParameterId)).Data;

            var apiInformation = apiInformationService.GetDecryptedApiInformationById(tradeParameter.ApiInformationId).Data;

            BinanceFuturesOrder binanceFuturesOrder1 = new BinanceFuturesOrder();
            BinanceFuturesOrder binanceFuturesOrder2 = new BinanceFuturesOrder();
            BinancePositionDetailsUsdt binancePositionDetailsUsdt = new BinancePositionDetailsUsdt();


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

            var accountInfo = (await binanceApiService.GetFuturesUsdtAccountInformationAsync()).Data;


            //if (accountInfo.AvailableBalance < tradeParameter.MaximumBalanceLimit)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;

            //    Console.WriteLine("Available Balance: {0}, Maximum Balance For This Trade: {1}", accountInfo.AvailableBalance, tradeParameter.MaximumBalanceLimit);
            //    Console.WriteLine("The available balance is less than the maximum balance selected for this trade. Please increase balance or decrease maximum trade balance limit.");

            //    Console.ReadLine();
            //    return;
            //}


            Console.WriteLine("Available Balance: {0}, Maximum Balance For This Trade: {1}", accountInfo.AvailableBalance, tradeParameter.MaximumBalanceLimit);

            var leverageSet = await binanceApiService.SetLeverageForFuturesUsdtSymbolPairAsync(tradeParameter.SymbolPair, tradeParameter.Leverage);

            Console.WriteLine(leverageSet.Message);

            var marginTypeSet = await binanceApiService.SetMarginTypeForFuturesUsdtSymbolPairAsync(tradeParameter.SymbolPair, tradeParameter.MarginType);

            Console.WriteLine(marginTypeSet.Message);

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
            decimal stoplossPrice = 0;

            while (tradeFlow.InUse == true)
            {
                int trueRenkoCount = -1;
                int falseRenkoCount = -1;

                Console.ForegroundColor = ConsoleColor.White;

                Thread.Sleep(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["TimePeriod"]));


                if (streamData.Open != 0)
                {
                    Console.WriteLine("UTC Time: {0}", DateTime.UtcNow);

                    var lastKline = await UpdateOrInsertKlineData(binanceFuturesUsdtKlineDal, tradeParameter, streamData);

                    var renkoResults = indicatorService.GetFuturesUsdtRenkoBricks(tradeParameter.SymbolPair, tradeParameter.Interval, tradeParameter.IndicatorParameterId).Data;

                    lastRenkoBrick = renkoResults.LastOrDefault();




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
                                Console.WriteLine("Current PRICE/IN Brick:  OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}, Price In BrickNumber: {4}", streamData.OpenTime, streamData.Open, streamData.Close, lastRenkoBrick.IsUp, trueRenkoCount + 1);

                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("Current COMPLETED Brick: OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}, BrickNumber: {4}", lastRenkoBrick.Date, lastRenkoBrick.Open, lastRenkoBrick.Close, lastRenkoBrick.IsUp, trueRenkoCount);

                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("First TRUE Brick:        OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}", firstTrueRenkoAfterTheLastFalse.Date, firstTrueRenkoAfterTheLastFalse.Open, firstTrueRenkoAfterTheLastFalse.Close, firstTrueRenkoAfterTheLastFalse.IsUp);

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Last FALSE Brick:        OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}", lastFalseRenkoBrick.Date, lastFalseRenkoBrick.Open, lastFalseRenkoBrick.Close, lastFalseRenkoBrick.IsUp);

                                Console.ForegroundColor = ConsoleColor.White;

                                Console.WriteLine("============================================================================================================================================================");

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
                                Console.WriteLine("Current PRICE/IN Brick:  OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}, Price In BrickNumber: {4}", streamData.OpenTime, streamData.Open, streamData.Close, lastRenkoBrick.IsUp, falseRenkoCount + 1);

                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("Current COMPLETED Brick: OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}, BrickNumber: {4}", lastRenkoBrick.Date, lastRenkoBrick.Open, lastRenkoBrick.Close, lastRenkoBrick.IsUp, falseRenkoCount);

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("First FALSE Brick:       OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}", firstFalseRenkoAfterTheLastTrue.Date, firstFalseRenkoAfterTheLastTrue.Open, firstFalseRenkoAfterTheLastTrue.Close, firstFalseRenkoAfterTheLastTrue.IsUp);

                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Last TRUE Brick:         OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}", lastTrueRenkoBrick.Date, lastTrueRenkoBrick.Open, lastTrueRenkoBrick.Close, lastTrueRenkoBrick.IsUp);

                                Console.ForegroundColor = ConsoleColor.White;

                                Console.WriteLine("============================================================================================================================================================");

                                break;
                            }
                    }


                    if (tradeFlow.LookingForPosition == true && tradeFlow.PlacingOrders == false && tradeFlow.FollowUpOfOpenPosition == false)
                    {
                        Console.WriteLine("Trade Status: LOOKING FOR POSITION!");

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
                        }

                    }

                    if (tradeFlow.PlacingOrders == true && tradeFlow.FollowUpOfOpenPosition == false)
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

                            quantity1 = Math.Round(Convert.ToDecimal(tradeParameter.MaximumBalanceLimit * tradeParameter.MaxBalancePercentage * tradeParameter.Leverage / 2 / price1), symbolPairInformation.QuantityPrecision);
                            quantity2 = Math.Round(Convert.ToDecimal(tradeParameter.MaximumBalanceLimit * tradeParameter.MaxBalancePercentage * tradeParameter.Leverage / 2 / price2), symbolPairInformation.QuantityPrecision);

                            var order1 = await binanceApiService.PlaceFuturesUsdtLimitOrderAsync(tradeParameter.SymbolPair, "Buy",
                                quantity1, "Long", price1);
                            var order2 = await binanceApiService.PlaceFuturesUsdtLimitOrderAsync(tradeParameter.SymbolPair, "Buy",
                                quantity2, "Long", price2);


                            Console.WriteLine("Order 1: " + order1.Message);
                            Console.WriteLine("Order 2: " + order2.Message);

                            Console.WriteLine("Placed orders controlling...");

                            var checkOrder1 = (await binanceApiService.GetFuturesUsdtOrderBySymbolPairAndOrderIdAsync(tradeParameter.SymbolPair, order1.Data.OrderId));

                            var checkOrder2 =
                                (await binanceApiService.GetFuturesUsdtOrderBySymbolPairAndOrderIdAsync(
                                    tradeParameter.SymbolPair, binanceFuturesOrder2.OrderId));

                            if (checkOrder1.Success && checkOrder2.Success)
                            {
                                binanceFuturesOrder1 = checkOrder1.Data;
                                binanceFuturesOrder2 = checkOrder2.Data;

                                Console.WriteLine("Placed Orders Control Result => ORDER ID-1: {0}, ORDER ID-2: {1}", binanceFuturesOrder1.OrderId, binanceFuturesOrder2.OrderId);
                            }


                            if (order1.Success && order2.Success && checkOrder1.Success && checkOrder1.Success)
                            {
                                tradeFlow.PlacingOrders = false;
                                tradeFlow.OrdersStartedToFill = true;
                            }
                            else
                            {
                                tradeFlow.PlacingOrders = false;
                                tradeFlow.LookingForPosition = true;
                            }
                        }



                        if (falseRenkoCount >= 1 && falseRenkoCount < 3)
                        {
                            price1 = Math.Round(Convert.ToDecimal(firstFalseRenkoAfterTheLastTrue.Open - indicatorParameter.Parameter1 / 2), symbolPairInformation.PricePrecision);
                            price2 = Math.Round(Convert.ToDecimal(firstFalseRenkoAfterTheLastTrue.Open - indicatorParameter.Parameter1 - indicatorParameter.Parameter1 / 2), symbolPairInformation.PricePrecision);

                            quantity1 = Math.Round(Convert.ToDecimal(tradeParameter.MaximumBalanceLimit * tradeParameter.MaxBalancePercentage * tradeParameter.Leverage / 2 / price1), symbolPairInformation.QuantityPrecision, MidpointRounding.ToZero);
                            quantity2 = Math.Round(Convert.ToDecimal(tradeParameter.MaximumBalanceLimit * tradeParameter.MaxBalancePercentage * tradeParameter.Leverage / 2 / price2), symbolPairInformation.QuantityPrecision, MidpointRounding.ToZero);

                            var order1 = await binanceApiService.PlaceFuturesUsdtLimitOrderAsync(tradeParameter.SymbolPair, "Sell",
                                quantity1, "Short", price1);
                            var order2 = await binanceApiService.PlaceFuturesUsdtLimitOrderAsync(tradeParameter.SymbolPair, "Sell",
                                quantity2, "Short", price2);

                            Console.WriteLine("Order 1: " + order1.Message);
                            Console.WriteLine("Order 2: " + order2.Message);

                            Console.WriteLine("Placed orders controlling...");

                            var checkOrder1 = (await binanceApiService.GetFuturesUsdtOrderBySymbolPairAndOrderIdAsync(tradeParameter.SymbolPair, order1.Data.OrderId));

                            var checkOrder2 =
                                (await binanceApiService.GetFuturesUsdtOrderBySymbolPairAndOrderIdAsync(
                                    tradeParameter.SymbolPair, binanceFuturesOrder2.OrderId));

                            if (checkOrder1.Success && checkOrder2.Success)
                            {
                                binanceFuturesOrder1 = checkOrder1.Data;
                                binanceFuturesOrder2 = checkOrder2.Data;

                                Console.WriteLine("Placed Orders Control Result => ORDER ID-1: {0}, ORDER ID-2: {1}", binanceFuturesOrder1.OrderId, binanceFuturesOrder2.OrderId);
                            }


                            if (order1.Success && order2.Success && checkOrder1.Success && checkOrder1.Success)
                            {
                                tradeFlow.PlacingOrders = false;
                                tradeFlow.OrdersStartedToFill = true;
                            }
                            else
                            {
                                tradeFlow.PlacingOrders = false;
                                tradeFlow.LookingForPosition = true;
                            }
                        }
                    }

                    if (tradeFlow.OrdersStartedToFill == true)
                    {
                        Console.WriteLine("Trade Status: CONTROLLING THE PLACED ORDERS TO FILL!");

                        binanceFuturesOrder1 =
                            (await binanceApiService.GetFuturesUsdtOrderBySymbolPairAndOrderIdAsync(
                                tradeParameter.SymbolPair, binanceFuturesOrder1.OrderId)).Data;
                        binanceFuturesOrder2 =
                            (await binanceApiService.GetFuturesUsdtOrderBySymbolPairAndOrderIdAsync(
                                tradeParameter.SymbolPair, binanceFuturesOrder2.OrderId)).Data;

                        Console.WriteLine("Order Id: {0}, SymbolPair: {1}, Price: {2}, Quantity: {3}, Filled Quantity: {4}, Status: {5}", binanceFuturesOrder1.OrderId, binanceFuturesOrder1.Symbol, binanceFuturesOrder1.Price, binanceFuturesOrder1.Quantity, binanceFuturesOrder1.QuantityFilled, binanceFuturesOrder2.Status.ToString());
                        Console.WriteLine("Order Id: {0}, SymbolPair: {1}, Price: {2}, Quantity: {3}, Filled Quantity: {4}, Status: {5}", binanceFuturesOrder2.OrderId, binanceFuturesOrder2.Symbol, binanceFuturesOrder2.Price, binanceFuturesOrder2.Quantity, binanceFuturesOrder2.QuantityFilled, binanceFuturesOrder2.Status.ToString());



                        if (binanceFuturesOrder1.Status == OrderStatus.Filled && binanceFuturesOrder2.Status == OrderStatus.Filled)
                        {
                            tradeFlow.OrdersStartedToFill = false;
                            tradeFlow.FollowUpOfOpenPosition = true;
                            Console.WriteLine("All orders filled! Let's follow the position!");

                        }

                        if (trueRenkoCount > 4)
                        {
                            var canceledAllOrders = await binanceApiService.CancelAllFuturesUsdtLimitOrdersBySymbolPairAsync(tradeParameter.SymbolPair);

                            if (canceledAllOrders.Success)
                            {
                                Console.WriteLine("Number of TRUE bricks exceeded 5. Partially filled orders cancelling: " + canceledAllOrders.Message);
                                tradeFlow.OrdersStartedToFill = false;
                                tradeFlow.FollowUpOfOpenPosition = true;
                            }
                            else
                            {
                                Console.WriteLine("An error occurred while cancelling partially filled orders. Please control your orders manually!");
                                Console.WriteLine("Remote data message: " + canceledAllOrders.Message);
                            }

                        }

                        if (falseRenkoCount > 4)
                        {
                            var canceledAllOrders = await binanceApiService.CancelAllFuturesUsdtLimitOrdersBySymbolPairAsync(tradeParameter.SymbolPair);

                            if (canceledAllOrders.Success)
                            {
                                Console.WriteLine("Number of FALSE bricks exceeded 5. Partially filled orders cancelling: " + canceledAllOrders.Message);
                                tradeFlow.OrdersStartedToFill = false;
                                tradeFlow.FollowUpOfOpenPosition = true;
                            }
                            else
                            {
                                Console.WriteLine("An error occurred while cancelling partially filled orders. Please control your orders manually!");
                                Console.WriteLine("Remote data message: " + canceledAllOrders.Message);
                            }
                        }

                    }

                    if (tradeFlow.FollowUpOfOpenPosition == true)
                    {
                        decimal estimatedProfit = 0;

                        Console.WriteLine("Trade Status: FOLLOWING OPEN POSITION!");

                        var binancePositionDetailsUsdtResult =
                            await binanceApiService.GetFuturesUsdtPositionDetailsBySymbolPairAsync(tradeParameter.SymbolPair);

                        Console.WriteLine(binancePositionDetailsUsdtResult.Message);

                        binancePositionDetailsUsdt = binancePositionDetailsUsdtResult.Data;

                        var calculatedEntryPrice =
                            (binanceFuturesOrder1.AvgPrice * binanceFuturesOrder1.QuantityFilled +
                             binanceFuturesOrder2.AvgPrice * binanceFuturesOrder2.QuantityFilled) /
                            (binanceFuturesOrder1.QuantityFilled + binanceFuturesOrder2.QuantityFilled);

                        if (binancePositionDetailsUsdt.PositionSide == PositionSide.Long)
                        {
                            stoplossPrice = Math.Round(Convert.ToDecimal(calculatedEntryPrice - calculatedEntryPrice * tradeParameter.StopLossPercent));
                        }

                        if (binancePositionDetailsUsdt.PositionSide == PositionSide.Short)
                        {
                            stoplossPrice = Math.Round(Convert.ToDecimal(calculatedEntryPrice + calculatedEntryPrice * tradeParameter.StopLossPercent));
                        }

                        Console.WriteLine("Stoploss Percent: {0} , Calculated Stoploss Price: {1}", tradeParameter.StopLossPercent, stoplossPrice);

                        if (binancePositionDetailsUsdt.PositionSide == PositionSide.Long && streamData.Close <= stoplossPrice)
                        {
                            Console.WriteLine("The price fell below the stoploss price. Position will be stop.");

                            var stopOrder = await binanceApiService.CloseFuturesUsdtPositionByMarketOrderAsync(tradeParameter.SymbolPair, "Sell", Math.Round(Convert.ToDecimal(binanceFuturesOrder1.QuantityFilled + binanceFuturesOrder2.QuantityFilled), symbolPairInformation.QuantityPrecision), "Long");

                            if (stopOrder.Success)
                            {
                                Console.WriteLine("Position is STOPPED: " + stopOrder.Message);
                                tradeFlow.FollowUpOfOpenPosition = false;
                                tradeFlow.LookingForPosition = true;
                            }

                        }

                        if (binancePositionDetailsUsdt.PositionSide == PositionSide.Short && streamData.Close >= stoplossPrice)
                        {
                            Console.WriteLine("The price fell below the stoploss price. Position will be stop.");

                            var stopOrder = await binanceApiService.CloseFuturesUsdtPositionByMarketOrderAsync(tradeParameter.SymbolPair, "Buy", Math.Round(Convert.ToDecimal(binanceFuturesOrder1.QuantityFilled + binanceFuturesOrder2.QuantityFilled), symbolPairInformation.QuantityPrecision), "Short");

                            if (stopOrder.Success)
                            {
                                Console.WriteLine("Position is STOPPED: " + stopOrder.Message);
                                tradeFlow.FollowUpOfOpenPosition = false;
                                tradeFlow.LookingForPosition = true;
                            }

                        }


                    }


                    Console.WriteLine("##########   Estimated Profit = %" + binancePositionDetailsUsdt.UnrealizedPnl + "   ##########");
                    iteration++;
                    Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> ITERATION: {0}", iteration);

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
