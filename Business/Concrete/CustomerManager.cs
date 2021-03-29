using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        [ValidationAspect(typeof(CustomerValidator), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        [CacheRemoveAspect("ICustomerService.Get", Priority = 3)]
        public IResult Add(Customer customer)
        {
            if (!_userService.IsUserExist(customer.UserId))
            {
                return new ErrorResult(Messages.UserNotFound);
            }

            if (_customerDal.GetList(c => c.UserId == customer.UserId).Any())
            {
                return new ErrorResult(Messages.CustomerAlreadyExist);
            }

            _customerDal.Add(customer);
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
        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetList());
        }

        [CacheAspect]
        public IDataResult<Customer> GetByUserId(int userId)
        {
            var customer = _customerDal.Get(c => c.UserId == userId);

            if (customer == null)
                return new ErrorDataResult<Customer>(Messages.CustomerNotFound);

            return new SuccessDataResult<Customer>(Messages.CustomerReceived, customer);
        }

        [ValidationAspect(typeof(CustomerValidator), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        [CacheRemoveAspect("IColorService.Get", Priority = 3)]
        public IResult Update(Customer customer)
        {
            if (!_customerDal.GetList(c => c.UserId == customer.UserId).Any())
            {
                return new ErrorResult(Messages.UserNotFound);
            }

            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);

        }
    }
}
