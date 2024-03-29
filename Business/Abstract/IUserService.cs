﻿using Core.Utilities.Results;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);

        IResult Update(User user);

        IDataResult<User> GetById(int id);

        IDataResult<List<User>> GetAll();

        bool IsUserExist(int userId);

        IDataResult<List<OperationClaim>> GetClaims(User user);

        IDataResult<User> GetByMail(string email);
    }
}
