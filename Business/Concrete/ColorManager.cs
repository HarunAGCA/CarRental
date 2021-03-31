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
using Entities.DTOs;
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

        [ValidationAspect(typeof(ColorAddDtoValidator), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        [CacheRemoveAspect("IColorService.Get", Priority = 3)]
        [SecuredOperation("admin")]
        public IResult Add(ColorAddDto color)
        {
            if (IsExistsByName(color.Name).Data)
            {
                return new ErrorResult(Messages.ColorAlreadyExists);
            }
            _colorDal.Add(new Color { Name = color.Name });
            return new SuccessResult(Messages.ColorAdded);
        }

        [TransactionScopeAspect(Priority = 1)]
        [CacheRemoveAspect("IColorService.Get", Priority = 2)]
        [SecuredOperation("admin")]
        public IResult Delete(short colorId)
        {
            if (_colorDal.Get(c => c.Id == colorId) == null)
            {
                return new ErrorResult(Messages.ColorNotFound);
            }
            _colorDal.Delete(new Color { Id = colorId });
            return new SuccessResult(Messages.ColorDeleted);

        }

        [CacheAspect]
        public IDataResult<ColorReturnDto> Get(short colorId)
        {
            var data = _colorDal.Get(c => c.Id == colorId);
            if (data == null)
                return new ErrorDataResult<ColorReturnDto>(Messages.ColorNotFound);

            return new SuccessDataResult<ColorReturnDto>(new ColorReturnDto { Id = data.Id, Name = data.Name });
        }

        [CacheAspect]
        public IDataResult<List<ColorReturnDto>> GetAll()
        {
            var result = _colorDal.GetList();

            List<ColorReturnDto> colors = new List<ColorReturnDto>();

            foreach (var color in result)
            {
                colors.Add(new ColorReturnDto
                {
                    Id = color.Id,
                    Name = color.Name
                });
            }

            return new SuccessDataResult<List<ColorReturnDto>>(Messages.ColorsListed, colors);

        }

        public IDataResult<bool> IsExists(short id)
        {
            var result = _colorDal.Get(c => c.Id == id);
            if (result == null)
                return new SuccessDataResult<bool>(false);
            else
                return new SuccessDataResult<bool>(true);
        }

        public IDataResult<bool> IsExistsByName(string colorName)
        {
            var result = _colorDal.Get(c => c.Name.ToLower() == colorName.ToLower());

            if (result == null)
                return new SuccessDataResult<bool>(false);
            else
                return new SuccessDataResult<bool>(true);

        }

        [ValidationAspect(typeof(ColorUpdateDtoValidator), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        [CacheRemoveAspect("IColorService.Get", Priority = 3)]
        [SecuredOperation("admin")]
        public IResult Update(ColorUpdateDto updatedColor)
        {
            _colorDal.Update(new Color { Id = updatedColor.Id, Name = updatedColor.Name });
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
