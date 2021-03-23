using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IDataResult<Customer> GetByUserId(int userId);
        IResult Delete(int id);
        IResult Update(Customer customer);
        IDataResult<List<Customer>> GetAll();
    }
}
