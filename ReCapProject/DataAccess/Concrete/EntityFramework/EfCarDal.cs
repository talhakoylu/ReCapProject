using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from c in context.Cars
                             join brand in context.Brands on c.BrandId equals brand.BrandId
                             join color in context.Colors on c.ColorId equals color.ColorId
                             //join carImage in context.CarImages on c.CarId equals carImage.CarId
                             select new CarDetailDto()
                             {
                                 CarId = c.CarId,
                                 BrandName = brand.BrandName,
                                 ColorName = color.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 ColorId = c.ColorId,
                                 BrandId = brand.BrandId,
                                 //CarImagePath = carImage.ImagePath
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
    }
}
