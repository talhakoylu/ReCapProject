using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Car car)
        {
            if (car.Description.Length < 2)
            {
                return new ErrorResult(Messages.CarAddErrorName);
            }
            else if (car.DailyPrice <= 0)
            {
                return new ErrorResult(Messages.CarAddErrorDailyPrice);
            }

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAddSuccess);
        }

        public IResult Delete(Car car)
        {
            var result = _carDal.Get(c => c.CarId == car.CarId);
            if (result == null)
            {
                return new ErrorResult(Messages.CarDeleteError);
            }

            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleteSuccess);
        }

        public IDataResult<List<Car>> GetAll()
        {
            var result = _carDal.GetAll();
            if (result == null)
            {
                return new ErrorDataResult<List<Car>>(Messages.CarGetAllError);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarGetAllSuccess);
        }

        public IDataResult<Car> GetById(int id)
        {
            var result = _carDal.Get(c => c.CarId == id);
            if (result == null)
            {
                return new SuccessDataResult<Car>(Messages.CarGetByIdError);
            }
            
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == id), Messages.CarGetByIdSuccess);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByBrandId(int id)
        {
            var result = _carDal.GetCarDetails(c => c.BrandId == id);
            if (result == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.CarGetCarsByBrandIdError);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.BrandId == id), Messages.CarGetCarsByBrandIdSuccess);
        }

        public IDataResult<List<CarDetailDto>> GetCarsByColorId(int id)
        {
            var result = _carDal.GetCarDetails(c => c.ColorId == id);
            if (result == null)
            {
                return new ErrorDataResult<List<CarDetailDto>>(Messages.CarGetCarsByColorIdError);
            }
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(c => c.ColorId == id), Messages.CarGetCarsByColorIdSuccess);
        }

        public IDataResult<List<CarDetailDto>> GetCarsDetailDto()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarGetAllSuccess);
        }

        public IResult Update(Car car)
        {
            var result = _carDal.Get(c => c.CarId == car.CarId);
            if (result == null)
            {
                return new ErrorResult(Messages.CarUpdateError);
            }

            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdateSuccess);
        }

    }
}
