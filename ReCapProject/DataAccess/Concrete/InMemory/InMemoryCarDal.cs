//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using DataAccess.Abstract;
//using Entities.Concrete;

//namespace DataAccess.Concrete.InMemory
//{
//    public class InMemoryCarDal : ICarDal
//    {
//        private List<Car> cars;

//        public InMemoryCarDal()
//        {
//            cars = new List<Car>()
//            {
//                new Car(){CarId = 1, BrandId = 1, ColorId = 2, DailyPrice = 25000, Description = "Car 1", ModelYear = 2015},
//                new Car(){CarId = 2, BrandId = 2, ColorId = 1, DailyPrice = 23000, Description = "Car 2", ModelYear = 2014},
//                new Car(){CarId = 3, BrandId = 1, ColorId = 3, DailyPrice = 12000, Description = "Car 3", ModelYear = 2009},
//                new Car(){CarId = 4, BrandId = 3, ColorId = 1, DailyPrice = 45000, Description = "Car 4", ModelYear = 2020},
//                new Car(){CarId = 5, BrandId = 2, ColorId = 3, DailyPrice = 56000, Description = "Car 5", ModelYear = 2021},
//            };
//        }

//        public List<Car> GetAll()
//        {
//            return cars;
//        }

//        public Car GetById(int carId)
//        {
//            return cars.SingleOrDefault(c => c.CarId == carId);
//        }

//        public void Add(Car car)
//        {
//            cars.Add(car);
//        }

//        public void Update(Car car)
//        {
//            Car carToUpdate = cars.SingleOrDefault(c => c.CarId == car.CarId);
//            carToUpdate.DailyPrice = car.DailyPrice;
//            carToUpdate.Description = car.Description;
//            carToUpdate.ModelYear = car.ModelYear;
//        }

//        public void Delete(Car car)
//        {
//            Car carToDelete = cars.SingleOrDefault(c => c.CarId == car.CarId);
//            cars.Remove(carToDelete);
//        }
//    }
//}
