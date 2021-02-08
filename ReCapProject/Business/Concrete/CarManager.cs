using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("Araba ekleme başarılı.");
            }
            else
            {
                Console.WriteLine("Araba eklerken bir şeyler ters gitti, acaba fiyat ya da araba isminde bir aksilik olabilir mi?");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Araba silme başarılı.");
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.Get(c => c.CarId == id);
        }

        public List<CarDetailDto> GetCarsByBrandId(int id)
        {
            return _carDal.GetCarDetails(c => c.BrandId == id);
        }

        public List<CarDetailDto> GetCarsByColorId(int id)
        {
            return _carDal.GetCarDetails(c => c.ColorId == id);
        }

        public List<CarDetailDto> GetCarsDetailDto()
        {
            return _carDal.GetCarDetails();
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Araba güncelleme başarılı.");
        }

    }
}
