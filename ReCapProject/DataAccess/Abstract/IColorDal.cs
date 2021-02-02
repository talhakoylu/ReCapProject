using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IColorDal
    {
        List<Colors> GetAll();
        Colors GetById(int colorId);
        void Add(Colors color);
        void Update(Colors color);
        void Delete(Colors color);
    }
}
