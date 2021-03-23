using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, CarRentalContext>, IRentalDal
    {
        public Rental GetLastRentalByCarId(int carId)
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from r in context.Rentals
                             where r.CarId == carId
                             orderby r.RentDate descending
                             select new Rental
                             {
                                 Id = r.Id,
                                 CarId = r.CarId,
                                 CustomerId = r.CustomerId,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };

                return result.ToList().FirstOrDefault();
            }
        }
    }
}
