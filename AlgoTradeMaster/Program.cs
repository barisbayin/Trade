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
using Business.Helpers;
using Core.Utilities.Results;
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
        private class VariableObjects
        {
            public FuturesUsdtRenkoBrick LastRenkoBrick { get; set; }
            public FuturesUsdtRenkoBrick LastFalseRenkoBrick { get; set; }
            public FuturesUsdtRenkoBrick LastTrueRenkoBrick { get; set; }
            public FuturesUsdtRenkoBrick FirstTrueRenkoAfterTheLastFalse { get; set; }
            public FuturesUsdtRenkoBrick FirstFalseRenkoAfterTheLastTrue { get; set; }
            public FuturesUsdtRenkoBrick PositionEntryRenkoBrick { get; set; }

            public BinancePositionDetailsUsdt BinancePositionDetailsUsdt { get; set; }

            public List<BinanceFuturesPlacedOrder> BinanceFuturesPlacedOrders { get; set; } =
                new List<BinanceFuturesPlacedOrder>();

            public List<BinanceFuturesOrder> BinanceFuturesFilledOrders { get; set; } = new List<BinanceFuturesOrder>();
            public decimal StopLossPrice { get; set; } = 0;
            public bool PositionEntryTrigger { get; set; } = false;
            public int TrueRenkoCount { get; set; } = -1;
            public int FalseRenkoCount { get; set; } = -1;
            public int LastInIntervalTrendCount { get; set; } = -1;
            public int LastTrendBrickCount { get; set; } = -1;

        }
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

            Calculators calculators = new Calculators();

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


            #endregion

            #region Object Related Instances


            IBinanceApiService binanceApiService = new BinanceApiManager(new BinanceClient(), apiInformation.ApiKey, apiInformation.SecretKey);

            IBinanceExchangeInformationService binanceExchangeInformationService = new BinanceExchangeInformationManager(new EfBinanceFuturesUsdtSymbolDal(), binanceApiService);

            #endregion

            #region Objects2

            var symbolPairInformation = (await
                binanceExchangeInformationService.GetFuturesUsdtSymbolInformationBySymbolPairAsync(tradeParameter.SymbolPair)).Data;

            #endregion


            #region Controls & Settings

            Console.Title = "ALGOTRADEMASTER-RENKO: " + tradeParameter.SymbolPair.ToUpper() + " | " + tradeParameter.Interval.ToUpper() + " | " + indicatorParameter.KlineEndType.ToUpper() + " | " + "BRICK SIZE: " + indicatorParameter.Parameter1 + " | " + apiInformation.ApiTitle.ToUpper();

            var accountInfo = (await binanceApiService.GetFuturesUsdtAccountInformationAsync()).Data;


            //if (accountInfo.AvailableBalance < tradeParameter.MaximumBalanceLimit)
            //{
            //    Console.ForegroundColor = ConsoleColor.Red;

            //    Console.WriteLine("Available Balance: {0}, Maximum Balance For This Trade: {1}", accountInfo.AvailableBalance, tradeParameter.MaximumBalanceLimit);
            //    Console.WriteLine("The available balance is less than the maximum balance selected for this trade. \nPlease increase balance or decrease maximum trade balance limit.");

            //    Console.ReadLine();
            //    return;
            //}


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


            var result = binanceKlineService.AddFuturesUsdtKlinesToDatabaseAsync(tradeParameter.SymbolPair, new List<string> { tradeParameter.Interval });

            Console.WriteLine(result.Result.Message);

            #endregion


            var streamData = await binanceKlineWsService.GetCurrentFuturesUsdtKlineDataAsync(tradeParameter.SymbolPair, (KlineInterval)Enum.Parse(typeof(KlineInterval), tradeParameter.Interval));


            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~  ALL CONTROLS DONE! LET'S START TRADE!   ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            tradeFlow.InUse = true;
            tradeFlow.IsSelected = false;
            tradeFlow.LookingForFirstPosition = true;
            //await tradeFlowService.UpdateTradeFlowAsync(tradeFlow);

            long iteration = 0;

            var variableObjects = new VariableObjects();

            while (tradeFlow.InUse == true)
            {

                if (streamData.Open != 0)
                {
                    #region LOOKING FOR FIRST POSITION

                    while (tradeFlow.LookingForFirstPosition==true)
                    {
                        Console.WriteLine("Trade Status: LOOKING FOR FIRST POSITION!");

                        var updatedVariableObjects = await InformationUpdates(streamData, binanceFuturesUsdtKlineDal, tradeParameter, indicatorService,
                            calculators, variableObjects);

                        if (updatedVariableObjects.LastRenkoBrick.IsUp == true)
                        {
                            if (updatedVariableObjects.LastTrendBrickCount == updatedVariableObjects.LastInIntervalTrendCount && updatedVariableObjects.LastInIntervalTrendCount < tradeParameter.NumberOfBricksForEntry)
                            {
                                if (updatedVariableObjects.PositionEntryTrigger == false)
                                {
                                    Console.WriteLine("The number of position entry bricks is expected to be triggered => Number Of Trigger Bricks: {0} | Trend Brick Count: {1}", tradeParameter.NumberOfBricksForEntry, updatedVariableObjects.LastTrendBrickCount);
                                }
                                else
                                {
                                    Console.WriteLine("The number of position entry bricks triggered => Number Of Trigger Bricks: {0} | Trend Brick Count: {1}", tradeParameter.NumberOfBricksForEntry, updatedVariableObjects.LastTrendBrickCount);
                                }
                                
                            }

                            if (updatedVariableObjects.LastTrendBrickCount == updatedVariableObjects.LastInIntervalTrendCount && updatedVariableObjects.LastInIntervalTrendCount >= tradeParameter.NumberOfBricksForEntry)
                            {
                                Console.WriteLine("The number of position entry bricks triggered => Number Of Trigger Bricks: {0} | Trend Brick Count: {1}", tradeParameter.NumberOfBricksForEntry, updatedVariableObjects.LastTrendBrickCount);
                                updatedVariableObjects.PositionEntryTrigger = true;
                            }

                            if (updatedVariableObjects.PositionEntryTrigger == true && updatedVariableObjects.TrueRenkoCount >= 1 && updatedVariableObjects.TrueRenkoCount <= tradeParameter.OrderRangeBrickQuantity)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("PRICE IS IN LONG POSITION ORDER ZONE: {0} - {1}", updatedVariableObjects.FirstTrueRenkoAfterTheLastFalse.Open, updatedVariableObjects.FirstTrueRenkoAfterTheLastFalse.Open + indicatorParameter.Parameter1 * tradeParameter.OrderRangeBrickQuantity);

                                tradeFlow.LookingForFirstPosition = false;
                                tradeFlow.PlacingOrders = true;
                            }
                        }

                        if (updatedVariableObjects.LastRenkoBrick.IsUp == false)
                        {
                            if (updatedVariableObjects.LastTrendBrickCount == updatedVariableObjects.LastInIntervalTrendCount && updatedVariableObjects.LastInIntervalTrendCount < tradeParameter.NumberOfBricksForEntry)
                            {
                                Console.WriteLine("The number of position entry bricks is expected to be triggered => Number Of Trigger Bricks: {0} | Trend Brick Count: {1}", tradeParameter.NumberOfBricksForEntry, updatedVariableObjects.LastTrendBrickCount);
                                updatedVariableObjects.PositionEntryTrigger = false;
                            }

                            if (updatedVariableObjects.LastTrendBrickCount == updatedVariableObjects.LastInIntervalTrendCount && updatedVariableObjects.LastInIntervalTrendCount >= tradeParameter.NumberOfBricksForEntry)
                            {
                                Console.WriteLine("The number of position entry bricks triggered => Number Of Trigger Bricks: {0} | Trend Brick Count: {1}", tradeParameter.NumberOfBricksForEntry, updatedVariableObjects.LastTrendBrickCount);
                                updatedVariableObjects.PositionEntryTrigger = true;
                            }

                            if (updatedVariableObjects.PositionEntryTrigger == true && updatedVariableObjects.TrueRenkoCount >= 1 && updatedVariableObjects.TrueRenkoCount <= tradeParameter.OrderRangeBrickQuantity)
                            {
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("PRICE IS IN SHORT POSITION ORDER ZONE: {0} - {1}", updatedVariableObjects.FirstFalseRenkoAfterTheLastTrue.Open, updatedVariableObjects.FirstFalseRenkoAfterTheLastTrue.Open - indicatorParameter.Parameter1 * tradeParameter.OrderRangeBrickQuantity);

                                tradeFlow.LookingForFirstPosition = false;
                                tradeFlow.PlacingOrders = true;
                            }
                        }

                        iteration++;
                        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> ITERATION: {0}", iteration);

                    }

                    #endregion

                    #region LOOKING FOR A POSITION

                    while (tradeFlow.LookingForPosition == true)
                    {


                        Console.WriteLine("Trade Status: LOOKING FOR POSITION!");

                        var updatedVariableObjects = await InformationUpdates(streamData, binanceFuturesUsdtKlineDal, tradeParameter, indicatorService,
                            calculators, variableObjects);


                        if (updatedVariableObjects.BinanceFuturesPlacedOrders != null)
                        {
                            updatedVariableObjects.BinanceFuturesPlacedOrders.Clear();
                        }


                        if (updatedVariableObjects.TrueRenkoCount >= 1 && updatedVariableObjects.TrueRenkoCount <= tradeParameter.OrderRangeBrickQuantity)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("PRICE IS IN LONG POSITION ORDER ZONE: {0} - {1}", updatedVariableObjects.FirstTrueRenkoAfterTheLastFalse.Open, updatedVariableObjects.FirstTrueRenkoAfterTheLastFalse.Open + indicatorParameter.Parameter1 * tradeParameter.OrderRangeBrickQuantity);

                            tradeFlow.LookingForPosition = false;
                            tradeFlow.PlacingOrders = true;
                        }
                        else
                        {
                            tradeFlow.LookingForPosition = true;
                        }

                        if (updatedVariableObjects.FalseRenkoCount >= 1 && updatedVariableObjects.FalseRenkoCount <= tradeParameter.OrderRangeBrickQuantity)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("PRICE IS IN SHORT POSITION ORDER ZONE: {0} - {1}", updatedVariableObjects.FirstFalseRenkoAfterTheLastTrue.Open, updatedVariableObjects.FirstFalseRenkoAfterTheLastTrue.Open - indicatorParameter.Parameter1 * tradeParameter.OrderRangeBrickQuantity);

                            tradeFlow.LookingForPosition = false;
                            tradeFlow.PlacingOrders = true;
                        }
                        else
                        {
                            tradeFlow.LookingForPosition = true;
                        }

                        iteration++;
                        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> ITERATION: {0}", iteration);
                    }
                    #endregion


                    while (tradeFlow.PlacingOrders == true)
                    {
                        Console.WriteLine("Trade Status: PLACING ORDERS!");

                        var updatedVariableObjects = await InformationUpdates(streamData, binanceFuturesUsdtKlineDal, tradeParameter, indicatorService,
                            calculators, variableObjects);

                        if (updatedVariableObjects.TrueRenkoCount >= 1 && updatedVariableObjects.TrueRenkoCount <= tradeParameter.OrderRangeBrickQuantity)
                        {
                            updatedVariableObjects.PositionEntryRenkoBrick = updatedVariableObjects.FirstTrueRenkoAfterTheLastFalse;

                            var orderQuantityCheck =
                                (tradeParameter.MaximumBalanceLimit * tradeParameter.MaxBalancePercentage *
                                    tradeParameter.Leverage / 100) /
                                (updatedVariableObjects.FirstTrueRenkoAfterTheLastFalse.Open + indicatorParameter.Parameter1 *
                                    tradeParameter.OrderRangeBrickQuantity) * tradeParameter.OrderQuantity * symbolPairInformation.LotSizeFilterMinQuantity;

                            if (orderQuantityCheck <= 0)
                            {
                                Console.WriteLine("Balance is not enough for {0} orders. Order count set 1 ", tradeParameter.OrderQuantity);
                                tradeParameter.OrderQuantity = 1;
                            }


                            var orders = await binanceApiService.PlaceFuturesUsdtMultipleLimitOrdersByPriceCalculationMethodAsync(
                                tradeParameter.SymbolPair, "Buy", "Long", tradeParameter.MaximumBalanceLimit,
                                tradeParameter.MaxBalancePercentage, tradeParameter.Leverage,
                                tradeParameter.OrderQuantity, updatedVariableObjects.FirstTrueRenkoAfterTheLastFalse.Open, tradeParameter.PriceCalculationMethod,
                                Convert.ToDecimal(indicatorParameter.Parameter1), tradeParameter.OrderRangeBrickQuantity,
                                calculatedPricePrecision, symbolPairInformation.QuantityPrecision);


                            if (orders.Data != null && orders.Success)
                            {

                                int i = 1;

                                foreach (var order in orders.Data)
                                {
                                    updatedVariableObjects.BinanceFuturesPlacedOrders.Add(order.Data);

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
                                    Thread.Sleep(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["IntermediateTimePeriod"]));

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
                                        j++;
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
                                    tradeFlow.LookingForPosition = false;
                                    tradeFlow.PlacingOrders = false;
                                    tradeFlow.OrdersStartedToFill = true;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("{0} problem/s with placed orders. Please check manually.", controlResults.Count(x => x == "Error"));
                                    tradeFlow.PlacingOrders = false;
                                    tradeFlow.LookingForPosition = false;
                                    tradeFlow.OrdersStartedToFill = true;
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
                                tradeFlow.LookingForPosition = false;

                            }
                            Console.ForegroundColor = ConsoleColor.White;
                        }



                        if (updatedVariableObjects.FalseRenkoCount >= 1 && updatedVariableObjects.FalseRenkoCount <= tradeParameter.OrderRangeBrickQuantity)
                        {
                            updatedVariableObjects.PositionEntryRenkoBrick = updatedVariableObjects.FirstFalseRenkoAfterTheLastTrue;

                            var orderQuantityCheck =
                                (tradeParameter.MaximumBalanceLimit * tradeParameter.MaxBalancePercentage *
                                    tradeParameter.Leverage / 100) /
                                (updatedVariableObjects.FirstFalseRenkoAfterTheLastTrue.Open + indicatorParameter.Parameter1 *
                                    tradeParameter.OrderRangeBrickQuantity) * tradeParameter.OrderQuantity * symbolPairInformation.LotSizeFilterMinQuantity;

                            if (orderQuantityCheck <= 0)
                            {
                                Console.WriteLine("Balance is not enough for {0} orders. Order count set 1 ", tradeParameter.OrderQuantity);
                                tradeParameter.OrderQuantity = 1;
                            }

                            var orders = await binanceApiService.PlaceFuturesUsdtMultipleLimitOrdersByPriceCalculationMethodAsync(
                                tradeParameter.SymbolPair, "Sell", "Short", tradeParameter.MaximumBalanceLimit,
                                tradeParameter.MaxBalancePercentage, tradeParameter.Leverage,
                                tradeParameter.OrderQuantity, updatedVariableObjects.FirstFalseRenkoAfterTheLastTrue.Open, tradeParameter.PriceCalculationMethod,
                                Convert.ToDecimal(indicatorParameter.Parameter1), tradeParameter.OrderRangeBrickQuantity,
                                calculatedPricePrecision, symbolPairInformation.QuantityPrecision);



                            if (orders.Data != null && orders.Success)
                            {

                                int i = 1;

                                foreach (var order in orders.Data)
                                {
                                    updatedVariableObjects.BinanceFuturesPlacedOrders.Add(order.Data);

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
                                    Thread.Sleep(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["IntermediateTimePeriod"]));

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
                                        j++;
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("An error occurred while checking Placed Order-{0} Control Result=> {1}", j, checkedOrder.Message);
                                        controlResults.Add("Error");
                                    }

                                }

                                var controlDecision = controlResults.Any(x => x == "Success");

                                if (controlDecision == false)
                                {
                                    controlResults.Clear();
                                    tradeFlow.LookingForPosition = false;
                                    tradeFlow.PlacingOrders = false;
                                    tradeFlow.OrdersStartedToFill = true;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("{0} problem/s with placed orders. Please check manually.", controlResults.Count(x => x == "Error"));
                                    tradeFlow.PlacingOrders = false;
                                    tradeFlow.LookingForPosition = false;
                                    tradeFlow.OrdersStartedToFill = true;
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
                                tradeFlow.LookingForPosition = false;

                            }
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                        iteration++;
                        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> ITERATION: {0}", iteration);
                    }

                    while (tradeFlow.OrdersStartedToFill == true)
                    {
                        Console.WriteLine("Trade Status: CONTROLLING THE PLACED ORDERS TO FILL!");

                        int i = 1;

                        var updatedVariableObjects = await InformationUpdates(streamData, binanceFuturesUsdtKlineDal, tradeParameter, indicatorService,
                            calculators, variableObjects);

                        var controlResults = new List<string>();

                        foreach (var placedOrder in updatedVariableObjects.BinanceFuturesPlacedOrders)
                        {
                            Thread.Sleep(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["IntermediateTimePeriod"]));

                            var checkedOrder = (await binanceApiService.GetFuturesUsdtOrderBySymbolPairAndOrderIdAsync(tradeParameter.SymbolPair, placedOrder.OrderId));

                            if (checkedOrder.Data is { Status: OrderStatus.Filled })
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
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
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("OrderId: {0} is not filled yet. {1}", checkedOrder.Data.OrderId, checkedOrder.Message);
                                Console.WriteLine(
                                    "Placed Order-{0} Control Result=> OrderId: {8} | Status: {9} | SymbolPair: {1} | Price/AvgPrice: {2}/{3} \n                               Quantity/QuantityFilled {4}/{5} | Side/PositionSide: {6}/{7}",
                                    i, checkedOrder.Data.Symbol, checkedOrder.Data.Price, checkedOrder.Data.AvgPrice, checkedOrder.Data.Quantity,
                                    checkedOrder.Data.QuantityFilled, checkedOrder.Data.Side, checkedOrder.Data.PositionSide,
                                    checkedOrder.Data.OrderId, checkedOrder.Data.Status);
                                controlResults.Add("NotFilled");
                                i++;
                            }

                        }


                        var controlDecision = controlResults.Any(x => x == "NotFilled");

                        if (controlDecision == false)
                        {


                            foreach (var placedOrder in updatedVariableObjects.BinanceFuturesPlacedOrders)
                            {
                                var checkedOrder = (await binanceApiService.GetFuturesUsdtOrderBySymbolPairAndOrderIdAsync(tradeParameter.SymbolPair, placedOrder.OrderId));

                                if (checkedOrder.Data is { Status: OrderStatus.Filled })
                                {
                                    updatedVariableObjects.BinanceFuturesFilledOrders.Add(checkedOrder.Data);
                                }

                            }
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("All orders filled! Let's track the position!");
                            tradeFlow.OrdersStartedToFill = false;
                            tradeFlow.TrackingOpenPosition = true;

                            controlResults.Clear();

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("{0} order/s not filled. Waiting them to fill.", controlResults.Count(x => x == "NotFilled"));
                            controlResults.Clear();
                        }


                        if (updatedVariableObjects.TrueRenkoCount > tradeParameter.CancelOrdersAfterBrick && updatedVariableObjects.LastRenkoBrick.Date > updatedVariableObjects.PositionEntryRenkoBrick.Date)
                        {
                            var canceledAllOrders = await binanceApiService.CancelAllFuturesUsdtLimitOrdersBySymbolPairAsync(tradeParameter.SymbolPair);

                            if (canceledAllOrders.Success)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Number of TRUE bricks exceeded {0}. Partially or not filled orders cancelling: " + canceledAllOrders.Message, tradeParameter.CancelOrdersAfterBrick);
                                tradeFlow.OrdersStartedToFill = false;
                                tradeFlow.TrackingOpenPosition = true;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("An error occurred while cancelling partially filled orders. Please control your orders manually!");
                                Console.WriteLine("Remote data message: " + canceledAllOrders.Message);
                            }

                        }

                        if (updatedVariableObjects.FalseRenkoCount > tradeParameter.CancelOrdersAfterBrick && updatedVariableObjects.LastRenkoBrick.Date > updatedVariableObjects.PositionEntryRenkoBrick.Date)
                        {
                            var canceledAllOrders = await binanceApiService.CancelAllFuturesUsdtLimitOrdersBySymbolPairAsync(tradeParameter.SymbolPair);

                            if (canceledAllOrders.Success)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Number of FALSE bricks exceeded {0}. Partially or not filled orders cancelling: " + canceledAllOrders.Message, tradeParameter.CancelOrdersAfterBrick);
                                tradeFlow.OrdersStartedToFill = false;
                                tradeFlow.TrackingOpenPosition = true;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("An error occurred while cancelling partially filled orders. Please control your orders manually!");
                                Console.WriteLine("Remote data message: " + canceledAllOrders.Message);
                            }
                        }
                        Console.ForegroundColor = ConsoleColor.White;

                        iteration++;
                        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> ITERATION: {0}", iteration);
                    }

                    while (tradeFlow.TrackingOpenPosition == true)
                    {
                        var estimatedProfit = 0M;

                        Console.WriteLine("Trade Status: TRACKING OPEN POSITION!");

                        var updatedVariableObjects = await InformationUpdates(streamData, binanceFuturesUsdtKlineDal, tradeParameter, indicatorService,
                            calculators, variableObjects);

                        var binancePositionDetailsUsdtResult = await binanceApiService.GetFuturesUsdtPositionDetailsBySymbolPairAsync(tradeParameter.SymbolPair);

                        Console.WriteLine(binancePositionDetailsUsdtResult.Message);

                        if (binancePositionDetailsUsdtResult.Success)
                        {
                            updatedVariableObjects.BinancePositionDetailsUsdt = binancePositionDetailsUsdtResult.Data;


                            if (updatedVariableObjects.BinancePositionDetailsUsdt.PositionSide == PositionSide.Long)
                            {
                                updatedVariableObjects.StopLossPrice = Math.Round(Convert.ToDecimal(updatedVariableObjects.BinancePositionDetailsUsdt.EntryPrice - updatedVariableObjects.BinancePositionDetailsUsdt.EntryPrice * tradeParameter.StopLossPercent / 100), calculatedPricePrecision);

                                Console.WriteLine("Stoploss Percent: %{0} , Calculated Stoploss Price: {1}", tradeParameter.StopLossPercent, updatedVariableObjects.StopLossPrice);

                                if (streamData.Close <= updatedVariableObjects.StopLossPrice)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;

                                    Console.WriteLine("The price fell below the stoploss price. Position will be stop.");

                                    Thread.Sleep(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["IntermediateTimePeriod"]));

                                    var stopOrder = await binanceApiService.CloseFuturesUsdtPositionByMarketOrderAsync(tradeParameter.SymbolPair, "Sell", Math.Round(Convert.ToDecimal(updatedVariableObjects.BinancePositionDetailsUsdt.Quantity), symbolPairInformation.QuantityPrecision), "Long");


                                    if (stopOrder.Success)
                                    {
                                        var stopOrderControl =
                                            binanceApiService.GetFuturesUsdtOrderBySymbolPairAndOrderIdAsync(
                                                tradeParameter.SymbolPair, stopOrder.Data.OrderId);

                                        if (stopOrderControl.Result.Success && stopOrderControl.Result.Data.Status == OrderStatus.Filled)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkGray;
                                            Console.WriteLine("Position is STOPPED: " + stopOrder.Message);
                                            tradeFlow.TrackingOpenPosition = false;
                                            tradeFlow.LookingForPosition = true;

                                            Thread.Sleep(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["IntermediateTimePeriod"]));

                                            Console.WriteLine("Maximum balance limit is updating...");


                                            await CalculateToAddPnLToMaximumBalance(binanceApiService, tradeParameter, stopOrderControl.Result.Data, updatedVariableObjects.BinancePositionDetailsUsdt.EntryPrice);
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Something wrong with stop order, PLEASE CHECK MANUALLY!! MESSAGE => " + stopOrder.Message);
                                    }

                                }

                                if (streamData.Close > updatedVariableObjects.StopLossPrice)
                                {
                                    if (updatedVariableObjects.TrueRenkoCount == -1 && updatedVariableObjects.FalseRenkoCount > tradeParameter.NumberOfBricksToBeTolerated && updatedVariableObjects.LastTrueRenkoBrick.Date > updatedVariableObjects.PositionEntryRenkoBrick.Date)
                                    {
                                        Console.WriteLine("Trend turns from long to short. Position will be closed!");

                                        var positionCloseOrder = await binanceApiService.CloseFuturesUsdtPositionByMarketOrderAsync(tradeParameter.SymbolPair, "Sell", Math.Round(Convert.ToDecimal(updatedVariableObjects.BinancePositionDetailsUsdt.Quantity), symbolPairInformation.QuantityPrecision), "Long");

                                        if (positionCloseOrder.Success)
                                        {
                                            var closeOrderControl =
                                                binanceApiService.GetFuturesUsdtOrderBySymbolPairAndOrderIdAsync(
                                                    tradeParameter.SymbolPair, positionCloseOrder.Data.OrderId);
                                            if (closeOrderControl.Result.Success && closeOrderControl.Result.Data.Status == OrderStatus.Filled)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Magenta;
                                                Console.WriteLine("Position close order message: " + positionCloseOrder.Message);
                                                Console.WriteLine("Position closed! | Trade status updated to Looking For Position.");

                                                Console.WriteLine("Maximum balance limit is updating...");

                                                await CalculateToAddPnLToMaximumBalance(binanceApiService, tradeParameter, closeOrderControl.Result.Data, updatedVariableObjects.BinancePositionDetailsUsdt.EntryPrice);

                                                tradeFlow.TrackingOpenPosition = false;
                                                tradeFlow.LookingForPosition = true;
                                            }

                                        }
                                    }

                                }

                                if (updatedVariableObjects.BinancePositionDetailsUsdt.EntryPrice == 0)
                                {
                                    estimatedProfit = 0;
                                }
                                else
                                {
                                    estimatedProfit = Math.Round((updatedVariableObjects.BinancePositionDetailsUsdt.MarkPrice / updatedVariableObjects.BinancePositionDetailsUsdt.EntryPrice - 1) * 100, 2) * tradeParameter.Leverage;
                                }


                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("##########   Estimated Profit = %" + estimatedProfit + " | " + "Unrealized PnL = $" + Math.Round(updatedVariableObjects.BinancePositionDetailsUsdt.UnrealizedPnl, 2) + "   ##########");
                                Console.ForegroundColor = ConsoleColor.White;
                            }

                            if (updatedVariableObjects.BinancePositionDetailsUsdt.PositionSide == PositionSide.Short)
                            {
                                updatedVariableObjects.StopLossPrice = Math.Round(Convert.ToDecimal(updatedVariableObjects.BinancePositionDetailsUsdt.EntryPrice + updatedVariableObjects.BinancePositionDetailsUsdt.EntryPrice * tradeParameter.StopLossPercent / 100), calculatedPricePrecision);

                                Console.WriteLine("Stoploss Percent: %{0} , Calculated Stoploss Price: {1}", tradeParameter.StopLossPercent, updatedVariableObjects.StopLossPrice);

                                if (streamData.Close >= updatedVariableObjects.StopLossPrice)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;

                                    Console.WriteLine("The price fell below the stoploss price. Position will be stop.");

                                    Thread.Sleep(500);



                                    var stopOrder = await binanceApiService.CloseFuturesUsdtPositionByMarketOrderAsync(tradeParameter.SymbolPair, "Buy", Math.Abs(Math.Round(Convert.ToDecimal(updatedVariableObjects.BinancePositionDetailsUsdt.Quantity), symbolPairInformation.QuantityPrecision)), "Short");

                                    if (stopOrder.Success)
                                    {
                                        var stopOrderControl =
                                            binanceApiService.GetFuturesUsdtOrderBySymbolPairAndOrderIdAsync(
                                                tradeParameter.SymbolPair, stopOrder.Data.OrderId);

                                        if (stopOrderControl.Result.Success && stopOrderControl.Result.Data.Status == OrderStatus.Filled)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkGray;
                                            Console.WriteLine("Position is STOPPED: " + stopOrder.Message);
                                            tradeFlow.TrackingOpenPosition = false;
                                            tradeFlow.LookingForPosition = true;

                                            Thread.Sleep(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["IntermediateTimePeriod"]));

                                            Console.WriteLine("Maximum balance limit is updating...");


                                            await CalculateToAddPnLToMaximumBalance(binanceApiService, tradeParameter, stopOrderControl.Result.Data, updatedVariableObjects.BinancePositionDetailsUsdt.EntryPrice);
                                        }

                                    }
                                    else
                                    {
                                        Console.WriteLine("Something wrong with stop order, PLEASE CHECK MANUALLY!! MESSAGE => " + stopOrder.Message);
                                    }

                                }

                                if (streamData.Close < updatedVariableObjects.StopLossPrice)
                                {

                                    if (updatedVariableObjects.FalseRenkoCount == -1 && updatedVariableObjects.TrueRenkoCount > tradeParameter.NumberOfBricksToBeTolerated && updatedVariableObjects.LastFalseRenkoBrick.Date > updatedVariableObjects.PositionEntryRenkoBrick.Date)
                                    {
                                        Console.WriteLine("Trend turns from short to long. Position will be closed!");

                                        var positionCloseOrder = await binanceApiService.CloseFuturesUsdtPositionByMarketOrderAsync(tradeParameter.SymbolPair, "Buy", Math.Abs(Math.Round(Convert.ToDecimal(updatedVariableObjects.BinancePositionDetailsUsdt.Quantity), symbolPairInformation.QuantityPrecision)), "Short");

                                        if (positionCloseOrder.Success)
                                        {
                                            var closeOrderControl =
                                                binanceApiService.GetFuturesUsdtOrderBySymbolPairAndOrderIdAsync(
                                                    tradeParameter.SymbolPair, positionCloseOrder.Data.OrderId);
                                            if (closeOrderControl.Result.Success && closeOrderControl.Result.Data.Status == OrderStatus.Filled)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Magenta;
                                                Console.WriteLine("Position close order message: " + positionCloseOrder.Message);
                                                Console.WriteLine("Position closed! | Trade status updated to Looking For Position.");

                                                Console.WriteLine("Maximum balance limit is updating...");

                                                await CalculateToAddPnLToMaximumBalance(binanceApiService, tradeParameter, closeOrderControl.Result.Data, updatedVariableObjects.BinancePositionDetailsUsdt.EntryPrice);

                                                tradeFlow.TrackingOpenPosition = false;
                                                tradeFlow.LookingForPosition = true;
                                            }

                                        }
                                    }


                                }

                                if (updatedVariableObjects.BinancePositionDetailsUsdt.EntryPrice == 0)
                                {
                                    estimatedProfit = 0;
                                }
                                else
                                {
                                    estimatedProfit = Math.Round((1 - updatedVariableObjects.BinancePositionDetailsUsdt.MarkPrice / updatedVariableObjects.BinancePositionDetailsUsdt.EntryPrice) * 100, 2) * tradeParameter.Leverage;
                                }

                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("##########   Estimated Profit = %" + estimatedProfit + " | " + "Unrealized PnL = $" + Math.Round(updatedVariableObjects.BinancePositionDetailsUsdt.UnrealizedPnl, 2) + "   ##########");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else
                        {
                            Console.WriteLine("An error occurred. Message: " + binancePositionDetailsUsdtResult.Message);
                        }

                        iteration++;
                        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> ITERATION: {0}", iteration);
                    }

                }
            }
        }

        private static async Task CalculateToAddPnLToMaximumBalance(IBinanceApiService binanceApiService,
            TradeParameterEntity tradeParameter, BinanceFuturesOrder closeOrder, decimal entryPrice)
        {
            decimal calculatedProfit;

            if (closeOrder is { Status: OrderStatus.Filled })
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(
                    "Stop Order Control Result=> OrderId: {8} | Status: {9} | SymbolPair: {1} | Price/AvgPrice: {2}/{3} \n                               Quantity/QuantityFilled {4}/{5} | Side/PositionSide: {6}/{7}",
                    closeOrder.Symbol, closeOrder.Price, closeOrder.AvgPrice,
                    closeOrder.Quantity,
                    closeOrder.QuantityFilled, closeOrder.Side, closeOrder.PositionSide,
                    closeOrder.OrderId, closeOrder.Status);

                calculatedProfit = (entryPrice - closeOrder.QuoteQuantityFilled /
                    tradeParameter.Leverage) * closeOrder.Quantity;

                if (calculatedProfit <= 0)
                {
                    tradeParameter.MaximumBalanceLimit += calculatedProfit;
                }
                else
                {
                    if (tradeParameter.AddPnlToMaximumBalanceLimit == true)
                    {
                        tradeParameter.MaximumBalanceLimit += calculatedProfit * tradeParameter.PercentageOfPnlToBeAdded / 100;
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("OrderId: {0} is not filled yet.", closeOrder.OrderId);
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

        private static async Task<VariableObjects> InformationUpdates(BinanceFuturesUsdtKlineEntity streamData, IBinanceFuturesUsdtKlineDal binanceFuturesUsdtKlineDal, TradeParameterEntity tradeParameter, IIndicatorService indicatorService, Calculators calculators, VariableObjects variableObjects)
        {
            variableObjects.TrueRenkoCount = -1;
            variableObjects.FalseRenkoCount = -1;
            variableObjects.LastInIntervalTrendCount = -1;
            variableObjects.LastTrendBrickCount = -1;

            if (streamData.Open != 0)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Thread.Sleep(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["MainTimePeriod"]));



                Console.WriteLine("UTC Time: {0} | Local Time: {1}", DateTime.UtcNow, DateTime.Now);

                var lastKline = await UpdateOrInsertKlineData(binanceFuturesUsdtKlineDal, tradeParameter, streamData);

                var renkoResults = indicatorService.GetFuturesUsdtRenkoBricks(tradeParameter.SymbolPair, tradeParameter.Interval, tradeParameter.IndicatorParameterId).Data;


                var renkoCountList = calculators.CalculateFuturesUsdtRenkoCountFromRenkoBrickList(renkoResults,
                    Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["RenkoCountRange"]));

                variableObjects.LastRenkoBrick = renkoResults.LastOrDefault();

                variableObjects.LastInIntervalTrendCount = renkoResults.Count(x => x.InIntervalTrendId == variableObjects.LastRenkoBrick.InIntervalTrendId);
                variableObjects.LastTrendBrickCount = renkoResults.Count(x => x.TrendId == variableObjects.LastRenkoBrick.TrendId);

                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("===================================================================================================================================================================");

                //variableObjects.BinanceFuturesPlacedOrders.Clear();

                #region Trend Counts Results

                Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.Write("Last {0} Trend Count Results: ", Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["RenkoCountRange"]));

                foreach (var renkoCount in renkoCountList.Data)
                {
                    if (renkoCount.RenkoSide == "True")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("|" + renkoCount.Count);
                    }
                    if (renkoCount.RenkoSide == "False")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("|" + renkoCount.Count);
                    }
                }

                Console.WriteLine();

                #endregion


                #region Last Trend Count && Last In Interval Trend Counts

                var inIntervalTrendCountList =
                    calculators.CalculateInIntervalTrendCountFromRenkoBrickList(
                        renkoResults.Where(x => x.TrendId == variableObjects.LastRenkoBrick.TrendId));

                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write("Last Trend Brick Count=> ");

                if (variableObjects.LastRenkoBrick.IsUp == true)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }

                if (variableObjects.LastRenkoBrick.IsUp == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.Write(variableObjects.LastTrendBrickCount);

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" | Last In Interval Trend Counts=> ");

                foreach (var inIntervalTrendCount in inIntervalTrendCountList.Data)
                {
                    if (variableObjects.LastRenkoBrick.IsUp == true)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    if (variableObjects.LastRenkoBrick.IsUp == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write("|" + inIntervalTrendCount);
                }
                Console.WriteLine();

                #endregion




                switch (variableObjects.LastRenkoBrick.IsUp)
                {
                    case true:
                        {
                            variableObjects.LastFalseRenkoBrick = renkoResults.LastOrDefault(x => x.IsUp == false);
                            variableObjects.FirstTrueRenkoAfterTheLastFalse = renkoResults.FirstOrDefault(x => x.Id == variableObjects.LastFalseRenkoBrick.Id + 1);

                            variableObjects.TrueRenkoCount = Convert.ToInt32(variableObjects.LastRenkoBrick.Id) - Convert.ToInt32(variableObjects.LastFalseRenkoBrick.Id);


                            if (streamData.Close <= variableObjects.LastRenkoBrick.Close && streamData.Close >= variableObjects.LastRenkoBrick.Open)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("Current PRICE/IN Brick:  OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}, Price In BrickNumber: {4}", streamData.OpenTime, streamData.Open, streamData.Close, variableObjects.LastRenkoBrick.IsUp, variableObjects.TrueRenkoCount);
                            }
                            if (streamData.Close > variableObjects.LastRenkoBrick.Close)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("Current PRICE/IN Brick:  OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}, Price In BrickNumber: {4}", streamData.OpenTime, streamData.Open, streamData.Close, variableObjects.LastRenkoBrick.IsUp, variableObjects.TrueRenkoCount + 1);
                            }

                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Current COMPLETED Brick: OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}, BrickNumber: {4}", variableObjects.LastRenkoBrick.Date, variableObjects.LastRenkoBrick.Open, variableObjects.LastRenkoBrick.Close, variableObjects.LastRenkoBrick.IsUp, variableObjects.TrueRenkoCount);

                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("First TRUE Brick:        OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}", variableObjects.FirstTrueRenkoAfterTheLastFalse.Date, variableObjects.FirstTrueRenkoAfterTheLastFalse.Open, variableObjects.FirstTrueRenkoAfterTheLastFalse.Close, variableObjects.FirstTrueRenkoAfterTheLastFalse.IsUp);

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Last FALSE Brick:        OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}", variableObjects.LastFalseRenkoBrick.Date, variableObjects.LastFalseRenkoBrick.Open, variableObjects.LastFalseRenkoBrick.Close, variableObjects.LastFalseRenkoBrick.IsUp);

                            Console.ForegroundColor = ConsoleColor.White;

                            Console.WriteLine("===================================================================================================================================================================");

                            break;
                        }
                    case false:
                        {
                            variableObjects.LastTrueRenkoBrick = renkoResults.LastOrDefault(x => x.IsUp == true);
                            variableObjects.FirstFalseRenkoAfterTheLastTrue = renkoResults.FirstOrDefault(x => x.Id == variableObjects.LastTrueRenkoBrick.Id + 1);

                            variableObjects.FalseRenkoCount = Convert.ToInt32(variableObjects.LastRenkoBrick.Id) - Convert.ToInt32(variableObjects.LastTrueRenkoBrick.Id);

                            if (streamData.Close >= variableObjects.LastRenkoBrick.Close && streamData.Close <= variableObjects.LastRenkoBrick.Open)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("Current PRICE/IN Brick:  OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}, Price In BrickNumber: {4}", streamData.OpenTime, streamData.Open, streamData.Close, variableObjects.LastRenkoBrick.IsUp, variableObjects.FalseRenkoCount);
                            }

                            if (streamData.Close < variableObjects.LastRenkoBrick.Close)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("Current PRICE/IN Brick:  OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}, Price In BrickNumber: {4}", streamData.OpenTime, streamData.Open, streamData.Close, variableObjects.LastRenkoBrick.IsUp, variableObjects.FalseRenkoCount + 1);
                            }


                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Current COMPLETED Brick: OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}, BrickNumber: {4}", variableObjects.LastRenkoBrick.Date, variableObjects.LastRenkoBrick.Open, variableObjects.LastRenkoBrick.Close, variableObjects.LastRenkoBrick.IsUp, variableObjects.FalseRenkoCount);

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("First FALSE Brick:       OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}", variableObjects.FirstFalseRenkoAfterTheLastTrue.Date, variableObjects.FirstFalseRenkoAfterTheLastTrue.Open, variableObjects.FirstFalseRenkoAfterTheLastTrue.Close, variableObjects.FirstFalseRenkoAfterTheLastTrue.IsUp);

                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Last TRUE Brick:         OpenTime: {0}, Open: {1}, Close: {2}, BrickSide: {3}", variableObjects.LastTrueRenkoBrick.Date, variableObjects.LastTrueRenkoBrick.Open, variableObjects.LastTrueRenkoBrick.Close, variableObjects.LastTrueRenkoBrick.IsUp);

                            Console.ForegroundColor = ConsoleColor.White;

                            Console.WriteLine("===================================================================================================================================================================");

                            break;
                        }
                }
            }

            return variableObjects;
        }
    }
}
