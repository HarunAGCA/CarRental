using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired();

            builder.HasData(
                new Color { Id = 1, Name = "Kırmızı" },
                new Color { Id = 2, Name = "Mavi" },
                new Color { Id = 3, Name = "Gri" }
                );
        }
    }
}
