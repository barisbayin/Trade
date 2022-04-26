using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Costants.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete.DTOs;
using Entity.Concrete.Entities;

namespace Business.Concrete
{
    public class TradeLogManager : ITradeLogService
    {
        private readonly ITradeLogDal _tradeLogDal;
        public TradeLogManager(ITradeLogDal tradeLogDal)
        {
            _tradeLogDal = tradeLogDal;
        }

        public IDataResult<List<TradeLogsDto>> GetAllTradeLogDetails()
        {
            var result = _tradeLogDal.GetTradeLogDetails();
            return new SuccessDataResult<List<TradeLogsDto>>(result);
        }

        public async Task<IDataResult<List<TradeLogEntity>>> GetAllTradeLogsAsync()
        {
            var result = await _tradeLogDal.GetAllAsync();
            return new SuccessDataResult<List<TradeLogEntity>>(result);
        }

        public async Task<IDataResult<List<TradeLogEntity>>> GetTradeLogsByTradeFlowIdAsync(int tradeFlowId)
        {
            var result = await _tradeLogDal.GetAllAsync(x => x.TradeFlowId == tradeFlowId);
            return new SuccessDataResult<List<TradeLogEntity>>(result);
        }

        public async Task<IResult> AddTradeLogAsync(TradeLogEntity tradeLogEntity)
        {
            tradeLogEntity.LogDate=DateTime.Now;
            try
            {
                await _tradeLogDal.AddAsync(tradeLogEntity);
                return new SuccessResult(CommonMessages.Added);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
            
        }

        public async Task<IResult> AddTradeLogByParametersAsync(int tradeFlowId, int tradeId, string logRecord)
        {
            var tradeLogEntity = new TradeLogEntity
            {
                TradeFlowId = tradeFlowId, TradeId = tradeId, LogRecord = logRecord, LogDate = DateTime.Now
            };


            try
            {
                await _tradeLogDal.AddAsync(tradeLogEntity);
                return new SuccessResult(CommonMessages.Added);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }
    }
}
