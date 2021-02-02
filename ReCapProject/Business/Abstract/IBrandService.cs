using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll();
        Brand GetById(int brandId);
        void Add(Brand brand);
        void Update(Brand brand);
        void Delete(Brand brand);
    }
}
