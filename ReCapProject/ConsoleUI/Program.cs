using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //gun9();

            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new User()
            {
                FirstName = "Mehmet Burak",
                LastName = "Köylü",
                Email = "mbkoylu2002@gmail.com",
                //Password = "1234"
            });

            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine($"{user.Id}, {user.FirstName} {user.LastName}, {user.Email}");
            }

            Console.WriteLine("---------Add Customer---------");
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer()
            {
                UserId = 1,
                CompanyName = "Company Name 1"
            });

            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine($"{customer.UserId}, {customer.CompanyName}");
            }

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var add = rentalManager.Add(new Rental()
            {
                CarId = 1,
                CustomerId = 1,
                RentDate = DateTime.Now,
            });

            if (add.Success)
            {
                foreach (var rentalDetailDto in rentalManager.GetAllRentalDetail().Data)
                {
                    Console.WriteLine($"{rentalDetailDto.FirstName} {rentalDetailDto.LastName}, {rentalDetailDto.CarBrand}, {rentalDetailDto.CarDescription}, {rentalDetailDto.CarModel}" +
                                      $", {rentalDetailDto.CompanyName}, {rentalDetailDto.RentDate.ToLocalTime()}, {rentalDetailDto.ReturnDate}");
                }
            }
            else
            {
                Console.WriteLine(add.Message);
            }


            var rental = rentalManager.GetById(4);
            Rental rentalUpdate = rental.Data;
            rentalUpdate.ReturnDate = DateTime.Now;
            var result = rentalManager.Update(rentalUpdate);
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine("hata");
            }

        }

        private static void gun9()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car()
            {
                BrandId = 1,
                Description = "Core Sonrası Araba 3",
                ColorId = 2,
                DailyPrice = 150000,
                ModelYear = 2021
            });

            Console.WriteLine("\n=============GetAll=============");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine($"CarId: {car.CarId}   BrandId: {car.BrandId}   ColorId: {car.ColorId}   " +
                                  $"Description: {car.Description}   DailyPrice: {car.DailyPrice}   ModelYear: {car.ModelYear}");
            }

            Console.WriteLine("\n=============GetCarsDetailDTO=============");
            foreach (var car in carManager.GetCarsDetailDto().Data)
            {
                Console.WriteLine($"{car.Description}   {car.ColorName}   {car.BrandName}   {car.DailyPrice}");
            }

            Console.WriteLine("\n=============GetCarById=============");
            var id4Car = carManager.GetById(4);
            Console.WriteLine(
                $"CarId: {id4Car.Data.CarId}   BrandId: {id4Car.Data.BrandId}   ColorId: {id4Car.Data.ColorId}   " +
                $"Description: {id4Car.Data.Description}   DailyPrice: {id4Car.Data.DailyPrice}   ModelYear: {id4Car.Data.ModelYear}");
        }
    }
}
