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
        IDataResult<List<TradeFlowEntity>> GetAllTradeFlows();
        IDataResult<List<TradeFlowPartialDto>> GetAllTradeFlowPartialDetails();
        IDataResult<TradeFlowAllDto> GetSelectedTradeFlowAllDetail();
        IDataResult<TradeFlowEntity> GetSelectedTradeFlow();
        IResult UpdateTradeFlow(TradeFlowEntity tradeFlowEntity);
        IDataResult<TradeFlowEntity> CheckTheTradeFlowIsSelected(int id);
        IDataResult<TradeFlowEntity> CheckIfTheTradeFlowIsEnded(int id);
        IDataResult<TradeFlowEntity> CheckIfTheTradeFlowIsInUse(int id);
        IDataResult<List<TradeFlowPartialDto>> GetEndedTradeFlowPartialDetails();
        IDataResult<List<TradeFlowPartialDto>> GetNotEndedTradeFlowPartialDetails();
        IDataResult<List<TradeFlowPartialDto>> GetInUseTradeFlowPartialDetails();
        IDataResult<List<TradeFlowPartialDto>> GetNotInUseTradeFlowPartialDetails();
        IResult MarkAsFinishedById(int id);
        IResult MarkAsNotInUseById(int id);
        IResult ResetTradeFlowById(int id);

        //Async Methods
        Task<IDataResult<TradeFlowEntity>> GetSelectedTradeFlowAsync();
        Task<IDataResult<TradeFlowEntity>> GetTradeFlowByIdAsync(int id);
        Task<IResult> AddTradeFlowAsync(TradeFlowEntity tradeFlowEntity);
        Task<IResult> UpdateTradeFlowAsync(TradeFlowEntity tradeFlowEntity);
        Task<IResult> SelectTradeFlowAsync(int id);
        Task<IResult> UnSelectTradeFlowAsync(int id);
        


    }
}
