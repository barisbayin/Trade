using Core.Utilities.Results;
using Entity.Concrete.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IApiInformationService
    {
        Task<IResult> AddApiInformation(ApiInformationEntity apiInformationEntity);
        Task<IResult> UpdateApiInformationById(ApiInformationEntity apiInformationEntity);
        Task<IDataResult<ApiInformationEntity>> GetApiInformationById(int id);
        Task<IDataResult<List<ApiInformationEntity>>> GetAllApiInformation();
        Task<IDataResult<List<ApiInformationEntity>>> GetAllNotRemovedApiInformation();
        Task<IResult> DeleteApiInformationById(int id);

    }
}
