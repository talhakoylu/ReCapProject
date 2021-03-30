using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class UserCreditCard : IEntity
    {
        public int Id { get; set; }
        public string CardName { get; set; }
        public string NameOnCard { get; set; }
        public string CardNumber { get; set; }
        public string CardYear { get; set; }
        public string CardMonth { get; set; }
        public int UserId { get; set; }

    }
}
