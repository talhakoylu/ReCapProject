using System;
using System.Collections.Generic;
using System.Text;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            string carDescription = carManager.GetById(3).Description;
            Console.WriteLine(carDescription);

            List<Car> cars = carManager.GetAll();

            foreach (var car in cars)
            {
                Console.WriteLine($"************** {car.CarId} Car **************");
                Console.WriteLine("Car Id: " + car.CarId);
                Console.WriteLine("Color Id: " + car.ColorId);
                Console.WriteLine("Brand Id: " + car.BrandId);
                Console.WriteLine("Description: " + car.Description);
                Console.WriteLine("Price: " + car.DailyPrice);
                Console.WriteLine("Model: " + car.ModelYear);
            }

            carManager.Update(new Car()
            {
                CarId = 3, Description = "Car 3 Updated"
            });

            Console.WriteLine("\n"+carManager.GetById(3).Description);
        }
    }
}
