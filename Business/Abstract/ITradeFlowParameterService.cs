using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entity.Concrete.Entities;

namespace Business.Abstract
{
    public interface ITradeFlowParameterService
    {
        Task<IDataResult<TradeFlowParameterEntity>> GetTradeFlowParameter();
        Task<IResult> UpdateTradeFlowParameter(TradeFlowParameterEntity tradeFlowParameter);
    }
}
