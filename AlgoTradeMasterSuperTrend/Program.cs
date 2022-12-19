using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Binance.Net.Clients;
using Binance.Net.Enums;
using Binance.Net.Objects.Models.Futures;
using Business.Abstract;
using Business.Concrete;
using Business.Helpers;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entity.Concrete.Entities;
using RemoteData.Binance.GeneralApi.Abstract;
using RemoteData.Binance.GeneralApi.Concrete;
using RemoteData.Binance.WebSocket.Abstract;
using RemoteData.Binance.WebSocket.Concrete;

namespace AlgoTradeMasterSuperTrend
{
    internal static class Program
    {
        private class VariableObjects
        {
            public BinanceFuturesUsdtKlineWithSuperTrend LastSuperTrendKline { get; set; }
            public BinanceFuturesUsdtKlineWithSuperTrend LastBuySuperTrendKline { get; set; }
            public BinanceFuturesUsdtKlineWithSuperTrend LastSellSuperTrendKline { get; set; }
            public BinanceFuturesUsdtKlineWithSuperTrend FirstSellAfterTheLastBuy { get; set; }
            public BinanceFuturesUsdtKlineWithSuperTrend FirstBuyAfterTheLastSell { get; set; }
            public BinanceFuturesUsdtKlineWithSuperTrend PositionEntrySuperTrendKline { get; set; }
            public BinancePositionDetailsUsdt BinancePositionDetailsUsdt { get; set; }

            public List<BinanceFuturesPlacedOrder> BinanceFuturesPlacedOrders { get; set; } =
                new List<BinanceFuturesPlacedOrder>();

            public List<BinanceFuturesOrder> BinanceFuturesFilledOrders { get; set; } = new List<BinanceFuturesOrder>();
            public int NormalizePricePrecision { get; set; }
            public decimal StopLossPrice { get; set; } = 0;
            public bool PositionEntryTrigger { get; set; } = false;
            public int LastTrendCount { get; set; }
            public int SellSuperTrendCount { get; set; }
            public int BuySuperTrendCount { get; set; }

        }
        private static async Task Main(string[] args)
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
                binanceExchangeInformationService.GetFuturesUsdtSymbolInformationBySymbolPairAsync(tradeParameter
                    .SymbolPair)).Data;

            #endregion

            #region Controls & Settings

            Console.Title = "ALGOTRADEMASTER-SUPERTREND: " + tradeParameter.SymbolPair.ToUpper() + " | " + tradeParameter.Interval.ToUpper() + " | " + indicatorParameter.KlineEndType.ToUpper() + " | " + "API: " + apiInformation.ApiTitle.ToUpper();

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

            variableObjects.NormalizePricePrecision = BitConverter.GetBytes(decimal.GetBits(symbolPairInformation.PriceFilterTickSize / 1.000000000000000000000000000000000m)[3])[2];

            while (tradeFlow.InUse == true)
            {
                var updatedVariableObjects = await InformationUpdates(streamData, binanceFuturesUsdtKlineDal, tradeParameter, indicatorService,
                    calculators, variableObjects);

                if (streamData.OpenPrice != 0)
                {
                    /*
                    #region LOOKING FOR FIRST POSITION

                    while (tradeFlow.LookingForFirstPosition == true)
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
                    */
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
                    streamData.OpenPrice, streamData.HighPrice, streamData.LowPrice,
                    streamData.ClosePrice, streamData.OpenTime, streamData.Volume,
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
                    streamData.OpenPrice, streamData.HighPrice, streamData.LowPrice,
                    streamData.ClosePrice, streamData.OpenTime, streamData.Volume,
                    streamData.QuoteVolume);

                Console.ForegroundColor = ConsoleColor.White;
            }

            return lastKline;
        }

        private static async Task<VariableObjects> InformationUpdates(BinanceFuturesUsdtKlineEntity streamData, IBinanceFuturesUsdtKlineDal binanceFuturesUsdtKlineDal, TradeParameterEntity tradeParameter, IIndicatorService indicatorService, Calculators calculators, VariableObjects variableObjects)
        {


            if (streamData.OpenPrice != 0)
            {
                Console.ForegroundColor = ConsoleColor.White;

                Thread.Sleep(Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["MainTimePeriod"]));



                Console.WriteLine("UTC Time: {0} | Local Time: {1}", DateTime.UtcNow, DateTime.Now);

                var lastKline = await UpdateOrInsertKlineData(binanceFuturesUsdtKlineDal, tradeParameter, streamData);

                var superTrendResults = indicatorService.GetSuperTrendResult(tradeParameter.SymbolPair, tradeParameter.Interval, tradeParameter.IndicatorParameterId).Data;

                var superTrendCountList = calculators.CalculateFuturesUsdtSuperTrendCount(superTrendResults,
                    Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SuperTrendCountRange"]));

                variableObjects.LastSuperTrendKline = superTrendResults.LastOrDefault();

                variableObjects.LastSuperTrendKline = calculators
                    .RoundDecimals(variableObjects.LastSuperTrendKline,
                        variableObjects.NormalizePricePrecision).Data;

                variableObjects.LastTrendCount = superTrendResults.Count(x => x.TrendId == variableObjects.LastSuperTrendKline.TrendId);


                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine("===================================================================================================================================================================");

                //variableObjects.BinanceFuturesPlacedOrders.Clear();

                #region SuperTrend Counts Results

                Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.Write("Last {0} SuperTrend Count Results: ", Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SuperTrendCountRange"]));
               
                foreach (var superTrendCount in superTrendCountList.Data)
                {
                    switch (superTrendCount.SuperTrendSide)
                    {
                        case "BUY":
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("|" + superTrendCount.Count);
                            break;
                        case "SELL":
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("|" + superTrendCount.Count);
                            break;
                    }
                }

                Console.WriteLine();

                #endregion


                switch (variableObjects.LastSuperTrendKline.SuperTrendSide == "BUY")
                {
                    case true:
                        {
                            variableObjects.LastSellSuperTrendKline = superTrendResults.LastOrDefault(x => x.SuperTrendSide == "SELL");

                            variableObjects.LastSellSuperTrendKline = calculators
                                .RoundDecimals(variableObjects.LastSellSuperTrendKline,
                                    variableObjects.NormalizePricePrecision).Data;

                            variableObjects.FirstBuyAfterTheLastSell = superTrendResults.FirstOrDefault(x => x.Id == variableObjects.LastSellSuperTrendKline.Id + 1);

                            variableObjects.FirstBuyAfterTheLastSell = calculators
                                .RoundDecimals(variableObjects.FirstBuyAfterTheLastSell,
                                    variableObjects.NormalizePricePrecision).Data;


                            variableObjects.BuySuperTrendCount = Convert.ToInt32(variableObjects.LastSuperTrendKline.Id) - Convert.ToInt32(variableObjects.LastSellSuperTrendKline.Id);


                            var proximityPercent = Math.Round((variableObjects.LastSuperTrendKline.ClosePrice /
                                                       variableObjects.LastSuperTrendKline.SuperTrendValue) * 100 - 100, 2);
                            var proximityPrice = Math.Round(variableObjects.LastSuperTrendKline.ClosePrice -
                                                               variableObjects.LastSuperTrendKline.SuperTrendValue, variableObjects.NormalizePricePrecision);

                            Console.ForegroundColor = ConsoleColor.Blue;

                            Console.WriteLine("Current ST Kline: OpenTime: {0}, Open: {1}, High: {2}, Low: {3}, Close: {4},\n                  STSide: {5}, STValue: {6}, Proximity%: {7}, Proximity$: {8} ", variableObjects.LastSuperTrendKline.OpenTime, variableObjects.LastSuperTrendKline.OpenPrice, variableObjects.LastSuperTrendKline.HighPrice, variableObjects.LastSuperTrendKline.LowPrice, variableObjects.LastSuperTrendKline.ClosePrice, variableObjects.LastSuperTrendKline.SuperTrendSide, variableObjects.LastSuperTrendKline.SuperTrendValue, proximityPercent, proximityPrice);

                            Console.ForegroundColor = ConsoleColor.DarkGreen;

                            Console.WriteLine("First BUY ST Kline: OpenTime: {0}, Open: {1}, High: {2}, Low: {3}, Close: {4}, STSide: {5}, STValue: {6}", variableObjects.FirstBuyAfterTheLastSell.OpenTime, variableObjects.FirstBuyAfterTheLastSell.OpenPrice, variableObjects.FirstBuyAfterTheLastSell.HighPrice, variableObjects.FirstBuyAfterTheLastSell.LowPrice, variableObjects.FirstBuyAfterTheLastSell.ClosePrice, variableObjects.FirstBuyAfterTheLastSell.SuperTrendSide, variableObjects.FirstBuyAfterTheLastSell.SuperTrendValue);

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Last SELL ST Kline: OpenTime: {0}, Open: {1}, High: {2}, Low: {3}, Close: {4}, STSide: {5}, STValue: {6}", variableObjects.LastSellSuperTrendKline.OpenTime, variableObjects.LastSellSuperTrendKline.OpenPrice, variableObjects.LastSellSuperTrendKline.HighPrice, variableObjects.LastSellSuperTrendKline.LowPrice, variableObjects.LastSellSuperTrendKline.ClosePrice, variableObjects.LastSellSuperTrendKline.SuperTrendSide, variableObjects.LastSellSuperTrendKline.SuperTrendValue);

                            Console.ForegroundColor = ConsoleColor.White;

                            Console.WriteLine("===================================================================================================================================================================");

                            break;
                        }
                    case false:
                        {
                            variableObjects.LastBuySuperTrendKline = superTrendResults.LastOrDefault(x => x.SuperTrendSide == "BUY");
                            variableObjects.LastBuySuperTrendKline = calculators.RoundDecimals(
                                variableObjects.LastBuySuperTrendKline, variableObjects.NormalizePricePrecision).Data;

                            variableObjects.FirstSellAfterTheLastBuy = superTrendResults.FirstOrDefault(x => x.Id == variableObjects.LastBuySuperTrendKline.Id + 1);

                            variableObjects.FirstSellAfterTheLastBuy = calculators
                                .RoundDecimals(variableObjects.FirstSellAfterTheLastBuy,
                                    variableObjects.NormalizePricePrecision).Data;

                            variableObjects.SellSuperTrendCount = Convert.ToInt32(variableObjects.LastSuperTrendKline.Id) - Convert.ToInt32(variableObjects.LastBuySuperTrendKline.Id);

                            var proximityPercent = Math.Round((100 - variableObjects.LastSuperTrendKline.ClosePrice /
                                                       variableObjects.LastSuperTrendKline.SuperTrendValue * 100), 2);
                            var proximityPrice = Math.Round(variableObjects.LastSuperTrendKline.SuperTrendValue -
                                                               variableObjects.LastSuperTrendKline.ClosePrice, variableObjects.NormalizePricePrecision);

                            Console.ForegroundColor = ConsoleColor.Blue;

                            Console.WriteLine("Current ST Kline: OpenTime: {0}, Open: {1}, High: {2}, Low: {3}, Close: {4}, \n                   STSide: {5}, STValue: {6}, Proximity%: {7}, Proximity$: {8} ", variableObjects.LastSuperTrendKline.OpenTime, variableObjects.LastSuperTrendKline.OpenPrice, variableObjects.LastSuperTrendKline.HighPrice, variableObjects.LastSuperTrendKline.LowPrice, variableObjects.LastSuperTrendKline.ClosePrice, variableObjects.LastSuperTrendKline.SuperTrendSide, variableObjects.LastSuperTrendKline.SuperTrendValue, proximityPercent, proximityPrice);

                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.WriteLine("First SELL ST Kline: OpenTime: {0}, Open: {1}, High: {2}, Low: {3}, Close: {4}, STSide: {5}, STValue: {6}", variableObjects.FirstSellAfterTheLastBuy.OpenTime, variableObjects.FirstSellAfterTheLastBuy.OpenPrice, variableObjects.FirstSellAfterTheLastBuy.HighPrice, variableObjects.FirstSellAfterTheLastBuy.LowPrice, variableObjects.FirstSellAfterTheLastBuy.ClosePrice, variableObjects.FirstSellAfterTheLastBuy.SuperTrendSide, variableObjects.FirstSellAfterTheLastBuy.SuperTrendValue);

                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Last BUY ST Kline: OpenTime: {0}, Open: {1}, High: {2}, Low: {3}, Close: {4}, STSide: {5}, STValue: {6}", variableObjects.LastBuySuperTrendKline.OpenTime, variableObjects.LastBuySuperTrendKline.OpenPrice, variableObjects.LastBuySuperTrendKline.HighPrice, variableObjects.LastBuySuperTrendKline.LowPrice, variableObjects.LastBuySuperTrendKline.ClosePrice, variableObjects.LastBuySuperTrendKline.SuperTrendSide, variableObjects.LastBuySuperTrendKline.SuperTrendValue);

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
