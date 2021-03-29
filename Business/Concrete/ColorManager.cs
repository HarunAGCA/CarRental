using Business.Abstract;
using Business.BusinessAspects.Autofac;
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
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [ValidationAspect(typeof(ColorValidator), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        [CacheRemoveAspect("IColorService.Get", Priority = 3)]
        [SecuredOperation("admin")]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        [TransactionScopeAspect(Priority = 1)]
        [CacheRemoveAspect("IColorService.Get", Priority = 2)]
        [SecuredOperation("admin")]
        public IResult Delete(short colorId)
        {
            if(_colorDal.Get(c=>c.Id == colorId) == null)
            {
                return new ErrorResult(Messages.ColorNotFound);
            }
            _colorDal.Delete(new Color { Id = colorId });
            return new SuccessResult(Messages.ColorDeleted);

        }

        [CacheAspect]
        public IDataResult<Color> Get(short colorId)
        {
            var data = _colorDal.Get(c => c.Id == colorId);
            return new SuccessDataResult<Color>(Messages.ColorReceived, data);
        }

        [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {
            var data = _colorDal.GetList();

            return new SuccessDataResult<List<Color>>(Messages.ColorsListed,data);

        }

        [ValidationAspect(typeof(ColorValidator), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        [CacheRemoveAspect("IColorService.Get", Priority = 3)]
        [SecuredOperation("admin")]
        public IResult Update(Color updatedColor)
        {
            _colorDal.Update(updatedColor);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
