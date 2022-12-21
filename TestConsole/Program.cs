using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using System;
using System.Threading;
using System.Threading.Tasks;
using Binance.Net.Clients;
using Binance.Net.Objects;
using CryptoExchange.Net.Authentication;
using RemoteData.Binance.GeneralApi.Concrete;

namespace TestConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IApiInformationService apiInformationService = new ApiInformationManager(new EfApiInformationDal());

            var binanceApi = apiInformationService.GetDecryptedApiInformationById(2019);


            BinanceClient binanceClient = new BinanceClient(new BinanceClientOptions());

            binanceClient.SetApiCredentials(new ApiCredentials(binanceApi.Data.ApiKey, binanceApi.Data.SecretKey));


            IIndicatorService indicatorService = new IndicatorManager(
                new BinanceKlineManager(new EfBinanceFuturesUsdtKlineDal(),new BinanceApiManager(new BinanceClient())), new EfIndicatorDal(),
                new IndicatorParameterManager(new EfIndicatorParameterDal()));


            var result = indicatorService.GetPivots("BTCUSDT", "FifteenMinutes", 1025);

            foreach (var pivotsResult in result.Result.Data)
            {
                Console.WriteLine("BTCUSDT" + " -- " + pivotsResult.Date + " -- " + Math.Round(Convert.ToDecimal(pivotsResult.HighLine),2) + " | " + Math.Round(Convert.ToDecimal(pivotsResult.HighPoint),2) + " | " + pivotsResult.HighTrend + " | " + Math.Round(Convert.ToDecimal(pivotsResult.LowLine),2) + " | " + Math.Round(Convert.ToDecimal(pivotsResult.LowPoint),2) + " | " + pivotsResult.LowTrend);
            }



            Console.ReadLine();
        }
    }
}
