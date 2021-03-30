using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class Findeks : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Day { get; set; }
        public string NationalIdentity { get; set; }
        public int FindeksScore { get; set; }
    }
}
