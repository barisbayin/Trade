using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using Quartz;
using System.Threading.Tasks;

namespace Business.Tasks.Jobs
{
    public class CalculateRenkoJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            IIndicatorService indicatorService = new IndicatorManager(
                new BinanceKlineManager(new EfBinanceFuturesUsdtKlineDal()),
                new IndicatorParameterManager(new EfIndicatorParameterDal()));

            var result = indicatorService.GetFuturesUsdtRenkoBricks("BTCUSDT", "FourHour", 3).Data;
            
        }
    }
}
