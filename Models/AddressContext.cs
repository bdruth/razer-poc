using Microsoft.EntityFrameworkCore;

public class AddressContext : DbContext
{
  public AddressContext(DbContextOptions<AddressContext> options) : base(options) { }

  public DbSet<AddressModel> Addresses { get; set; }
}
