using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscountManegment.Domain.ColleagueDiscountbtAgg;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountManagement.Infrastructure.EFCore.Mapping
{
    public class ColleagueDiscountMapping:IEntityTypeConfiguration<Colleague>
    {
        public void Configure(EntityTypeBuilder<Colleague> builder)
        {
            builder.ToTable("Colleagues");
            builder.HasKey(x => x.Id);
        }
    }
}
