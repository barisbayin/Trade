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

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            string startupPath = System.IO.Directory.GetCurrentDirectory();

            Console.WriteLine(startupPath + "\\apps\\");


            //IBinanceExchangeInformationService binanceExchangeInformationService =
            //    new BinanceExchangeInformationManager(new EfBinanceFuturesUsdtSymbolDal(),new BinanceApiManager(new BinanceClient()));
            //var data = binanceExchangeInformationService.AddFuturesUsdtSymbolsAsync();
            //Console.WriteLine(data.Result.Message);



            /*
            IBinanceKlineApiService binanceKlineService = new BinanceKlineApiManager(new BinanceClient());

            var data = binanceKlineService.GetSpecificKlineDataForFuturesUsdtAsync("BTCUSDT", new List<string> { "OneHour","ThirtyMinutes" } ,new DateTime(2021, 10, 25) );

            if (data.Result.Success)
            {
                foreach (var kline in data.Result.Data)
                {

                    Console.WriteLine("SymbolPair: {2}, Kline Interval: {3} Open Time: {0}, Open Price: {1}", kline.OpenTime, kline.Open,kline.SymbolPair,kline.KlineInterval);
                    //Thread.Sleep(10);
                }
            }
            else
            {
                Console.WriteLine(data.Result.Message);
            }
            */


            /*
            IBinanceKlineWsService binanceKlineWsService = new BinanceKlineWsManager(new BinanceSocketClient());

            var streamData = binanceKlineWsService.GetCurrentFuturesUsdtKlineData("BTCUSDT", KlineInterval.OneMinute);

            if (!streamData.Result.Success)
            {
                Console.WriteLine(streamData.Result.Message);
            }
            while (streamData.Result.Success)
            {
                
                Console.WriteLine("OpenTime: {4}, Open= {0}, High= {1}, Low={2}, Close= {3}, Volume= {5}, QuoteVolume= {6}", streamData.Result.Data.Open, streamData.Result.Data.High, streamData.Result.Data.Low, streamData.Result.Data.Close, streamData.Result.Data.OpenTime, streamData.Result.Data.BaseVolume, streamData.Result.Data.QuoteVolume);
                Thread.Sleep(1000);
            }
            
            */


            /*
            IBinanceKlineService binanceKlineService = new BinanceKlineManager(new EfBinanceFuturesUsdtKlineDal(), new BinanceKlineApiManager(new BinanceClient()));

            //var deleteAll = binanceKlineService.DeleteAllFuturesUsdtKlines();
            //Console.WriteLine(deleteAll.Message);

            Thread.Sleep(1000);

            var result1 = binanceKlineService.AddFuturesUsdtKlinesToDatabaseAsync("BTCUSDT", new List<string> { "FourHour" });

            Console.WriteLine(result1.Result.Message);

            Thread.Sleep(1000);

            var deleteResult = binanceKlineService.DeleteFuturesUsdtKlinesBySymbolPairAndMultiInterval("SOLUSDT", new List<string> { "OneDay", "ThirtyMinutes" });

            Console.WriteLine(deleteResult.Message);
            */

            //Console.WriteLine(deleteResult.Message);
            //Console.ReadLine();

            //IBinanceExchangeInformationService binanceExchangeInformationService = new BinanceExchangeInformationManager(new EfBinanceFuturesUsdtSymbolDal(), new BinanceExchangeInformationApiManager(new BinanceClient()));

            //var result = binanceExchangeInformationService.AddFuturesUsdtSymbolsAsync();
            //Console.WriteLine(result.Result.Message);


            //IBinanceCommonDatabaseParameterService binanceCommonDatabaseParameterService = new BinanceCommonDatabaseParameterManager(new EfBinanceCommonDatabaseParameterDal());

            //var result = binanceCommonDatabaseParameterService.GetAllBinanceIntervalParametersAsync().Result.Data;

            //foreach (var item in result)
            //{
            //    Console.WriteLine("Kline Interval: {0}, Day Parameter: {1}", item.Interval, item.DayParameter);

            //}


            //IIndicatorService indicatorService = new IndicatorManager(
            //    new BinanceKlineManager(new EfBinanceFuturesUsdtKlineDal()), new EfIndicatorDal(),
            //    new IndicatorParameterManager(new EfIndicatorParameterDal()));

            //var result5 = indicatorService.GetAllIndicatorsAsync().Result.Data;

            //foreach (var item in result5)
            //{
            //    Console.WriteLine(item.IndicatorName);
            //}

            //var result = indicatorService.GetSuperTrendResultAsync("SOLUSDT", "FourHour", 1).Data;
            //foreach (var data in result)
            //{
            //    Console.WriteLine("SymbolPair: {0}, Interval: {1}, OpenTime: {2}, Close: {3}, SuperTrendValue: {4}, SuperTrendSide: {5}", data.SymbolPair, data.KlineInterval, data.OpenTime, data.Close, data.SuperTrendValue, data.SuperTrendSide);
            //}



            //var result = indicatorService.GetFuturesUsdtRenkoBricks("BTCUSDT", "FourHour", 3).Data;
            //foreach (var data in result)
            //{
            //    Console.WriteLine("SymbolPair: {0}, Interval: {1}, OpenTime: {2}, Open: {3}, Close: {4}, BrickSide: {5}", data.SymbolPair, data.KlineInterval, data.Date, data.Open, data.Close, data.IsUp);

            //}



            //var result4 = indicatorService.GetFuturesUsdtRenkoBricksSuperTrend("BTCUSDT", "FourHour", 17).Data;
            //foreach (var data in result4)
            //{
            //    Console.WriteLine("SymbolPair: {0}, Interval: {1}, OpenTime: {2}, Open: {3}, Close: {4}, STValue: {7}, STSide: {6}, BrickSide: {5}", data.SymbolPair, data.KlineInterval, data.OpenTime, data.Open, data.Close, data.IsUp, data.SuperTrendSide, data.SuperTrendValue);

            //}


            //SubscribeKlineDataTrigger subscribeKlineDataTrigger = new SubscribeKlineDataTrigger();
            //subscribeKlineDataTrigger.TriggerTheJob();

            /*
            var result = AesEncryption.EncryptString("xmdrndSHn9ECzKNaRdRAL61MVmIzLwZAGmqTu4dGyZ8Di0XypASZXCXV6ETYQPsy");
            Console.WriteLine(result);
            var result2 = AesEncryption.DecryptString(result);

            Console.WriteLine(result2);

            IApiInformationService apiInformationService = new ApiInformationManager(new EfApiInformationDal());

            ApiInformationEntity apiInformationEntity = new ApiInformationEntity();

            apiInformationEntity.Exchange = "Binance";
            apiInformationEntity.ApiTitle = "Ezo-Key";
            apiInformationEntity.ApiKey = "xmdrndSHn9ECzKNaRdRAL61MVmIzLwZAGmqTu4dGyZ8Di0XypASZXCXV6ETYQPsy";
            apiInformationEntity.SecretKey = "Stv62g9xdnO04Zz7ujhqqnOGroof9DKevUFyWsrbYT1X54DREKLpG1sLLxSWZoSM";



            apiInformationService.AddApiInformation(apiInformationEntity);
            */

            
            IBinanceApiService binanceAccountInformationApiService =
                new BinanceApiManager(new BinanceClient(), "mJelRp3XwTEB2j5I5nEOmIn14hkb9wxkUGMY972U0i9alycBodgMDXnZq7EeDZvN", "nAd6XuJ4cvXtTNbiwKKRRrKc9FZ48lbEy5SbQBTtpa367DbZsBUHi7PHBXeCK85J");


            var xxxx = binanceAccountInformationApiService.SetLeverageForFuturesUsdtSymbolPairAsync("ETHUSDT", 3).Result;

            var result7 = binanceAccountInformationApiService.PlaceFuturesUsdtLimitOrder("ETHUSDT","Buy", 0.0009M, "Long",2900.05M );

            result7.Wait();

            //BinanceClient binanceClient = new BinanceClient();
            //binanceClient.SetApiCredentials("xmdrndSHn9ECzKNaRdRAL61MVmIzLwZAGmqTu4dGyZ8Di0XypASZXCXV6ETYQPsy", "Stv62g9xdnO04Zz7ujhqqnOGroof9DKevUFyWsrbYT1X54DREKLpG1sLLxSWZoSM");

            //var xxx = binanceClient.FuturesUsdt.ChangeInitialLeverageAsync("BTCUSDT", 3).Result;
            
            //var result3= binanceClient.Spot.Order.PlaceOrderAsync("BTCUSDT", OrderSide.Buy, OrderType.Limit,0.0017M,null,null,29000,TimeInForce.GoodTillCancel,null);

            //result3.Wait();

            Console.WriteLine(result7.Result.Success);
            
            /*
            var result2 =  binanceClient.Spot.Order.CancelAllOpenOrdersAsync("BTCUSDT");
            result2.Wait();
            Console.WriteLine(result2.Result.ResponseHeaders);
            Console.WriteLine(result2.Result.ResponseStatusCode);
            Console.WriteLine(result2.Result.Success);
            Console.WriteLine(result2.Result.OriginalData);
            


            var result = binanceAccountInformationApiService.GetAccountInformation().Result.Data;
            foreach (var item in result)
            {
                Console.WriteLine(item.OrderId + " | " + item.Symbol + " | " + item.Price + " | " + item.Quantity);
            }

            */
            Console.ReadLine();
        }
    }
}
