using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using session3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace session3.Configrations
{
    internal class OrderConfigration : IEntityTypeConfiguration<Order>

    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property("Address").HasDefaultValue("Tulkarm");
            builder.Property(p => p.Address).HasColumnType("varchar(30)");
        }
           
    }
}
