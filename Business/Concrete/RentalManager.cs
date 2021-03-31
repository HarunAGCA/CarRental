using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        ICarService _carService;

        public RentalManager(IRentalDal rentalDal, ICarService carService)
        {
            _rentalDal = rentalDal;
            _carService = carService;
        }

        [ValidationAspect(typeof(RentalAddDtoValidator), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        [CacheRemoveAspect("IRentalService.Get", Priority = 3)]
        public IResult Add(RentalAddDto rental)
        {
            bool isCarExists = _carService.IsExists(rental.CarId).Data;

            if (!isCarExists)
            {
                return new ErrorResult(Messages.CarNotFound);
            }

            var failedRule = BusinessEngine.Run(CheckIfCarFree(rental.CarId));

            if (failedRule != null)
            {
                return new ErrorResult(failedRule.Message);
            }

            _rentalDal.Add(new Rental { CarId = rental.CarId, CustomerId = rental.CustomerId, RentDate = rental.RentDate });

            return new SuccessResult(Messages.RentalAdded);

        }

        [ValidationAspect(typeof(RentalDeliverDtoValidator), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        [CacheRemoveAspect("IRentalService.Get", Priority = 3)]
        public IResult Deliver(RentalDeliverDto rentalDeliverDto)
        {
            var rental = _rentalDal.Get(r => r.Id == rentalDeliverDto.RentalId);

            rental.ReturnDate = rentalDeliverDto.ReturnDate;
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.CarDelivered);
        }

        [CacheAspect]
        public IDataResult<List<RentalReturnDto>> GetAll()
        {
            var result = _rentalDal.GetList();

            List<RentalReturnDto> rentals = new List<RentalReturnDto>();

            foreach (var rental in result)
            {
                rentals.Add(new RentalReturnDto { Id = rental.Id, CarId = rental.CarId, CustomerId = rental.CustomerId, RentDate = rental.RentDate, ReturnDate = rental.ReturnDate });
            }

            return new SuccessDataResult<List<RentalReturnDto>>(rentals);
        }

        [CacheAspect]
        public IDataResult<RentalReturnDto> GetRentalById(int id)
        {
            var rental = _rentalDal.Get(r => r.Id == id);
            if (rental != null)
            {
                return new SuccessDataResult<RentalReturnDto>(Messages.RentalReceived,
                    new RentalReturnDto
                    {
                        Id = rental.Id,
                        CarId = rental.CarId,
                        CustomerId = rental.CustomerId,
                        RentDate = rental.RentDate,
                        ReturnDate = rental.ReturnDate
                    });
            }
            else
            {
                return new ErrorDataResult<RentalReturnDto>(Messages.RentalNotFound);
            }
        }

        [ValidationAspect(typeof(RentalUpdateDtoValidator), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        [CacheRemoveAspect("IRentalService.Get", Priority = 3)]
        public IResult Update(RentalUpdateDto rental)
        {
            _rentalDal.Update(new Rental { Id = rental.Id, CarId = rental.CarId, CustomerId = rental.CustomerId, RentDate = rental.RentDate, ReturnDate = rental.ReturnDate });
            return new SuccessResult(Messages.RentalUpdated);
        }



        private IResult CheckIfCarFree(int carId)
        {
            var rental = _rentalDal.GetLastRentalByCarId(carId);

            if (rental == null)
                return new SuccessResult(Messages.CarIsFree);

            if (rental.ReturnDate == null)
                return new ErrorResult(Messages.CarIsNotFree);


            return new SuccessResult(Messages.CarIsFree);
        }
    }
}
