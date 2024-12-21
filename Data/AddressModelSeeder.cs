public class AddressModelSeeder
{
  private readonly AddressContext _context;

  public AddressModelSeeder(AddressContext context)
  {
    _context = context;
  }

  public void Seed()
  {
    // Clear existing data
    _context.Addresses.RemoveRange(_context.Addresses);
    _context.SaveChanges();

    _context.Addresses.AddRange(
        new AddressModel { StreetAddress = "123 Main Street", City = "Anytown", State = "CA", ZipCode = "12345" },
        new AddressModel { StreetAddress = "456 Oak Avenue", City = "Springfield", State = "IL", ZipCode = "54321" }
    );

    _context.SaveChanges();
  }
}
