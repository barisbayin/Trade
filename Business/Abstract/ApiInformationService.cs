using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entity.Concrete.Entities;

namespace Business.Abstract
{
    public interface IApiInformationService
    {
        Task<IResult> AddApiInformation(ApiInformationEntity apiInformationEntity);
        Task<IDataResult<ApiInformationEntity>> GetApiInformationById(int id);
    }
}
