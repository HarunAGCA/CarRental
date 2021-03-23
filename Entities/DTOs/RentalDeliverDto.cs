using Core.Entities;
using System;

namespace Entities.DTOs
{
    public class RentalDeliverDto:IDto
    {
        public int RentalId { get; set; }

        public DateTime ReturnDate { get; set; }
    }
}