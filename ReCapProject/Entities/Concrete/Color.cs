using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    
    public class Color:IEntity
    {
        [Key]
        public int ColorId { get; set; }
        public string ColorName { get; set; }

    }
}
