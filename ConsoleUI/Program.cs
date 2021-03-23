using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {/*
            ICarService carService = new CarManager(new EfCarDal());
            IColorService colorService = new ColorManager(new EfColorDal());
            IBrandService brandService = new BrandManager(new EfBrandDal());
            IRentalService rentalService = new RentalManager(new EfRentalDal());
            IUserService userService = new UserManager(new EfUserDal());
            ICustomerService customerService = new CustomerManager(new EfCustomerDal(), userService);

            
            AddCarOperation(carService);
            UpdateCarOperation(carService);

            GetCarsWithDetail(carService);

            DeleteCarOperation(carService);
            

            userService.Add(new User {FirstName = "Harun", LastName = "AĞCA", Email = "harun39117@gmail.com", Password = "12345" });
            User user = userService.GetByEmailPassword("harun39117@gmail.com", "12345").Data;
            customerService.Add(new Customer { UserId = user.Id, CompanyName = "AGCA TECHNOLOGY" });
            Customer customer = customerService.GetByUserId(user.Id).Data;
            rentalService.Add(new Rental { CarId = 1, CustomerId = customer.UserId, RentDate = DateTime.Now });

            */
            

            

          
        }

        private static void GetCarsWithDetail(ICarService carService)
        {
            foreach(var car in carService.GetCarsWithDetail().Data)
            {
                PrintCarDetails(car);
            }

        }

        private static void PrintCarDetails(CarDetailDto dto)
        {
            Console.WriteLine($"{dto.CarName}   {dto.BrandName}  {dto.ColorName}  {dto.DailyPrice}");
        }

        private static void AddCarOperation(ICarService carService)
        {
            //Before Adding
            Console.WriteLine("---------- Before Adding -----------");
            PrintAllCars(carService);

            var newCar = new Car { ColorId = 1, Name ="Astra",BrandId = 1, DailyPrice = 235, Description = "Opel Astra Gümüş Gri", ModelYear = 2018 };
            carService.Add(newCar);

            //After Adding
            Console.WriteLine("---------- After Adding -----------");
            PrintAllCars(carService);
        }

        private static void DeleteCarOperation(ICarService carService)
        {
            //Before Deleting
            Console.WriteLine("---------- Before Deleting -----------");
            PrintAllCars(carService);

            carService.Delete(1);

            //After Deleting
            Console.WriteLine("---------- After Deleting -----------");
            PrintAllCars(carService);
        }

        private static void UpdateCarOperation(ICarService carService)
        {
            //Before Updating
            Console.WriteLine("---------- Before Updating -----------");
            PrintAllCars(carService);

            var carToUpdate = carService.GetById(1).Data;
            carToUpdate.DailyPrice = 345;
            carService.Update(carToUpdate);

            //After Updating
            Console.WriteLine("---------- After Updating -----------");
            PrintAllCars(carService);
        }

        private static void PrintAllCars(ICarService carService)
        {
            foreach (var car in carService.GetAll().Data)
            {
                Console.WriteLine($"{car.Id}    {car.Name}      {car.BrandId}   {car.ColorId}     {car.DailyPrice}   {car.ModelYear}     {car.Description} \n");
            }
        }
    }
}
