using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface IBrandService
    {
        IResult Add(Brand brand);
        IResult Update(Brand updatedBrand);
        IResult Delete(short brandId);
        IDataResult<Brand> Get(short brandId);
        IDataResult<List<Brand>> GetAll();
    }
}
