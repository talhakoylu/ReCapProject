using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        private IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IDataResult<List<Brand>> GetAll()
        {
            var result = _brandDal.GetAll();
            if (result == null)
            {
                return new ErrorDataResult<List<Brand>>(Messages.BrandGetAllError);
            }

            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandGetAllSuccess);
        }

        public IDataResult<Brand> GetById(int brandId)
        {
            var result = _brandDal.Get(b => b.BrandId == brandId);
            if (result == null)
            {
                return new ErrorDataResult<Brand>(Messages.BrandGetError);
            }
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == brandId), Messages.BrandGetSuccess);
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length < 2)
            {
                return new ErrorResult(Messages.BrandAddError);
            }

            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAddSuccess);
        }

        public IResult Update(Brand brand)
        {
            var result = _brandDal.Get(b => b.BrandId == brand.BrandId);
            if (result == null)
            {
                return new ErrorResult(Messages.BrandUpdateError);
            }
            _brandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdateSuccess);
        }

        public IResult Delete(Brand brand)
        {
            var result = _brandDal.Get(b => b.BrandId == brand.BrandId);
            if (result == null)
            {
                return new ErrorResult(Messages.BrandDeleteError);
            }
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleteSuccess);
        }
    }
}
