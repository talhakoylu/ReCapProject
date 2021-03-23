using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [CacheAspect()]
        public IDataResult<List<Color>> GetAll()
        {
            var result = _colorDal.GetAll();
            if (result == null)
            {
                return new ErrorDataResult<List<Color>>(Messages.ColorGetAllError);
            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorGetAllSuccess);
        }

        [CacheAspect()]
        public IDataResult<Color> GetById(int colorId)
        {
            var result = _colorDal.Get(c => c.ColorId == colorId);
            if (result == null)
            {
                return new ErrorDataResult<Color>(Messages.ColorGetByIdError);
            }
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == colorId), Messages.ColorGetByIdSuccess);
        }

        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspects("IColorService.Get")]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAddSuccess);
        }

        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspects("IColorService.Get")]
        public IResult Update(Color color)
        {
            var result = _colorDal.Get(c => c.ColorId == color.ColorId);
            if (result == null)
            {
                return new ErrorResult(Messages.ColorUpdateError);
            }

            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdateSuccess);
        }

        //[SecuredOperation("admin")]
        [CacheRemoveAspects("IColorService.Get")]
        public IResult Delete(Color color)
        {
            var result = _colorDal.Get(c => c.ColorId == color.ColorId);
            if (result == null)
            {
                return new ErrorResult(Messages.ColorDeleteError);
            }

            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleteSuccess);
        }
    }
}
