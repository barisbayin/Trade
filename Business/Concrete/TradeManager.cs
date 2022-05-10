using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete.DTOs;

namespace Business.Concrete
{
    public class TradeManager : ITradeService
    {
        private readonly ITradeDal _tradeDal;
        public TradeManager(ITradeDal tradeDal)
        {
            _tradeDal = tradeDal;
        }
        public  IDataResult<List<TradeDto>> GetAllTradeDetails()
        {
            var trades = _tradeDal.GetAllTradeDetails();
            return new SuccessDataResult<List<TradeDto>>(trades);
        }
    }
}
