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

        [ValidationAspect(typeof(AddCarDtoValidator), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        [CacheRemoveAspect("ICarService.Get", Priority = 2)]
        [SecuredOperation("admin")]
        public IResult Add(AddCarDto car)
        {
            _carDal.Add(new Car
            {
                BrandId = car.BrandId,
                ColorId = car.ColorId,
                DailyPrice = car.DailyPrice,
                Description = car.Description,
                ModelYear = car.ModelYear,
                Name = car.Name
            });

            return new SuccessResult(Messages.CarAdded);
        }

        [TransactionScopeAspect(Priority = 1)]
        [CacheRemoveAspect("ICarService.Get", Priority = 2)]
        [SecuredOperation("admin")]
        public IResult Delete(int id)
        {
            if (_carDal.Get(c => c.Id == id) == null)
            {
                return new ErrorResult(Messages.CarNotFound);
            }
            _carDal.Delete(new Car { Id = id });
            return new SuccessResult(Messages.CarDeleted);
        }

        [CacheAspect]
        public IDataResult<List<CarReturnDto>> GetAll()
        {
            var cars = _carDal.GetList();

            List<CarReturnDto> data = new List<CarReturnDto>();
            foreach (var car in cars)
            {
                data.Add(
                    new CarReturnDto
                    {
                        Id = car.Id,
                        BrandId = car.BrandId,
                        ColorId = car.ColorId,
                        DailyPrice = car.DailyPrice,
                        Name = car.Name,
                        Description = car.Description,
                        ModelYear = car.ModelYear
                    }
                    );
            }

            return new SuccessDataResult<List<CarReturnDto>>(Messages.CarsListed, data);
        }

        [CacheAspect]
        public IDataResult<CarReturnDto> GetById(int id)
        {
            var data = _carDal.Get(c => c.Id == id);

            if (data == null)
                return new ErrorDataResult<CarReturnDto>(Messages.CarNotFound);

            CarReturnDto carReturnDto = new CarReturnDto
            {
                Id = data.Id,
                BrandId = data.BrandId,
                ColorId = data.ColorId,
                ModelYear = data.ModelYear,
                DailyPrice = data.DailyPrice,
                Description = data.Description,
                Name = data.Name
            };

            return new SuccessDataResult<CarReturnDto>(Messages.CarReceived, carReturnDto);
        }

        [CacheAspect]
        public IDataResult<CarDetailDto> GetCarDetail(int carId)
        {
            var data = _carDal.GetCarDetailByCarId(carId);
            if (data == null)
                return new ErrorDataResult<CarDetailDto>(Messages.CarNotFound);

            return new SuccessDataResult<CarDetailDto>(data);
        }

        [CacheAspect]
        public IDataResult<List<CarReturnDto>> GetCarsByBrandId(short brandId)
        {
            var cars = _carDal.GetList(c => c.BrandId == brandId);

            if (cars == null)
                return new ErrorDataResult<List<CarReturnDto>>(Messages.CarNotFound);

            List<CarReturnDto> data = new List<CarReturnDto>();
            foreach (var car in cars)
            {
                data.Add(
                    new CarReturnDto
                    {
                        Id = car.Id,
                        BrandId = car.BrandId,
                        ColorId = car.ColorId,
                        DailyPrice = car.DailyPrice,
                        Name = car.Name,
                        Description = car.Description,
                        ModelYear = car.ModelYear
                    }
                    );
            }

            return new SuccessDataResult<List<CarReturnDto>>(data);
        }

        [CacheAspect]
        public IDataResult<List<CarReturnDto>> GetCarsByColorId(short colorId)
        {
            var cars = _carDal.GetList(c => c.ColorId == colorId);

            if (cars == null)
                return new ErrorDataResult<List<CarReturnDto>>(Messages.CarNotFound);

            List<CarReturnDto> data = new List<CarReturnDto>();
            foreach (var car in cars)
            {
                data.Add(
                    new CarReturnDto
                    {
                        Id = car.Id,
                        BrandId = car.BrandId,
                        ColorId = car.ColorId,
                        DailyPrice = car.DailyPrice,
                        Name = car.Name,
                        Description = car.Description,
                        ModelYear = car.ModelYear
                    }
                    );
            }

            return new SuccessDataResult<List<CarReturnDto>>(data);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetCarsWithDetail()
        {

            var data = _carDal.GetCarsWithDetails();

            if (data == null)
                return new ErrorDataResult<List<CarDetailDto>>(Messages.CarNotFound);

            return new SuccessDataResult<List<CarDetailDto>>(data);
        }

        public IDataResult<bool> IsExists(int carId)
        {
            var car = _carDal.Get(c => c.Id == carId);
            if (car == null)
            {
                return new SuccessDataResult<bool>(false);
            }

            return new SuccessDataResult<bool>(true);
        }

        [ValidationAspect(typeof(UpdateCarDtoValidator), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        [CacheRemoveAspect("ICarService.Get", Priority = 3)]
        [SecuredOperation("admin")]
        public IResult Update(UpdateCarDto car)
        {
            _carDal.Update(new Car
            {
                Id = car.Id,
                BrandId = car.BrandId,
                ColorId = car.ColorId,
                DailyPrice = car.DailyPrice,
                Description = car.Description,
                ModelYear = car.ModelYear,
                Name = car.Name
            });

            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
