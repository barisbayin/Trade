using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete.Entities;

namespace Business.Concrete
{
    public class TradeFlowParameterManager : ITradeFlowParameterService
    {
        private readonly ITradeFlowParameterDal _tradeFlowParameterDal;
        public TradeFlowParameterManager(ITradeFlowParameterDal tradeFlowParameterDal)
        {
             _tradeFlowParameterDal= tradeFlowParameterDal;
        }
        public async Task<IDataResult<TradeFlowEntity>> GetTradeFlowParameter()
        {
            var tradeFlowParameter =(await _tradeFlowParameterDal.GetAllAsync(x => x.IsSelected == true)).LastOrDefault();
            return new SuccessDataResult<TradeFlowEntity>(tradeFlowParameter);
        }

        public async Task<IResult> UpdateTradeFlowParameter(TradeFlowEntity tradeFlowParameter)
        {
            await _tradeFlowParameterDal.UpdateAsync(tradeFlowParameter);
            return new SuccessResult();
        }
    }
}
