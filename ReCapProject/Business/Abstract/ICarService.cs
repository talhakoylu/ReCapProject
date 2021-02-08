using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        Car GetById(int id);
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        List<CarDetailDto> GetCarsByBrandId(int id);
        List<CarDetailDto> GetCarsByColorId(int id);
        List<CarDetailDto> GetCarsDetailDto();
    }
}
