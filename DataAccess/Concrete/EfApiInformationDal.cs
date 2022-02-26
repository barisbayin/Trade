using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete.Entities;

namespace DataAccess.Concrete
{
    public class EfApiInformationDal : EfEntityRepositoryBase<ApiInformationEntity, TradeContext>, IApiInformationDal
    {
    }
}
