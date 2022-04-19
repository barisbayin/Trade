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
using CryptoExchange.Net.Objects;
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


            BinancePositionDetailsUsdt binancePositionDetailsUsdt = new BinancePositionDetailsUsdt();
            List<BinanceFuturesPlacedOrder> binanceFuturesPlacedOrders = new List<BinanceFuturesPlacedOrder>();


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


            if (accountInfo.AvailableBalance < tradeParameter.MaximumBalanceLimit)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Available Balance: {0}, Maximum Balance For This Trade: {1}", accountInfo.AvailableBalance, tradeParameter.MaximumBalanceLimit);
                Console.WriteLine("The available balance is less than the maximum balance selected for this trade. \nPlease increase balance or decrease maximum trade balance limit.");

                Console.ReadLine();
                return;
            }


            Console.WriteLine("Available Balance: {0}, Maximum Balance For This Trade: {1}", accountInfo.AvailableBalance, tradeParameter.MaximumBalanceLimit);

            var leverageSet = await binanceApiService.SetLeverageForFuturesUsdtSymbolPairAsync(tradeParameter.SymbolPair, tradeParameter.Leverage);

            Console.WriteLine(leverageSet.Message);

            var marginTypeSet = await binanceApiService.SetMarginTypeForFuturesUsdtSymbolPairAsync(tradeParameter.SymbolPair, tradeParameter.MarginType);

            Console.WriteLine(marginTypeSet.Message);

            int calculatedPricePrecision = BitConverter.GetBytes(decimal.GetBits(symbolPairInformation.PriceFilterTickSize / 1.000000000000000000000000000000000m)[3])[2];



            #endregion





            #region Preparing For Trade

            await binanceExchangeInformationService.AddFuturesUsdtSymbolInformationAsync();

            //await tradeFlowService.UpdateTradeFlowAsync(tradeFlow);


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

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~  ALL CONTROLS DONE! LET'S START TRADE!   ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            tradeFlow.TradeStarted = true;
            tradeFlow.TradeStartTime = DateTime.Now;
            //await tradeFlowService.UpdateTradeFlowAsync(tradeFlow);

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
                                firstTrueRenkoAfterTheLastFalse = renkoResults.FirstOrDefault(x => x.Id == lastFalseRenkoBrick.Id + 1);

                                trueRenkoCount = Convert.ToInt32(lastRenkoBrick.Id) - Convert.ToInt32(lastFalseRenkoBrick.Id);

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
                                firstFalseRenkoAfterTheLastTrue = renkoResults.FirstOrDefault(x => x.Id == lastTrueRenkoBrick.Id + 1);

                                falseRenkoCount = Convert.ToInt32(lastRenkoBrick.Id) - Convert.ToInt32(lastTrueRenkoBrick.Id);

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


                    if (tradeFlow.LookingForPosition == true && tradeFlow.PlacingOrders == false && tradeFlow.TrackingOpenPosition == false)
                    {
                        binanceFuturesPlacedOrders.Clear();

                        Console.WriteLine("Trade Status: LOOKING FOR POSITION!");

                        if (trueRenkoCount >= 1 && trueRenkoCount <= tradeParameter.OrderRangeBrickQuantity)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("PRICE IS IN LONG POSITION ORDER ZONE: {0} - {1}", firstTrueRenkoAfterTheLastFalse.Open, firstTrueRenkoAfterTheLastFalse.Open + indicatorParameter.Parameter1 * tradeParameter.OrderRangeBrickQuantity);

                            tradeFlow.LookingForPosition = false;
                            tradeFlow.PlacingOrders = true;
                        }
                        else
                        {
                            tradeFlow.LookingForPosition = true;
                        }

                        if (falseRenkoCount >= 1 && falseRenkoCount <= tradeParameter.OrderRangeBrickQuantity)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("PRICE IS IN SHORT POSITION ORDER ZONE: {0} - {1}", firstFalseRenkoAfterTheLastTrue.Open, firstFalseRenkoAfterTheLastTrue.Open - indicatorParameter.Parameter1 * tradeParameter.OrderRangeBrickQuantity);

                            tradeFlow.LookingForPosition = false;
                            tradeFlow.PlacingOrders = true;
                        }
                        else
                        {
                            tradeFlow.LookingForPosition = true;
                        }

                    }

                    if (tradeFlow.PlacingOrders == true && tradeFlow.TrackingOpenPosition == false)
                    {
                        Console.WriteLine("Trade Status: PLACING ORDERS!");


                        if (trueRenkoCount >= 1 && trueRenkoCount <= tradeParameter.OrderRangeBrickQuantity)
                        {
                            var orderQuantityCheck =
                                (tradeParameter.MaximumBalanceLimit * tradeParameter.MaxBalancePercentage *
                                    tradeParameter.Leverage / 100) /
                                (firstTrueRenkoAfterTheLastFalse.Open + indicatorParameter.Parameter1 *
                                    tradeParameter.OrderRangeBrickQuantity) * tradeParameter.OrderQuantity * symbolPairInformation.LotSizeFilterMinQuantity;

                            if (orderQuantityCheck <= 0)
                            {
                                Console.WriteLine("Balance is not enough for {0} orders. Order count set 1 ", tradeParameter.OrderQuantity);
                                tradeParameter.OrderQuantity = 1;
                            }


                            var orders = await binanceApiService.PlaceFuturesUsdtMultipleLimitOrdersByPriceCalculationMethodAsync(
                                tradeParameter.SymbolPair, "Buy", "Long", tradeParameter.MaximumBalanceLimit,
                                tradeParameter.MaxBalancePercentage, tradeParameter.Leverage,
                                tradeParameter.OrderQuantity, firstTrueRenkoAfterTheLastFalse.Open, tradeParameter.PriceCalculationMethod,
                                Convert.ToDecimal(indicatorParameter.Parameter1), tradeParameter.OrderRangeBrickQuantity,
                                calculatedPricePrecision, symbolPairInformation.QuantityPrecision);





                            if (orders.Data != null && orders.Success)
                            {

                                int i = 1;

                                foreach (var order in orders.Data)
                                {
                                    binanceFuturesPlacedOrders.Add(order.Data);

                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine(
                                        "Order {0}: SymbolPair: {1} | Price/AvgPrice: {2}/{3} | Quantity/QuantityFilled {4}/{5} \nSide/PositionSide: {6}/{7} | OrderId: {8} | Status: {9}",
                                        i, order.Data.Symbol, order.Data.Price, order.Data.AvgPrice, order.Data.Quantity,
                                        order.Data.QuantityFilled, order.Data.Side, order.Data.PositionSide,
                                        order.Data.OrderId, order.Data.Status);
                                    i++;
                                }

                                Console.ForegroundColor = ConsoleColor.White;

                                Console.WriteLine("Placed orders are controlling...");

                                int j = 1;

                                var controlResults = new List<string>();

                                foreach (var order in orders.Data)
                                {
                                    Thread.Sleep(500);

                                    var checkedOrder = (await binanceApiService.GetFuturesUsdtOrderBySymbolPairAndOrderIdAsync(tradeParameter.SymbolPair, order.Data.OrderId));

                                    if (checkedOrder.Data != null && checkedOrder.Success)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine(
                                            "Placed Order-{0} Control Result=> OrderId: {8} | Status: {9} | SymbolPair: {1} \nPrice/AvgPrice: {2}/{3} | Quantity/QuantityFilled {4}/{5} | Side/PositionSide: {6}/{7}",
                                            j, checkedOrder.Data.Symbol, checkedOrder.Data.Price, checkedOrder.Data.AvgPrice, checkedOrder.Data.Quantity,
                                            checkedOrder.Data.QuantityFilled, checkedOrder.Data.Side, checkedOrder.Data.PositionSide,
                                            checkedOrder.Data.OrderId, checkedOrder.Data.Status);
                                        controlResults.Add("Success");
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("An error occurred while checking Placed Order-{0} Control Result=> {1}", j, checkedOrder.Message);
                                        controlResults.Add("Error");
                                    }
                                    
                                }

                                var controlDecision = controlResults.Any(x => x == "Error");

                                if (controlDecision == false)
                                {
                                    controlResults.Clear();
                                    tradeFlow.PlacingOrders = false;
                                    tradeFlow.OrdersStartedToFill = true;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("{0} problem/s with placed orders. Please check manually.", controlResults.Count(x => x == "Error"));
                                    tradeFlow.PlacingOrders = false;
                                    tradeFlow.LookingForPosition = true;
                                }


                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("There are problems with placed orders. Order data looks null. Please check manually. Message: {0}", orders.Message);
                                int i = 1;
                                foreach (var data in orders.Data)
                                {
                                    Console.WriteLine("Order-{0} :" + data.Error.Code + ": " + data.Error.Message, i);
                                    i++;
                                }
                                tradeFlow.PlacingOrders = false;
                                tradeFlow.LookingForPosition = true;

                            }
                            Console.ForegroundColor = ConsoleColor.White;
                        }



                        if (falseRenkoCount >= 1 && falseRenkoCount <= tradeParameter.OrderRangeBrickQuantity)
                        {
                            var orderQuantityCheck =
                                (tradeParameter.MaximumBalanceLimit * tradeParameter.MaxBalancePercentage *
                                    tradeParameter.Leverage / 100) /
                                (firstFalseRenkoAfterTheLastTrue.Open + indicatorParameter.Parameter1 *
                                    tradeParameter.OrderRangeBrickQuantity) * tradeParameter.OrderQuantity * symbolPairInformation.LotSizeFilterMinQuantity;

                            if (orderQuantityCheck <= 0)
                            {
                                Console.WriteLine("Balance is not enough for {0} orders. Order count set 1 ", tradeParameter.OrderQuantity);
                                tradeParameter.OrderQuantity = 1;
                            }

                            var orders = await binanceApiService.PlaceFuturesUsdtMultipleLimitOrdersByPriceCalculationMethodAsync(
                                tradeParameter.SymbolPair, "Sell", "Short", tradeParameter.MaximumBalanceLimit,
                                tradeParameter.MaxBalancePercentage, tradeParameter.Leverage,
                                tradeParameter.OrderQuantity, firstFalseRenkoAfterTheLastTrue.Open, tradeParameter.PriceCalculationMethod,
                                Convert.ToDecimal(indicatorParameter.Parameter1), tradeParameter.OrderRangeBrickQuantity,
                                calculatedPricePrecision, symbolPairInformation.QuantityPrecision);



                            if (orders.Data != null && orders.Success)
                            {

                                int i = 1;

                                foreach (var order in orders.Data)
                                {
                                    binanceFuturesPlacedOrders.Add(order.Data);

                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine(
                                        "Order {0}: SymbolPair: {1} | Price/AvgPrice: {2}/{3} | Quantity/QuantityFilled {4}/{5} \nSide/PositionSide: {6}/{7} | OrderId: {8} | Status: {9}",
                                        i, order.Data.Symbol, order.Data.Price, order.Data.AvgPrice, order.Data.Quantity,
                                        order.Data.QuantityFilled, order.Data.Side, order.Data.PositionSide,
                                        order.Data.OrderId, order.Data.Status);
                                    i++;
                                }

                                Console.ForegroundColor = ConsoleColor.White;

                                Console.WriteLine("Placed orders are controlling...");

                                int j = 1;

                                var controlResults = new List<string>();

                                foreach (var order in orders.Data)
                                {
                                    Thread.Sleep(500);

                                    var checkedOrder = (await binanceApiService.GetFuturesUsdtOrderBySymbolPairAndOrderIdAsync(tradeParameter.SymbolPair, order.Data.OrderId));

                                    if (checkedOrder.Data != null && checkedOrder.Success)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine(
                                            "Placed Order-{0} Control Result=> OrderId: {8} | Status: {9} | SymbolPair: {1} \nPrice/AvgPrice: {2}/{3} | Quantity/QuantityFilled {4}/{5} | Side/PositionSide: {6}/{7}",
                                            j, checkedOrder.Data.Symbol, checkedOrder.Data.Price, checkedOrder.Data.AvgPrice, checkedOrder.Data.Quantity,
                                            checkedOrder.Data.QuantityFilled, checkedOrder.Data.Side, checkedOrder.Data.PositionSide,
                                            checkedOrder.Data.OrderId, checkedOrder.Data.Status);
                                        controlResults.Add("Success");
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("An error occurred while checking Placed Order-{0} Control Result=> {1}", j, checkedOrder.Message);
                                        controlResults.Add("Error");
                                    }

                                }

                                var controlDecision = controlResults.Any(x => x == "Success");

                                if (controlDecision == true)
                                {
                                    controlResults.Clear();
                                    tradeFlow.PlacingOrders = false;
                                    tradeFlow.OrdersStartedToFill = true;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("There are problems with placed orders. Please check manually.");
                                    tradeFlow.PlacingOrders = false;
                                    tradeFlow.LookingForPosition = true;
                                }


                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;

                                Console.WriteLine("There are problems with placed orders. Order data looks null. Please check manually. Message: {0}", orders.Message);
                                int i = 1;
                                foreach (var data in orders.Data)
                                {
                                    Console.WriteLine("Order-{0} :" + data.Error.Code + ": " + data.Error.Message, i);
                                    i++;
                                }
                                tradeFlow.PlacingOrders = false;
                                tradeFlow.LookingForPosition = true;

                            }
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }

                    if (tradeFlow.OrdersStartedToFill == true)
                    {
                        Console.WriteLine("Trade Status: CONTROLLING THE PLACED ORDERS TO FILL!");

                        int i = 1;

                        var controlResults = new List<string>();

                        foreach (var placedOrder in binanceFuturesPlacedOrders)
                        {
                            var checkedOrder = (await binanceApiService.GetFuturesUsdtOrderBySymbolPairAndOrderIdAsync(tradeParameter.SymbolPair, placedOrder.OrderId));

                            if (checkedOrder.Data != null && checkedOrder.Data.Status == OrderStatus.Filled)
                            {
                                Console.WriteLine(
                                    "Placed Order-{0} Control Result=> OrderId: {8} | Status: {9} | SymbolPair: {1} | Price/AvgPrice: {2}/{3} \n                               Quantity/QuantityFilled {4}/{5} | Side/PositionSide: {6}/{7}",
                                    i, checkedOrder.Data.Symbol, checkedOrder.Data.Price, checkedOrder.Data.AvgPrice, checkedOrder.Data.Quantity,
                                    checkedOrder.Data.QuantityFilled, checkedOrder.Data.Side, checkedOrder.Data.PositionSide,
                                    checkedOrder.Data.OrderId, checkedOrder.Data.Status);
                                controlResults.Add("Filled");
                                i++;
                            }
                            else
                            {
                                Console.WriteLine("{0}. Order not filled yet. Control Result=> {1}", i, checkedOrder.Message);
                                controlResults.Add("NotFilled");
                                i++;
                            }

                        }


                        var controlDecision = controlResults.Any(x => x == "NotFilled");

                        if (controlDecision == false)
                        {
                            controlResults.Clear();
                            Console.WriteLine("All orders filled! Let's follow the position!");
                            tradeFlow.OrdersStartedToFill = false;
                            tradeFlow.TrackingOpenPosition = true;

                        }
                        else
                        {
                            Console.WriteLine("{0} order/s not filled. Waiting them to fill.", controlResults.Count(x => x == "NotFilled"));
                            controlResults.Clear();
                        }


                        if (trueRenkoCount > tradeParameter.CancelOrdersAfterBrick)
                        {
                            var canceledAllOrders = await binanceApiService.CancelAllFuturesUsdtLimitOrdersBySymbolPairAsync(tradeParameter.SymbolPair);

                            if (canceledAllOrders.Success)
                            {
                                Console.WriteLine("Number of TRUE bricks exceeded {0}. Partially or not filled orders cancelling: " + canceledAllOrders.Message, tradeParameter.CancelOrdersAfterBrick);
                                tradeFlow.OrdersStartedToFill = false;
                                tradeFlow.TrackingOpenPosition = true;
                            }
                            else
                            {
                                Console.WriteLine("An error occurred while cancelling partially filled orders. Please control your orders manually!");
                                Console.WriteLine("Remote data message: " + canceledAllOrders.Message);
                            }

                        }

                        if (falseRenkoCount > tradeParameter.CancelOrdersAfterBrick)
                        {
                            var canceledAllOrders = await binanceApiService.CancelAllFuturesUsdtLimitOrdersBySymbolPairAsync(tradeParameter.SymbolPair);

                            if (canceledAllOrders.Success)
                            {
                                Console.WriteLine("Number of FALSE bricks exceeded {0}. Partially or not filled orders cancelling: " + canceledAllOrders.Message, tradeParameter.CancelOrdersAfterBrick);
                                tradeFlow.OrdersStartedToFill = false;
                                tradeFlow.TrackingOpenPosition = true;
                            }
                            else
                            {
                                Console.WriteLine("An error occurred while cancelling partially filled orders. Please control your orders manually!");
                                Console.WriteLine("Remote data message: " + canceledAllOrders.Message);
                            }
                        }

                    }

                    if (tradeFlow.TrackingOpenPosition == true)
                    {
                        var estimatedProfit = 0M;

                        Console.WriteLine("Trade Status: TRACKING OPEN POSITION!");

                        var binancePositionDetailsUsdtResult = await binanceApiService.GetFuturesUsdtPositionDetailsBySymbolPairAsync(tradeParameter.SymbolPair);

                        Console.WriteLine(binancePositionDetailsUsdtResult.Message);

                        binancePositionDetailsUsdt = binancePositionDetailsUsdtResult.Data;


                        var totalPositionSize = 0M;
                        var totalFilledQuantity = 0M;

                        foreach (var placedOrder in binanceFuturesPlacedOrders)
                        {

                            var perFilledOrderSize = placedOrder.AvgPrice * placedOrder.QuantityFilled;
                            var perFilledQuantity = placedOrder.QuantityFilled;

                            totalPositionSize = totalPositionSize + perFilledOrderSize;
                            totalFilledQuantity = totalFilledQuantity + perFilledQuantity;

                        }

                        var calculatedEntryPrice = totalPositionSize / totalFilledQuantity;



                        if (binancePositionDetailsUsdt.PositionSide == PositionSide.Long)
                        {
                            stoplossPrice = Math.Round(Convert.ToDecimal(calculatedEntryPrice - calculatedEntryPrice * tradeParameter.StopLossPercent / 100));

                            Console.WriteLine("Stoploss Percent: {0} , Calculated Stoploss Price: {1}", tradeParameter.StopLossPercent, stoplossPrice);

                            if (streamData.Close <= stoplossPrice)
                            {
                                Console.WriteLine("The price fell below the stoploss price. Position will be stop.");

                                var stopOrder = await binanceApiService.CloseFuturesUsdtPositionByMarketOrderAsync(tradeParameter.SymbolPair, "Sell", Math.Round(Convert.ToDecimal(totalFilledQuantity), symbolPairInformation.QuantityPrecision), "Long");

                                if (stopOrder.Success)
                                {
                                    Console.WriteLine("Position is STOPPED: " + stopOrder.Message);
                                    tradeFlow.TrackingOpenPosition = false;
                                    tradeFlow.LookingForPosition = true;
                                }

                            }

                            if (streamData.Close > stoplossPrice)
                            {
                                if (trueRenkoCount == -1 && falseRenkoCount > -1)
                                {
                                    Console.WriteLine("Trend turns from long to short. Position will be closed!");

                                    var positionCloseOrder = await binanceApiService.CloseFuturesUsdtPositionByMarketOrderAsync(tradeParameter.SymbolPair, "Sell", Math.Round(Convert.ToDecimal(totalFilledQuantity), symbolPairInformation.QuantityPrecision), "Long");


                                    var binancePositionDetailsUsdtControl = await binanceApiService.GetFuturesUsdtPositionDetailsBySymbolPairAsync(tradeParameter.SymbolPair);

                                    if (positionCloseOrder.Success && binancePositionDetailsUsdtControl.Data == null)
                                    {
                                        tradeFlow.TrackingOpenPosition = false;
                                        tradeFlow.LookingForPosition = true;
                                    }
                                }

                            }

                            estimatedProfit = Math.Round((binancePositionDetailsUsdt.MarkPrice / calculatedEntryPrice - 1) * 100, 2);

                            Console.WriteLine("##########   Estimated Profit = %" + estimatedProfit + "   ##########");

                        }

                        if (binancePositionDetailsUsdt.PositionSide == PositionSide.Short)
                        {
                            stoplossPrice = Math.Round(Convert.ToDecimal(calculatedEntryPrice + calculatedEntryPrice * tradeParameter.StopLossPercent / 100));

                            Console.WriteLine("Stoploss Percent: {0} , Calculated Stoploss Price: {1}", tradeParameter.StopLossPercent, stoplossPrice);

                            if (streamData.Close >= stoplossPrice)
                            {
                                Console.WriteLine("The price fell below the stoploss price. Position will be stop.");

                                var stopOrder = await binanceApiService.CloseFuturesUsdtPositionByMarketOrderAsync(tradeParameter.SymbolPair, "Buy", Math.Round(Convert.ToDecimal(totalFilledQuantity), symbolPairInformation.QuantityPrecision), "Short");

                                if (stopOrder.Success)
                                {
                                    Console.WriteLine("Position is STOPPED: " + stopOrder.Message);
                                    tradeFlow.TrackingOpenPosition = false;
                                    tradeFlow.LookingForPosition = true;
                                }

                            }

                            if (streamData.Close < stoplossPrice)
                            {

                                if (falseRenkoCount == -1 && trueRenkoCount > -1)
                                {
                                    Console.WriteLine("Trend turns from short to long. Position will be closed!");

                                    var positionCloseOrder = await binanceApiService.CloseFuturesUsdtPositionByMarketOrderAsync(tradeParameter.SymbolPair, "Buy", Math.Round(Convert.ToDecimal(totalFilledQuantity), symbolPairInformation.QuantityPrecision), "Short");


                                    var binancePositionDetailsUsdtControl = await binanceApiService.GetFuturesUsdtPositionDetailsBySymbolPairAsync(tradeParameter.SymbolPair);

                                    if (positionCloseOrder.Success && binancePositionDetailsUsdtControl.Data == null)
                                    {
                                        tradeFlow.TrackingOpenPosition = false;
                                        tradeFlow.LookingForPosition = true;
                                    }
                                }




                            }

                            estimatedProfit = Math.Round((1 - binancePositionDetailsUsdt.MarkPrice / calculatedEntryPrice) * 100, 2);

                            Console.WriteLine("##########   Estimated Profit = %" + estimatedProfit + "   ##########");

                        }

                    }


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
