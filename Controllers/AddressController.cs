using Microsoft.AspNetCore.Mvc;


namespace MyRazorMvcApp.Controllers
{

  public class AddressController : Controller
  {
    private readonly AddressContext _context;

    public AddressController(AddressContext context)
    { _context = context; }

    public IActionResult Index()
    {
      var addresses = _context.Addresses.ToList();
      return View(addresses);
    }
  }
}
