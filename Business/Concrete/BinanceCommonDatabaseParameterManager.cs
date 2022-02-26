using Business.Abstract;
using Business.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete.Entities;

namespace Business.Concrete
{

    public class BinanceCommonDatabaseParameterManager : IBinanceCommonDatabaseParameterService
    {

        private readonly IBinanceCommonDatabaseParameterDal _binanceCommonDatabaseParameterDal;
        public BinanceCommonDatabaseParameterManager(IBinanceCommonDatabaseParameterDal binanceCommonDatabaseParameterDal)
        {
            _binanceCommonDatabaseParameterDal = binanceCommonDatabaseParameterDal;
        }

        public async Task<IDataResult<List<BinanceIntervalParameterEntity>>> GetAllBinanceIntervalParametersAsync()
        {
            return new SuccessDataResult<List<BinanceIntervalParameterEntity>>(await _binanceCommonDatabaseParameterDal.GetAllAsync());
        }

        public async Task<IDataResult<int>> GetFuturesUsdtDayParameterForTheIntervalAsync(string interval)
        {
            var dayParameter = await _binanceCommonDatabaseParameterDal.GetAsync(i => i.Interval == interval && i.Market == "FuturesUsdt");

            return new SuccessDataResult<int>(dayParameter.DayParameter);
        }

        public async Task<IResult> UpdateDayParameterByIntervalAndMarketplace(string interval, string marketplace, int dayParameter)
        {
            Calculators calculators = new Calculators();

            var klineAmount = calculators.CalculateKlineAmountByInterval(interval, dayParameter);

            return new SuccessResult();

        }
    }
}
