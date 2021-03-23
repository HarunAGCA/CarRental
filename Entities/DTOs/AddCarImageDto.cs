using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class AddCarImageDto:IDto
    {
        public List<IFormFile> Images { get; set; }

        public int CarId { get; set; }
    }
}
