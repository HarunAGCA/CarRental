using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator), Priority = 1)]
        [TransactionScopeAspect]
        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("admin")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);

            return new SuccessResult(Messages.CarAdded);
        }

        [TransactionScopeAspect]
        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("admin")]
        public IResult Delete(int id)
        {
            if(_carDal.Get(c=>c.Id==id) == null)
            {
                return new ErrorResult(Messages.CarNotFound);
            }
            _carDal.Delete(new Car { Id = id });
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            var data = _carDal.GetList();

            return new SuccessDataResult<List<Car>>(Messages.CarsListed,data);
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            var data = _carDal.Get(c => c.Id == id);

            return new SuccessDataResult<Car>(Messages.CarReceived, data);
        }

        [CacheAspect]
        public IDataResult<CarDetailDto> GetCarDetail(int carId)
        {
            var data = _carDal.GetCarDetailByCarId(carId);

            return new SuccessDataResult<CarDetailDto>(Messages.ReceivedCarDetail, data);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(short brandId)
        {
            var data = _carDal.GetList(c => c.BrandId == brandId);

            return new SuccessDataResult<List<Car>>(Messages.CarsListed,data);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByColorId(short colorId)
        {
            var data = _carDal.GetList(c => c.ColorId == colorId);

            return new SuccessDataResult<List<Car>>(Messages.CarsListed, data);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsWithDetail()
        {

            var data = _carDal.GetCarsWithDetails();

            return new SuccessDataResult<List<CarDetailDto>>(Messages.ReceivedCarsDetail, data);
        }

        public IDataResult<bool> IsExists(int carId)
        {
            var car = _carDal.Get(c => c.Id == carId);
            if(car == null)
            {
                return new SuccessDataResult<bool>(false);
            }

            return new SuccessDataResult<bool>(true);
        }

        [ValidationAspect(typeof(CarValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("ICarService.Get")]
        [SecuredOperation("admin")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);

            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
