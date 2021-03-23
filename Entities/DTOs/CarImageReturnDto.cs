using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class CarImageReturnDto:IDto
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public string Path { get; set; }

        public DateTime UploadDate { get; set; }
    }
}
