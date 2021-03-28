using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    class RentalConfiguration : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(c => c.CarId).IsRequired();
            builder.Property(c => c.CustomerId).IsRequired();
            builder.Property(c => c.RentDate).IsRequired();

            builder.HasData(new Rental { Id = 1, CarId = 2, CustomerId = 1, RentDate = DateTime.Now.AddDays(5) });
        }
    }
}
