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
    public class TradeFlowManager : ITradeFlowService
    {
        private readonly ITradeFlowDal _tradeFlowDal;
        public TradeFlowManager(ITradeFlowDal tradeFlowDal)
        {
            _tradeFlowDal = tradeFlowDal;
        }
        public async Task<IDataResult<TradeFlowEntity>> GetTradeFlow()
        {
            var tradeFlow =(await _tradeFlowDal.GetAllAsync(x => x.IsSelected == true)).LastOrDefault();
            return new SuccessDataResult<TradeFlowEntity>(tradeFlow);
        }

        public async Task<IResult> UpdateTradeFlow(TradeFlowEntity tradeFlowEntity)
        {
            await _tradeFlowDal.UpdateAsync(tradeFlowEntity);
            return new SuccessResult();
        }
    }
}
