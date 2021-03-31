using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class ColorReturnDto:IDto
    {
        public short Id { get; set; }

        public string Name { get; set; }
    }
}
