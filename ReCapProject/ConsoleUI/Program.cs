using System;
using System.Collections.Generic;
using System.Text;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
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
            Console.WriteLine($"CarId: {id4Car.Data.CarId}   BrandId: {id4Car.Data.BrandId}   ColorId: {id4Car.Data.ColorId}   " +
                              $"Description: {id4Car.Data.Description}   DailyPrice: {id4Car.Data.DailyPrice}   ModelYear: {id4Car.Data.ModelYear}");
        }
    }
}
