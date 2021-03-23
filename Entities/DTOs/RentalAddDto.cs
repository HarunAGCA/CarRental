using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class RentalAddDto:IDto
    {
        public int CustomerId { get; set; }

        public int CarId { get; set; }

        public DateTime RentDate { get; set; }
        
    }
}
