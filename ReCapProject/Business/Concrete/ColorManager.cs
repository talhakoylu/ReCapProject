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
            return _colorDal.Get(c => c.ColorId == colorId);
        }

        public void Add(Colors color)
        {
            _colorDal.Add(color);
            Console.WriteLine("Renk ekleme başarılı.");
        }

        public void Update(Colors color)
        {
            _colorDal.Update(color);
            Console.WriteLine("Renk güncelleme başarılı.");
        }

        public void Delete(Colors color)
        {
            _colorDal.Delete(color);
            Console.WriteLine("Renk silme başarılı.");
        }
    }
}
