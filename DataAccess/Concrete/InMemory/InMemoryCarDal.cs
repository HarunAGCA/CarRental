using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{Id=1, BrandId=1, ColorId=1, DailyPrice=120, Description="Hyundai Accent Gri", ModelYear=2015 },
                new Car{Id=2, BrandId=2, ColorId=2, DailyPrice=250, Description="Mercedes E250 Beyaz", ModelYear=2013},
                new Car{Id=3, BrandId=1, ColorId=3, DailyPrice=340, Description="Volkswagen Jetta Siyah", ModelYear=2019 }
            };
        }

        public void Add(Car entity)
        {
            _cars.Add(entity);
        }

        public void Delete(Car entity)
        {
            var carToDelete = _cars.SingleOrDefault(c => c.Id == entity.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            return _cars.Find(filter.Compile().Invoke);
        }

        public CarDetailDto GetCarDetailByCarId(int id)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarsWithDetails()
        {
            throw new NotImplementedException();
        }

        public List<Car> GetList(Expression<Func<Car, bool>> filter = null)
        {
            return filter == null ? _cars : _cars.FindAll(filter.Compile().Invoke);
        }

        public void Update(Car entity)
        {
            var carToUpdate = _cars.SingleOrDefault(c => c.Id == entity.Id);
            carToUpdate.BrandId = entity.BrandId;
            carToUpdate.ColorId = entity.ColorId;
            carToUpdate.DailyPrice = entity.DailyPrice;
            carToUpdate.Description = entity.Description;
            carToUpdate.ModelYear = entity.ModelYear;
        }
    }
}
