using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entity.Concrete.DTOs;
using Entity.Concrete.Entities;

namespace Business.Abstract
{
    public interface ITradeFlowService
    {
        IDataResult<List<TradeFlowPartialDto>> GetTradeFlowPartialDetails();


        //Async Methods
        Task<IDataResult<TradeFlowEntity>> GetSelectedTradeFlow();
        Task<IDataResult<TradeFlowEntity>> GetTradeFlowById(int id);
        Task<IResult> AddTradeFlowAsync(TradeFlowEntity tradeFlowEntity);
        Task<IResult> UpdateTradeFlow(TradeFlowEntity tradeFlowEntity);

        
    }
}
