using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IBrandService
    {
        IResult Add(BrandAddDto brand);

        IResult Update(BrandUpdateDto updatedBrand);

        IResult Delete(short brandId);

        IDataResult<BrandReturnDto> Get(short brandId);

        IDataResult<List<BrandReturnDto>> GetAll();

        IDataResult<bool> IsExistsByName(string name);
    }
}
