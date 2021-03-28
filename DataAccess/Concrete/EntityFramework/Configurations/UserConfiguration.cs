using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(50).IsRequired();
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.IsBlocked).IsRequired();
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.PasswordSalt).IsRequired();

            builder.HasData(
                new User
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "admin@example.com",
                    PasswordHash = new byte[64] { 25, 78, 12, 92, 111, 47, 220, 165, 88, 193, 137, 155, 106, 86, 184, 96, 229, 59, 65, 45, 136, 21, 33, 31, 201, 28, 45, 161, 102, 190, 63, 226, 118, 235, 61, 204, 166, 132, 91, 17, 74, 128, 161, 200, 57, 131, 214, 187, 25, 6, 45, 7, 94, 201, 113, 22, 27, 221, 109, 204, 248, 51, 173, 142 },
                    PasswordSalt = new byte[128] { 135, 81, 181, 173, 15, 182, 157, 117, 198, 58, 203, 141, 46, 25, 114, 105, 105, 57, 189, 210, 36, 224, 140, 242, 133, 214, 125, 70, 33, 75, 131, 136, 213, 146, 255, 188, 25, 246, 68, 60, 251, 42, 176, 165, 32, 122, 1, 245, 207, 192, 98, 154, 243, 247, 90, 130, 139, 49, 220, 148, 20, 187, 65, 25, 107, 37, 178, 247, 229, 186, 133, 213, 242, 206, 40, 158, 242, 243, 213, 181, 102, 79, 2, 147, 47, 242, 183, 138, 146, 113, 93, 70, 26, 22, 157, 122, 37, 126, 136, 251, 21, 248, 112, 135, 136, 24, 183, 19, 145, 230, 35, 248, 182, 47, 45, 201, 76, 209, 251, 241, 171, 69, 254, 128, 239, 61, 167, 47 },
                    IsBlocked = false,

                }) ;
        }

    }
}
