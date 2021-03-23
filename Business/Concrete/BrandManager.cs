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
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [ValidationAspect(typeof(BrandValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IBrandService.Get")]
        [SecuredOperation("admin")]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);

            return new SuccessResult(Messages.BrandAdded);
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("IBrandService.Get")]
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
        public IDataResult<Brand> Get(short brandId)
        {
            var data = _brandDal.Get(b => b.Id == brandId);
            if (data == null)
                return new ErrorDataResult<Brand>(Messages.BrandNotFound);

            return new SuccessDataResult<Brand>(Messages.BrandReceived, data);
        }

        [CacheAspect]
        public IDataResult<List<Brand>> GetAll()
        {
            var data=  _brandDal.GetList();

            return new SuccessDataResult<List<Brand>>(Messages.BrandsListed,data);
        }

        [ValidationAspect(typeof(BrandValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IBrandService.Get")]
        [SecuredOperation("admin")]
        public IResult Update(Brand updatedBrand)
        {
            _brandDal.Update(updatedBrand);

            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
