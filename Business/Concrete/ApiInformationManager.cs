using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete.Entities;

namespace Business.Concrete
{
    public class ApiInformationManager : IApiInformationService
    {
        private readonly IApiInformationDal _apiInformationDal;
        public ApiInformationManager(IApiInformationDal apiInformationDal)
        {
            _apiInformationDal = apiInformationDal;
        }
        public async Task<IResult> AddApiInformation(ApiInformationEntity apiInformationEntity)
        {
            var encryptedApiKey = AesEncryption.EncryptString(apiInformationEntity.ApiKey);
            var encryptedSecretKey = AesEncryption.EncryptString(apiInformationEntity.SecretKey);

            apiInformationEntity.ApiKey = encryptedApiKey;
            apiInformationEntity.SecretKey = encryptedSecretKey;
            apiInformationEntity.CreationDate = DateTime.Now;
            apiInformationEntity.IsRemoved = false;
            apiInformationEntity.RemovedDate = null;
            try
            {
                await _apiInformationDal.AddAsync(apiInformationEntity);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.InnerException.Message);
                throw;
            }


            return new SuccessResult();
        }

        public async Task<IDataResult<ApiInformationEntity>> GetApiInformationById(int id)
        {
            var result = await _apiInformationDal.GetAsync(x => x.Id == id);
            return new SuccessDataResult<ApiInformationEntity>(result);
        }
    }
}
