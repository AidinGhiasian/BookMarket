using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountManegment.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountManagement.Infrastructure.EFCore.Mapping
{
    public class CustomerDiscountMapping:IEntityTypeConfiguration<CustomerDiscount>
    {
        public void Configure(EntityTypeBuilder<CustomerDiscount> builder)
        {
            builder.ToTable("CustomerDiscounts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DiscountRate).HasMaxLength(500).IsRequired();
            builder.Property(x => x.EndDate).HasMaxLength(500).IsRequired();
            builder.Property(x => x.StartDate).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Reason).HasMaxLength(500).IsRequired();
           


        }
    }
}
