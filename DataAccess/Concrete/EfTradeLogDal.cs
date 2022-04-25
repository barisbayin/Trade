using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete.DTOs;
using Entity.Concrete.Entities;

namespace DataAccess.Concrete
{
    public class EfTradeLogDal : EfEntityRepositoryBase<TradeLogEntity, TradeContext>, ITradeLogDal
    {
        public List<TradeLogsDto> GetTradeLogDetails()
        {
            using (TradeContext context = new TradeContext())
            {
                var result = from tl in context.TradeLogs
                             join tf in context.TradeFlows on tl.TradeFlowId equals tf.Id
                             join tp in context.TradeParameters on tf.TradeParameterId equals tp.Id

                             select new TradeLogsDto
                             {
                                 TradeFlowId = tl.TradeFlowId,
                                 TradeParameterTitle = tp.TradeParameterTitle,
                                 SymbolPair = tp.SymbolPair,
                                 TradeId = tl.TradeId,
                                 LogRecord = tl.LogRecord,
                                 LogDate = tl.LogDate

                             };
                //result.OrderByDescending(x => x.TradeFlowId).ThenByDescending(x => x.TradeId).ThenBy(x => x.LogDate);
                return result.ToList();
            }
        }
    }
}
