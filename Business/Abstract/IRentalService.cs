using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(RentalAddDto rental);
        IDataResult<List<RentalReturnDto>> GetAll();
        IDataResult<RentalReturnDto> GetRentalById(int id);
        IResult Update(RentalUpdateDto rental);
        IResult Deliver(RentalDeliverDto rentalDeliverDto);
    }
}
