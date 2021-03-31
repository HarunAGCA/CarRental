using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        IUserService _userService;
        public CustomerManager(ICustomerDal customerDal, IUserService userService)
        {
            _customerDal = customerDal;
            _userService = userService;
        }

        [ValidationAspect(typeof(CustomerDtoValidator), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        [CacheRemoveAspect("ICustomerService.Get", Priority = 3)]
        public IResult Add(CustomerDto customer)
        {
            if (!_userService.IsUserExist(customer.UserId))
            {
                return new ErrorResult(Messages.UserNotFound);
            }

            if (_customerDal.GetList(c => c.UserId == customer.UserId).Any())
            {
                return new ErrorResult(Messages.CustomerAlreadyExist);
            }

            _customerDal.Add(new Customer { UserId = customer.UserId, CompanyName = customer.CompanyName });
            return new SuccessResult(Messages.CustomerAdded);
        }

        [TransactionScopeAspect(Priority = 1)]
        [CacheRemoveAspect("IColorService.Get", Priority = 2)]
        public IResult Delete(int customerId)
        {
            if (!_customerDal.GetList(c => c.UserId == customerId).Any())
            {
                return new ErrorResult(Messages.CustomerNotFound);
            }

            _customerDal.Delete(new Customer { UserId = customerId });
            return new SuccessResult(Messages.CustomerDeleted);
        }

        [CacheAspect]
        public IDataResult<List<CustomerDto>> GetAll()
        {
            var result = _customerDal.GetList();

            List<CustomerDto> customers = new List<CustomerDto>();

            foreach (var customer in result)
            {
                customers.Add(
                    new CustomerDto { UserId = customer.UserId, CompanyName = customer.CompanyName });
            }

            return new SuccessDataResult<List<CustomerDto>>(customers);
        }

        [CacheAspect]
        public IDataResult<CustomerDto> GetByUserId(int userId)
        {
            var result = _customerDal.Get(c => c.UserId == userId);

            if (result == null)
                return new ErrorDataResult<CustomerDto>(Messages.CustomerNotFound);

            return new SuccessDataResult<CustomerDto>(Messages.CustomerReceived, new CustomerDto { UserId = result.UserId, CompanyName = result.CompanyName });
        }

        [ValidationAspect(typeof(CustomerDtoValidator), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        [CacheRemoveAspect("IColorService.Get", Priority = 3)]
        public IResult Update(CustomerDto customer)
        {
            if (!_customerDal.GetList(c => c.UserId == customer.UserId).Any())
            {
                return new ErrorResult(Messages.UserNotFound);
            }

            _customerDal.Update(new Customer { UserId = customer.UserId, CompanyName = customer.CompanyName });

            return new SuccessResult(Messages.CustomerUpdated);

        }
    }
}
