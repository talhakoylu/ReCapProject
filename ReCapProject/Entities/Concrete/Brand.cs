using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Brand:IEntity
    {
        [Key]
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
