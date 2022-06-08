using Ecommerce.Identity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Identity.Configuration
{
    public class UserAddressConfiguration : IEntityTypeConfiguration<Address>
    {

        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasData(
                new Address
                {
                    Id = 1,
                    AppUserId = "3f200298-19f0-1098-fa02-9802f010ctc0",
                    FirstName = "System",
                    LastName = "User",
                    Street = "SoldinerStr 20",
                    City = "Berlin",
                    State = "Wedding",
                    ZipCode = "12345"
                },
                new Address
                {
                    Id = 2,
                    AppUserId = "2o031306-d503-0340-z0x2-1305x504doe4",
                    FirstName = "System",
                    LastName = "Admin",
                    Street = "KolonieStr 12",
                    City = "Berlin",
                    State = "Wedding",
                    ZipCode = "12345"
                }
                );
        }
    }
}
