using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalAccount.API.Models;

namespace PersonalAccount.DB.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(a => a.Id);
        
        builder.HasMany<Resident>()
            .WithOne(a => a.PersonalAccount)
            .HasForeignKey(r => r.PersonalAccountId);
        
        builder.OwnsOne(a => a.Address);
    }
}

public class ResidentConfiguration : IEntityTypeConfiguration<Resident>
{
    public void Configure(EntityTypeBuilder<Resident> builder)
    {
        builder.HasKey(r => r.Id);

        builder.HasOne(r => r.PersonalAccount)
            .WithMany(a => a.Residents)
            .HasForeignKey(r => r.PersonalAccountId);
    }
}