using Microsoft.EntityFrameworkCore;
using PersonalAccount.API.Models;
using PersonalAccount.DB.Configurations;

namespace PersonalAccount.DB;

public class AccountContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }

    public AccountContext(DbContextOptions<AccountContext> options)
    : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfiguration())
            .ApplyConfiguration(new ResidentConfiguration());
    }
}

