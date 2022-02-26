using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Binance.Net;
using Binance.Net.Enums;
using Quartz;
using RemoteData.Binance.WebSocket.Abstract;
using RemoteData.Binance.WebSocket.Concrete;

namespace Business.Tasks.Jobs
{
    public class SubscribeKlineDataJob : IJob
    {
        private readonly IBinanceWsService _binanceKlineWsService;
        public SubscribeKlineDataJob()
        {
            this._binanceKlineWsService = new BinanceWsManager(new BinanceSocketClient());
        }

        private async void SubscribeKlineData()
        {
            var streamData = await _binanceKlineWsService.GetCurrentFuturesUsdtKlineDataAsync("BTCUSDT", KlineInterval.OneMinute);



        }

        public async Task Execute(IJobExecutionContext context)
        {

            try
            {
                SubscribeKlineData();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

    }
}
