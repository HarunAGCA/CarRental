using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        public int UserId { get; set; }

        public string CompanyName { get; set; }

        public User User { get; set; }
    }
}
