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
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(new Brand(){BrandId = 1, BrandName = "Marka 1"});
            //brandManager.Add(new Brand(){BrandId = 2, BrandName = "Marka 2"});
            ColorManager colorManager = new ColorManager(new EfColorDal());
            //colorManager.Add(new Colors(){ColorId = 1, ColorName = "Renk 1"});
            //colorManager.Add(new Colors(){ColorId = 2, ColorName = "Renk 2"});
            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car(){CarId = 1, BrandId = 2, ColorId = 2, Description = "Araba 1", DailyPrice = 250, ModelYear = 2001});
            //carManager.Add(new Car(){CarId = 2, BrandId = 2, ColorId = 1, Description = "Araba 2", DailyPrice = 5520, ModelYear = 2020});
            //carManager.Add(new Car(){CarId = 3, BrandId = 1, ColorId = 2, Description = "Araba 3", DailyPrice = 7330, ModelYear = 2009});

            Console.WriteLine("======= GetAll for Cars =======");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"Car Id: {car.CarId}\tBrandId: {car.ColorId}\tColorId: {car.ColorId}" +
                                  $"\tDescription: {car.Description}\tDailyPrice: {car.DailyPrice}\tModel Year: {car.ModelYear}");
            }

            Console.WriteLine("\n======= GetById 2 =======");
            var carById = carManager.GetById(2);
            Console.WriteLine($"Car Id: {carById.CarId}\tBrandId: {carById.ColorId}\tColorId: {carById.ColorId}" +
                              $"\tDescription: {carById.Description}\tDailyPrice: {carById.DailyPrice}\tModel Year: {carById.ModelYear}");

            Console.WriteLine("\n======= GetByColorId 2 =======");
            foreach (var car in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine($"Car Id: {car.CarId}\tBrandId: {car.BrandId}\tColorId: {car.ColorId}" +
                                  $"\tDescription: {car.Description}\tDailyPrice: {car.DailyPrice}\tModel Year: {car.ModelYear}");
            }
        }
    }
}
