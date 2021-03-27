using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.BrandId).IsRequired();
            builder.Property(c => c.ColorId).IsRequired();
            builder.Property(c => c.DailyPrice).IsRequired();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.ModelYear).IsRequired();
            builder.Property(c => c.Description).IsRequired();
        }
    }
}
