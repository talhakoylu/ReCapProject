using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager:IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public List<Colors> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Colors GetById(int colorId)
        {
            return _colorDal.GetById(colorId);
        }

        public void Add(Colors color)
        {
            _colorDal.Add(color);
        }

        public void Update(Colors color)
        {
            _colorDal.Update(color);
        }

        public void Delete(Colors color)
        {
            _colorDal.Delete(color);
        }
    }
}
