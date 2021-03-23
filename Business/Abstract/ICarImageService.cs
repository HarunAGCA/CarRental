using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImageReturnDto>> GetAllByCarId(int carId);
        IDataResult<CarImageReturnDto> GetById(int id);
        IResult Add(AddCarImageDto addCarImageDto);
        IResult Update(UpdateCarImageDto updateCarImageDto);
        IResult Delete(int id);

    }
}
