using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VSTest.DAL.Entities;
using VSTest.DAL.Interfaces;

namespace VSTest.DAL;

public class VSDbContext : DbContextBase, IUnitOfWork
{
    public virtual DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.json")
                 .Build()
                 .GetConnectionString("vs-db");

        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>().ToTable("Customer", "dbo");
        modelBuilder.Entity<Customer>().HasKey(c => c.ID);
        modelBuilder.Entity<Customer>().Property(c => c.ID).HasColumnName("ID").IsRequired();
        modelBuilder.Entity<Customer>().Property(c => c.Name).HasColumnName("Name").HasMaxLength(255).IsRequired();
        modelBuilder.Entity<Customer>().Property(c => c.Surname).HasColumnName("Surname").HasMaxLength(255).IsRequired();
        modelBuilder.Entity<Customer>().Property(c => c.Patronymic).HasColumnName("Patronymic").HasMaxLength(255);
        modelBuilder.Entity<Customer>().Property(c => c.Birthday).HasColumnName("Birthday").IsRequired();
        modelBuilder.Entity<Customer>().Property(c => c.PhoneNumber).HasColumnName("PhoneNumber").HasMaxLength(15).IsRequired();
    }

    public override async Task SaveAsync(CancellationToken cancellationToken = default)
        => await SaveChangesAsync(cancellationToken);
}
