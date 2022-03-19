using Core.Utilities.Results;
using Entity.Concrete.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IApiInformationService
    {
        IDataResult<List<ApiInformationEntity>> GetAllNotRemovedApiInformation();
        IDataResult<ApiInformationEntity> GetDecryptedApiInformationById(int id);

        //Async Methods
        Task<IResult> AddApiInformationAsync(ApiInformationEntity apiInformationEntity);
        Task<IResult> UpdateApiInformationByIdAsync(ApiInformationEntity apiInformationEntity);
        Task<IDataResult<ApiInformationEntity>> GetApiInformationByIdAsync(int id);
        Task<IDataResult<List<ApiInformationEntity>>> GetAllApiInformationAsync();
        Task<IDataResult<List<ApiInformationEntity>>> GetAllNotRemovedApiInformationAsync();
        Task<IResult> DeleteApiInformationByIdAsync(int id);

       

    }
}
