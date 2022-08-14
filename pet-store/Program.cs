using Microsoft.EntityFrameworkCore;
using pet_store.DAL;
using pet_store.Services.AdminServices;
using pet_store.Services.AnimalServices;
using pet_store.Services.CatalogServices;
using pet_store.Services.HomeServices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PetStoreContext>(options => options.UseSqlite("Data Source=c:\\temp1\\animalDb.db"));
builder.Services.AddTransient<IHomeRepository, HomeRepository>();
builder.Services.AddTransient<ICatalogRepository, CatalogRepository>();
builder.Services.AddTransient<IAnimalRepository, AnimalRepository>();
builder.Services.AddTransient<IAdminRepository, AdminRepository>();
builder.Services.AddControllersWithViews();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<PetStoreContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

app.UseStaticFiles();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllerRoute("default", "{controller=Home}/{Action=Index}/{id?}"));

app.Run();





/*
 * 1. finish the edit and the delete in the server
 * 1.5. check all the places with combobox
 * 2. make an option to move to all categories in the catalog
 * 2.5. in add new animal - instead of category name - make combobox
 * 3. make all the views pretty, put only what i need there
 * 4. handle all the exeptions - (where i have an option to enter a name of category or id that is not exist etc...)
 * 5. make an 404 page
 */