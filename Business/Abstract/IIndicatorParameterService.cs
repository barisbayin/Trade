using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using Entity.Concrete.Entities;

namespace Business.Abstract
{
    public interface IIndicatorParameterService
    {
        IDataResult<List<IndicatorParameterEntity>> GetAll();

        IDataResult<IndicatorParameterEntity> GetIndicatorParameterDataById(string name);
        Task<IDataResult<IndicatorParameterEntity>> GetIndicatorParameterDataByIdAsync(int parameterId);
        IDataResult<List<IndicatorParameterDto>> GetIndicatorParameterDetails();
        Task<IResult> DeleteIndicatorParameterById(int id);
    }
}
