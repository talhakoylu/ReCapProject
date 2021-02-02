using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal:IColorDal
    {
        private List<Colors> colors;

        public InMemoryColorDal()
        {
            colors = new List<Colors>()
            {
                new Colors() {ColorId = 1, ColorName = "blue", ColorCode = "#0572EC"},
                new Colors() {ColorId = 2, ColorName = "red", ColorCode = "#D0343A"},
                new Colors() {ColorId = 3, ColorName = "purple", ColorCode = "#63065F"},
            };
        }
        public List<Colors> GetAll()
        {
            return colors;
        }

        public Colors GetById(int colorId)
        {
            return colors.SingleOrDefault(c => c.ColorId == colorId);
        }

        public void Add(Colors color)
        {
            colors.Add(color);
        }

        public void Update(Colors color)
        {
            Colors colorToUpdate = colors.SingleOrDefault(c => c.ColorId == color.ColorId);
            colorToUpdate.ColorCode = color.ColorCode;
            colorToUpdate.ColorName = color.ColorName;
        }

        public void Delete(Colors color)
        {
            Colors colorToDelete = colors.SingleOrDefault(c => c.ColorId == color.ColorId);
            colors.Remove(colorToDelete);
        }
    }
}
