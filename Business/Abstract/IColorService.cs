using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(Color color);
        IResult Update(Color updatedColor);
        IResult Delete(short colorId);
        IDataResult<Color> Get(short colorId);
        IDataResult<List<Color>> GetAll();
    }
}
