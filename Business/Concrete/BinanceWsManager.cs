using Business.Abstract;
using Core.Utilities.Results;
using RemoteData.Binance.WebSocket.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IBinanceWsService = RemoteData.Binance.WebSocket.Abstract.IBinanceWsService;

namespace Business.Concrete
{
    public class BinanceWsManager : Abstract.IBinanceWsService
    {
        private readonly IBinanceKlineService _binanceKlineService;
        private readonly IBinanceWsService _binanceKlineWsService;
        public BinanceWsManager(IBinanceKlineService binanceKlineService, IBinanceWsService binanceKlineWsService)
        {
            _binanceKlineService = binanceKlineService;
            _binanceKlineWsService = binanceKlineWsService;
        }
        public async Task<IResult> AutoInsertFuturesUsdtKlineDataToDatabaseAsync(string symbolPair, List<string> intervalList)
        {
            var addOldKlinesToDatabase = await _binanceKlineService.AddFuturesUsdtKlinesToDatabaseAsync(symbolPair, intervalList);

            if (addOldKlinesToDatabase.Success)
            {
                while (true)
                {

                }
            }

            return new SuccessResult();

        }
    }
}
