using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        //TODO Test that if aspects are runnig by written order
        [TransactionScopeAspect(Priority = 2)]
        [CacheRemoveAspect("ICarImageService.Get", Priority = 3)]
        [ValidationAspect(typeof(AddCarImageDtoValidator), Priority = 1)]
        [SecuredOperation("admin")]
        public IResult Add(AddCarImageDto addCarImageDto)
        {
            if (_carImageDal.GetList(c => c.CarId == addCarImageDto.CarId).Count + addCarImageDto.Images.Count > 5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }


            string uniqueImageName;

            foreach (var image in addCarImageDto.Images)
            {
                var helperResult = ImageHelper.AddImage(image);

                if (!helperResult.IsSuccess)
                {
                    return new ErrorResult(Messages.CarImageCouldNotAdded);
                }

                uniqueImageName = helperResult.Data;

                _carImageDal.Add(new CarImage
                {
                    CarId = addCarImageDto.CarId,
                    FileName = uniqueImageName,
                    UploadDate = DateTime.Now
                });


            }
            return new SuccessResult(Messages.CarImagesAdded);
        }

        [TransactionScopeAspect(Priority = 1)]
        [CacheRemoveAspect("ICarImageService.Get", Priority = 2)]
        [SecuredOperation("admin")]
        public IResult Delete(int id)
        {
            var imageToDelete = _carImageDal.Get(c => c.Id == id);

            if (imageToDelete != null)
            {
                _carImageDal.Delete(imageToDelete);
                ImageHelper.Delete(imageToDelete.FileName);
            }

            return new SuccessResult(Messages.CarImageDeleted);

        }

        [CacheAspect]
        [PerformanceAspect(3)]
        public IDataResult<List<CarImageReturnDto>> GetAllByCarId(int carId)
        {
            var result = CheckIfCarHasNoImage(carId);

            var failedResult = BusinessEngine.Run(result);

            if (failedResult != null)
            {
                return new ErrorDataResult<List<CarImageReturnDto>>(failedResult.Message);
            }

            return result;
        }

        [CacheAspect]
        public IDataResult<CarImageReturnDto> GetById(int id)
        {
            var image = _carImageDal.Get(c => c.Id == id);
            if (image == null)
            {
                return new ErrorDataResult<CarImageReturnDto>(Messages.CarImageNotFound);
            }

            return new SuccessDataResult<CarImageReturnDto>(
                new CarImageReturnDto
                {
                    Id = image.Id,
                    CarId = image.CarId,
                    UploadDate = image.UploadDate,
                    Path = ImageHelper.GetImageRelativePath(image.FileName)
                }
                );
        }

        [ValidationAspect(typeof(UpdateCarImageDtoValidator), Priority = 1)]
        [TransactionScopeAspect(Priority = 2)]
        [CacheRemoveAspect("ICarImageService.Get", Priority = 3)]
        [SecuredOperation("admin")]
        public IResult Update(UpdateCarImageDto updateCarImageDto)
        {
            var imageRecord = _carImageDal.Get(ci => ci.Id == updateCarImageDto.Id);
            if (imageRecord == null)
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }

            var helperResult = ImageHelper.Update(updateCarImageDto.Image, imageRecord.FileName);

            if (!helperResult.IsSuccess)
            {
                return new ErrorResult(Messages.CarImageCouldNotUpdated);
            }

            imageRecord.FileName = helperResult.Data;
            imageRecord.UploadDate = DateTime.Now;

            _carImageDal.Update(imageRecord);

            return new SuccessResult(Messages.CarImageUpdated);
        }




        private IDataResult<List<CarImageReturnDto>> CheckIfCarHasNoImage(int carId)
        {
            var imageList = new List<CarImageReturnDto>();

            bool isExists = _carImageDal.GetList(c => c.CarId == carId).Any();

            if (!isExists)
            {
                imageList.Add(new CarImageReturnDto
                {
                    CarId = carId,
                    Path = ImageHelper.GetImageRelativePath("default.jpg")
                });

                return new SuccessDataResult<List<CarImageReturnDto>>(imageList);
            }

            var imageRecords = _carImageDal.GetList(ci => ci.CarId == carId);

            foreach (var imageRecord in imageRecords)
            {
                imageList.Add(new CarImageReturnDto
                {
                    CarId = imageRecord.CarId,
                    Id = imageRecord.Id,
                    UploadDate = imageRecord.UploadDate,
                    Path = ImageHelper.GetImageRelativePath(imageRecord.FileName)
                });
            }

            return new SuccessDataResult<List<CarImageReturnDto>>(imageList);
        }
    }
}
