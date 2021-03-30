using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Entities.Concrete;

namespace Entities.DTOs
{
    public class UserProfileUpdateDto : IDto
    {
        public User User { get; set; }
        public string Password { get; set; }
    }
}
