using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AddressContext>(options =>
  options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<AddressModelSeeder>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Home/Error");
  // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
  app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

using (var scope = app.Services.CreateScope())
{
  if (scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>().IsDevelopment())
  {
    // Automatically update migrations on startup (Development only)
    var dbContext = scope.ServiceProvider.GetService<AddressContext>();
    if (dbContext != null)
    {
      dbContext.Database.Migrate();
    }

    // Get the instance of AddressSeeder from the service provider
    var seeder = scope.ServiceProvider.GetService<AddressModelSeeder>();

    if (seeder != null)
    {
      // Now call Seed on it to seed the data
      seeder.Seed();
    }
  }
}

app.Run();
