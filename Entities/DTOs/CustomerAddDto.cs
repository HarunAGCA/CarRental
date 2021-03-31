using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
   public class CustomerDto:IDto
    {

        public int UserId { get; set; }

        public string CompanyName { get; set; }
    }
}
