using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(CustomerDto customer);
        IDataResult<CustomerDto> GetByUserId(int userId);
        IResult Delete(int id);
        IResult Update(CustomerDto customer);
        IDataResult<List<CustomerDto>> GetAll();
    }
}
