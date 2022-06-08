using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Identity.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "cayd12ao4-k3el-3002-sowx-12sdsw29sddw",
                    UserId = "3f200298-19f0-1098-fa02-9802f010ctc0"
                },

                new IdentityUserRole<string>
                {
                    RoleId = "mzx3o4d-o2wc-0204-osdo-1ssw301oxcvob",
                    UserId = "2o031306-d503-0340-z0x2-1305x504doe4"
                }
           );
        }
    }
}
