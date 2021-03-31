using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;


namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(ColorAddDto color);

        IResult Update(ColorUpdateDto updatedColor);

        IResult Delete(short colorId);

        IDataResult<ColorReturnDto> Get(short colorId);

        IDataResult<List<ColorReturnDto>> GetAll();

        IDataResult<bool> IsExists(short id);

        IDataResult<bool> IsExistsByName(string colorName);
    }
}
