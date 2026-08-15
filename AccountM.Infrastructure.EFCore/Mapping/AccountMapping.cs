using AccountManagement.Domain.RoleAgg;
using AM.Domain.Account.AD;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountM.Infrastructure.EFCore.Mapping
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(x => x.Family)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(x => x.PhoneNumber)
                   .IsRequired()
                   .HasMaxLength(20);

            builder.Property(x => x.Email)
                   .IsRequired()
                   .HasMaxLength(250);

            builder.Property(x => x.BirthDate)
                   .IsRequired();

            builder.Property(x => x.CreationDate)
                   .IsRequired();

            builder.Property(x => x.Address)
                   .HasMaxLength(500);


            builder.Property(x => x.Password)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(x => x.Picture)
                   .HasMaxLength(500);

            builder.Property(x => x.IsAvalable)
                   .IsRequired();

            builder.Property(x => x.RoleId)
                   .IsRequired();

            // رابطه با Role (چند Account برای یک Role)
            builder.HasOne<Role>()
                   .WithMany(x => x.Accounts)
                   .HasForeignKey(x => x.RoleId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
