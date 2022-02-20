using Microsoft.EntityFrameworkCore;
using ReadingsAPI.SeedData;
using System.ComponentModel.DataAnnotations;

public class ReadingsDbContext : DbContext
{
    public ReadingsDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Account> Accounts => Set<Account>();
    public DbSet<MeterReading> MeterReadings => Set<MeterReading>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MeterReading>()
            .Property(e => e.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<MeterReading>()
            .HasOne(p => p.Account)
            .WithMany(b => b.MeterReadings)
            .HasForeignKey(p => p.AccountId);

        TestAccounts testAccounts = new TestAccounts();
        foreach(Account account in testAccounts.GetAccounts())
        {
            modelBuilder.Entity<Account>().HasData(new Account { AccountId = account.AccountId, FirstName = account.FirstName, LastName = account.LastName });
        }
    }
}

public class Account
{
    public int AccountId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public virtual IList<MeterReading>? MeterReadings { get; set; }
}

public class MeterReading
{ 
    [Key]
    public int Id { get; set; }
    public DateTime? MeterReadingDateTime { get; set; }
    public string? MeterReadValue { get; set; }
    public int AccountId { get; set; }
    public virtual Account? Account { get; set; }
}
