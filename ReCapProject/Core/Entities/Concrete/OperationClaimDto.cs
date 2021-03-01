using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class OperationClaimDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
