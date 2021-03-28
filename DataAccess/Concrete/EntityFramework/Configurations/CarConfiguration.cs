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

            builder.HasData(new Car
            {
                Id = 1,
                BrandId = 1,
                ColorId = 1,
                Name = "SUV",
                DailyPrice = 250M,
                ModelYear = 2022,
                Description = "TOGG SUV model kırmızı"
            },
            new Car
            {
                Id = 2,
                BrandId = 1,
                ColorId = 2,
                Name = "SUV",
                DailyPrice = 250M,
                ModelYear = 2022,
                Description = "TOGG SUV model mavi"
            }, new Car
            {
                Id = 3,
                BrandId = 1,
                ColorId = 3,
                Name = "Sedan",
                DailyPrice = 200M,
                ModelYear = 2022,
                Description = "TOGG Sedan gri"
            }
            );
        }
    }
}
