using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorService
    {
        List<Colors> GetAll();
        Colors GetById(int colorId);
        void Add(Colors color);
        void Update(Colors color);
        void Delete(Colors color);
    }
}
