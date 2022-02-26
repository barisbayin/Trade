using Business.Abstract;
using Business.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Costants.Messages;
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

        public async Task<IResult> DeleteDayParameterById(int id)
        {
            await _binanceCommonDatabaseParameterDal.DeleteAsync(await _binanceCommonDatabaseParameterDal.GetAsync(x => x.Id == id));
            return new SuccessResult(CommonMessages.Deleted);
        }

        public async Task<IResult> AddDayParameterAsync(BinanceIntervalParameterEntity binanceIntervalParameterEntity)
        {
            Calculators calculators = new Calculators();
            binanceIntervalParameterEntity.KlineCount = (calculators.CalculateKlineAmountByInterval(binanceIntervalParameterEntity.Interval,
                    binanceIntervalParameterEntity.DayParameter)).Result.Data;
            try
            {
                await _binanceCommonDatabaseParameterDal.AddAsync(binanceIntervalParameterEntity);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.InnerException.Message);
            }
            
            return new SuccessResult(CommonMessages.Added);
        }

        public async Task<IResult> UpdateDayParameterAsync(BinanceIntervalParameterEntity binanceIntervalParameterEntity)
        {
            Calculators calculators = new Calculators();
            binanceIntervalParameterEntity.KlineCount = (calculators.CalculateKlineAmountByInterval(binanceIntervalParameterEntity.Interval,
                binanceIntervalParameterEntity.DayParameter)).Result.Data;
            try
            {
                await _binanceCommonDatabaseParameterDal.UpdateAsync(binanceIntervalParameterEntity);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
            
            return new SuccessResult(CommonMessages.Updated);
        }
    }
}
