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

            builder.HasData(
                new CarImage { Id = 1, CarId = 1, UploadDate = DateTime.Now, FileName = "9c51a451-ac2b-4840-81cb-e9447bf97441.jpg" },
                new CarImage { Id = 2, CarId = 1, UploadDate = DateTime.Now, FileName = "62343bd3-b600-4911-ba92-a3e92460c91b.jpg" },
                new CarImage { Id = 3, CarId = 1, UploadDate = DateTime.Now, FileName = "e855898a-5e19-4e9e-82fa-421a884b353a.jpg" },
                new CarImage { Id = 4, CarId = 1, UploadDate = DateTime.Now, FileName = "f16ec7fb-bcfa-49b6-accc-87e92b6d3cc3.jpg" },
                new CarImage { Id = 5, CarId = 2, UploadDate = DateTime.Now, FileName = "3fa88654-2976-4cff-948c-e3e20c730c91.jpg" },
                new CarImage { Id = 6, CarId = 2, UploadDate = DateTime.Now, FileName = "7a6f413f-0d74-4584-89a2-ff7898a8623d.jpg" },
                new CarImage { Id = 7, CarId = 2, UploadDate = DateTime.Now, FileName = "2135828c-09f7-4c6a-a5df-3a137c9a138a.jpg" },
                new CarImage { Id = 8, CarId = 2, UploadDate = DateTime.Now, FileName = "ee9d8d7e-d89b-4d70-b012-4aa241fca70a.jpg" },
                new CarImage { Id = 9, CarId = 3, UploadDate = DateTime.Now, FileName = "33959098-8427-4200-bd6e-823c2890ff10.jpg" },
                new CarImage { Id = 10, CarId = 3, UploadDate = DateTime.Now, FileName = "c300ab97-d45f-439c-90b8-fd09a9426cc4.jpg" },
                new CarImage { Id = 11, CarId = 3, UploadDate = DateTime.Now, FileName = "2cca89e4-a7a4-44fe-b8ac-f50872a1395b.jpg" },
                new CarImage { Id = 12, CarId = 3, UploadDate = DateTime.Now, FileName = "af969d12-5a14-488d-8509-796efb2bd0b3.jpg" }
                );

        }
    }
}
