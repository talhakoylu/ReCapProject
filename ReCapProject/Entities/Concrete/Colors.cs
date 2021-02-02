using System;
using System.Collections.Generic;
using System.Text;
using Entities.Abstract;

namespace Entities.Concrete
{
    
    public class Colors:IEntity
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }

    }
}
