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
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetAll();
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(int id);

        IDataResult<bool> IsExists(int carId);

        IDataResult<List<Car>> GetCarsByBrandId(short brandId);
        IDataResult<List<Car>> GetCarsByColorId(short colorId);

        IDataResult<List<CarDetailDto>> GetCarsWithDetail();
        IDataResult<CarDetailDto> GetCarDetail(int carId);
    }
}
