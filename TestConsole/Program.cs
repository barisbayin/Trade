using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using System;
using System.Threading;
using System.Threading.Tasks;
using Binance.Net.Clients;
using Binance.Net.Objects;
using CryptoExchange.Net.Authentication;

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



            var info = binanceClient.SpotApi.ExchangeData.GetExchangeInfoAsync(CancellationToken.None).Result.Data;

            int maxSymbolLength = 15;

            foreach (var item in info.Symbols)
            {
                if (item.QuoteAsset=="BUSD")
                {
                    Console.WriteLine(item.Name + "\t| " + item.BaseAsset + "\t| " + item.QuoteAsset);
                }
                
            }





            Console.ReadLine();
        }
    }
}
