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
        Task<IResult> AddIndicatorParameter(IndicatorParameterEntity indicatorParameterEntity);
        Task<IResult> UpdateIndicatorParameter(IndicatorParameterEntity indicatorParameterEntity);
        IDataResult<List<IndicatorParameterEntity>> GetAll();
        IDataResult<IndicatorParameterEntity> GetIndicatorParameterEntityById(int id);
        Task<IDataResult<IndicatorParameterEntity>> GetIndicatorParameterEntityByIdAsync(int id);
        IDataResult<List<IndicatorParameterDto>> GetIndicatorParameterDetails();
        Task<IResult> DeleteIndicatorParameterById(int id);
    }
}
