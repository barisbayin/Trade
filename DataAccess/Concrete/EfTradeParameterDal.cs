using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete.DTOs;
using Entity.Concrete.Entities;

namespace DataAccess.Concrete
{
    public class EfTradeParameterDal : EfEntityRepositoryBase<TradeParameterEntity, TradeContext>, ITradeParameterDal
    {
        public List<TradeParameterDto> GetTradeParameterDetails()
        {
            using (TradeContext context = new TradeContext())
            {
                var result = from tp in context.TradeParameters
                             join ip in context.IndicatorParameters on tp.IndicatorParameterId equals ip.Id
                             join a in context.ApiInformations on tp.ApiInformationId equals a.Id
                             where tp.Removed==false

                             select new TradeParameterDto
                             {
                                 Id = tp.Id,
                                 TradeParameterTitle = tp.TradeParameterTitle,
                                 IndicatorParameterTitle = ip.ParameterTitle,
                                 ApiTitle = a.ApiTitle,
                                 SymbolPair = tp.SymbolPair,
                                 Interval = tp.Interval,
                                 MarginType = tp.MarginType,
                                 Leverage = tp.Leverage,
                                 MaxAmountLimit = tp.MaximumAmountLimit,
                                 MaxAmountPercentage = tp.MaxAmountPercentage,
                                 AddPnlToMaxAmountLimit = tp.AddPnlToMaximumAmountLimit,
                                 PercentageOfPnlToBeAdded = tp.PercentageOfPnlToBeAdded,
                                 InUse = tp.InUse,
                                 CreationDate = tp.CreationDate,
                                 ModifiedDate = tp.ModifiedDate
                             };
                return result.ToList();
            }
        }
    }
}
