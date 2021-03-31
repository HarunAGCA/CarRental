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
using System.Collections.Generic;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandAddDtoValidator), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        [CacheRemoveAspect("IBrandService.Get",Priority =3)]
        [SecuredOperation("admin")]
        public IResult Add(BrandAddDto brand)
        {
            if (IsExistsByName(brand.Name).Data)
            {
                return new ErrorResult(Messages.BrandAlreadyExists);
            }
            _brandDal.Add(new Brand {Name=brand.Name});

            return new SuccessResult(Messages.BrandAdded);
        }

        [TransactionScopeAspect(Priority = 1)]
        [CacheRemoveAspect("IBrandService.Get", Priority = 2)]
        [SecuredOperation("admin")]
        public IResult Delete(short brandId)
        {
            if(_brandDal.Get(b=>b.Id == brandId) == null)
            {
                return new ErrorResult(Messages.BrandNotFound);
            }

            _brandDal.Delete(new Brand { Id = brandId });

            return new SuccessResult(Messages.BrandDeleted);

        }

        [CacheAspect]
        public IDataResult<BrandReturnDto> Get(short brandId)
        {
            var result = _brandDal.Get(b => b.Id == brandId);
            if (result == null)
                return new ErrorDataResult<BrandReturnDto>(Messages.BrandNotFound);

            var data = new BrandReturnDto { Id = result.Id, Name = result.Name };

            return new SuccessDataResult<BrandReturnDto>(Messages.BrandReceived, data);
        }

        [CacheAspect]
        public IDataResult<List<BrandReturnDto>> GetAll()
        {
            var result=  _brandDal.GetList();

            var brands = new List<BrandReturnDto>();

            foreach(var brand in result)
            {
                brands.Add(new BrandReturnDto { Id = brand.Id, Name = brand.Name });
            }

            return new SuccessDataResult<List<BrandReturnDto>>(Messages.BrandsListed,brands);
        }

        public IDataResult<bool> IsExistsByName(string name)
        {
            var result = _brandDal.Get(b => b.Name.ToLower() == name.ToLower());

            if (result == null)
                return new SuccessDataResult<bool>(false);
            else
                return new SuccessDataResult<bool>(true);
        }

        [ValidationAspect(typeof(BrandUpdateDtoValidator),Priority =1)]
        [TransactionScopeAspect(Priority =2)]
        [CacheRemoveAspect("IBrandService.Get",Priority =3)]
        [SecuredOperation("admin")]
        public IResult Update(BrandUpdateDto updatedBrand)
        {
            _brandDal.Update(new Brand {Id = updatedBrand.Id, Name = updatedBrand.Name });

            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
