using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes.DTOs
{
    public class OrderDetailsDto:IDto
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public string CompanyName { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsDelivered { get; set; }
    }
}
