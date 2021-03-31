using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarReturnDto:IDto
    {
        public int Id { get; set; }

        public short BrandId { get; set; }

        public short ColorId { get; set; }

        public string Name { get; set; }

        public short ModelYear { get; set; }

        public decimal DailyPrice { get; set; }

        public string Description { get; set; }
    }
}
