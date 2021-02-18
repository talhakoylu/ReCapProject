﻿using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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

        public IDataResult<List<Color>> GetAll()
        {
            var result = _colorDal.GetAll();
            if (result == null)
            {
                return new ErrorDataResult<List<Color>>(Messages.ColorGetAllError);
            }
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorGetAllSuccess);
        }

        public IDataResult<Color> GetById(int colorId)
        {
            var result = _colorDal.Get(c => c.ColorId == colorId);
            if (result == null)
            {
                return new ErrorDataResult<Color>(Messages.ColorGetByIdError);
            }
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == colorId), Messages.ColorGetByIdSuccess);
        }

        public IResult Add(Color color)
        {
            ValidationTool.Validate(new ColorValidator(), color);

            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAddSuccess);
        }

        public IResult Update(Color color)
        {
            var result = _colorDal.Get(c => c.ColorId == color.ColorId);
            if (result == null)
            {
                return new ErrorResult(Messages.ColorUpdateError);
            }

            ValidationTool.Validate(new ColorValidator(), color);

            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdateSuccess);
        }

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
