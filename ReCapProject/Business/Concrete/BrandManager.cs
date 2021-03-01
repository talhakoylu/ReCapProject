using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

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

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BrandValidator))]
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAddSuccess);
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BrandValidator))]
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

        [SecuredOperation("admin")]
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
