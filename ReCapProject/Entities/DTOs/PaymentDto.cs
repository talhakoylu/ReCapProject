using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class PaymentDto : IDto
    {
        public Rental Rental { get; set; }
        public Payment Payment { get; set; }
    }
}
