using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    class CarImageConfiguration : IEntityTypeConfiguration<CarImage>
    {
        public void Configure(EntityTypeBuilder<CarImage> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.CarId).IsRequired();
            builder.Property(c => c.FileName).IsRequired();
            builder.Property(c => c.UploadDate).IsRequired();
        }
    }
}
