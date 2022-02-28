using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using Entity.Concrete.Entities;

namespace Business.Concrete
{
    public class IndicatorParameterManager : IIndicatorParameterService
    {
        private readonly IIndicatorParameterDal _indicatorParameterDal;

        public IndicatorParameterManager(IIndicatorParameterDal indicatorParameterDal)
        {
            _indicatorParameterDal = indicatorParameterDal;
        }

        public IDataResult<List<IndicatorParameterEntity>> GetAll()
        {
            return new SuccessDataResult<List<IndicatorParameterEntity>>(_indicatorParameterDal.GetAll());
        }

        public IDataResult<IndicatorParameterEntity> GetIndicatorParameterDataById(string name)
        {
            return new SuccessDataResult<IndicatorParameterEntity>(_indicatorParameterDal.Get(x => x.ParameterTitle == name));
        }

        public async Task<IDataResult<IndicatorParameterEntity>> GetIndicatorParameterDataByIdAsync(int parameterId)
        {
            return new SuccessDataResult<IndicatorParameterEntity>(await _indicatorParameterDal.GetAsync(x => x.Id == parameterId));
        }

        public IDataResult<List<IndicatorParameterDto>> GetIndicatorParameterDetails()
        {
            var result = _indicatorParameterDal.GetIndicatorParameterDetails();
            return new SuccessDataResult<List<IndicatorParameterDto>>(result);
        }
    }
}
