using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        [CacheRemoveAspect("IUserService.Get", Priority = 3)]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        [CacheAspect]
        public IDataResult<List<User>> GetAll()
        {
            var users = _userDal.GetList();
            return new SuccessDataResult<List<User>>(Messages.UsersReceived, users);
        }

        [CacheAspect]
        public IDataResult<User> GetById(int id)
        {    
            var user = _userDal.Get(u => u.Id == id);
            return new SuccessDataResult<User>(Messages.UserReceived, user);
        }

        [ValidationAspect(typeof(UserValidator), Priority = 1)]
       // [CacheAspect]
        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var claims = _userDal.GetClaims(user);
            return new SuccessDataResult<List<OperationClaim>>(claims);
        }

        [CacheAspect]
        public IDataResult<User> GetByMail(string email)
        {
            var user=  _userDal.Get(u => u.Email == email);
            return new SuccessDataResult<User>(user);
        }

        public bool IsUserExist(int userId)
        {
            var user = _userDal.Get(u => u.Id == userId);
            return user != null ? true : false;
        }

        [ValidationAspect(typeof(UserValidator), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        [CacheRemoveAspect("IUserService.Get", Priority = 3)]
        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
