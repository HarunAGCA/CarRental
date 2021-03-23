using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UpdateCarImageDto:IDto
    {
        public int Id { get; set; }

        public IFormFile Image { get; set; }

    }
}
