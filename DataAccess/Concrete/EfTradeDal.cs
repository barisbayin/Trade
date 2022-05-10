using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Binance.Net.Enums;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete.DTOs;
using Entity.Concrete.Entities;

namespace DataAccess.Concrete
{
    public class EfTradeDal : EfEntityRepositoryBase<TradeEntity, TradeContext>, ITradeDal
    {

        public List<TradeDto> GetAllTradeDetails()
        {
            using (TradeContext context = new TradeContext())
            {
                var result = from t in context.Trades
                             join tf in context.TradeFlows on t.TradeFlowId equals tf.Id
                             join tp in context.TradeParameters on tf.TradeParameterId equals tp.Id

                             select new TradeDto
                             {
                                 TradeId = t.Id,
                                 TradeFlowId = tf.Id,
                                 TradeFlowTitle = tp.TradeParameterTitle,
                                 TradeStarted = t.TradeStarted,
                                 TradeStartTime = t.TradeStartTime,
                                 TradeEnded = t.TradeEnded,
                                 TradeEndTime = t.TradeEndTime


                             };
                return result.ToList();
            }
        }
    }
}
