using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete.DTOs;

namespace Business.Concrete
{
    public class TradeParameterManager : ITradeParameterService
    {
        private readonly ITradeParameterDal _tradeParameterDal;
        public TradeParameterManager(ITradeParameterDal tradeParameterDal)
        {
            _tradeParameterDal = tradeParameterDal;
        }
        public IDataResult<List<TradeParameterDto>> GetTradeParameterDetails()
        {
            var result = _tradeParameterDal.GetTradeParameterDetails();
            return new SuccessDataResult<List<TradeParameterDto>>(result);
        }
    }
}
