using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using System.Linq;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public CarDetailDto GetCarDetailByCarId(int id)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from cr in context.Cars
                             join b in context.Brands
                             on cr.BrandId equals b.Id
                             join c in context.Colors
                             on cr.ColorId equals c.Id
                             where cr.Id == id
                             select new CarDetailDto
                             {
                                 BrandName = b.Name,
                                 CarName = cr.Name,
                                 ColorName = c.Name,
                                 DailyPrice = cr.DailyPrice
                             };

                return result.SingleOrDefault();
            }
        }

        public List<CarDetailDto> GetCarsWithDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from cr in context.Cars
                             join b in context.Brands
                             on cr.BrandId equals b.Id
                             join c in context.Colors
                             on cr.ColorId equals c.Id
                             select new CarDetailDto
                             {
                                 BrandName = b.Name,
                                 CarName = cr.Name,
                                 ColorName = c.Name,
                                 DailyPrice = cr.DailyPrice
                             };

               var listResult = result.ToList();
                return listResult;
            }
        }
    }
}
