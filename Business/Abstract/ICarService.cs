using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<CarReturnDto> GetById(int id);

        IDataResult<List<CarReturnDto>> GetAll();

        IResult Add(AddCarDto car);

        IResult Update(UpdateCarDto car);

        IResult Delete(int id);

        IDataResult<bool> IsExists(int carId);

        IDataResult<List<CarReturnDto>> GetCarsByBrandId(short brandId);

        IDataResult<List<CarReturnDto>> GetCarsByColorId(short colorId);

        IDataResult<List<CarDetailDto>> GetCarsWithDetail();

        IDataResult<CarDetailDto> GetCarDetail(int carId);
    }
}
