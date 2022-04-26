using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entity.Concrete.DTOs;
using Entity.Concrete.Entities;

namespace Business.Abstract
{
    public interface ITradeLogService
    {
        IDataResult<List<TradeLogsDto>> GetAllTradeLogDetails();
        //Async Methods
        Task<IDataResult<List<TradeLogEntity>>> GetAllTradeLogsAsync();
        Task<IDataResult<List<TradeLogEntity>>> GetTradeLogsByTradeFlowIdAsync(int tradeFlowId);
        Task<IResult> AddTradeLogAsync(TradeLogEntity tradeLogEntity);
        Task<IResult> AddTradeLogByParametersAsync(int tradeFlowId, int tradeId, string logRecord);
    }
}
