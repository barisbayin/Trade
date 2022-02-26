using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entity.Concrete;
using Entity.Concrete.Entities;

namespace DataAccess.Abstract
{
    public interface IIndicatorParameterDal : IEntityRepository<IndicatorParameterEntity>
    {
    }
}
