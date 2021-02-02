using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal:IBrandDal
    {
        private List<Brand> brands;

        public InMemoryBrandDal()
        {
            brands = new List<Brand>()
            {
                new Brand(){BrandId = 1, BrandName = "Brand 1"},
                new Brand(){BrandId = 2, BrandName = "Brand 2"},
                new Brand(){BrandId = 3, BrandName = "Brand 3"},
            };
        }
        public List<Brand> GetAll()
        {
            return brands;
        }

        public Brand GetById(int brandId)
        {
            return brands.SingleOrDefault(b => b.BrandId == brandId);
        }

        public void Add(Brand brand)
        {
            brands.Add(brand);
        }

        public void Update(Brand brand)
        {
            Brand brandToUpdate = brands.SingleOrDefault(b => b.BrandId == brand.BrandId);
            brandToUpdate.BrandName = brand.BrandName;
        }

        public void Delete(Brand brand)
        {
            Brand brandToDelete = brands.SingleOrDefault(b => b.BrandId == brand.BrandId);
            brands.Remove(brandToDelete);
        }
    }
}
