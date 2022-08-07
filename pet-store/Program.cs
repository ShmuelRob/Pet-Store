using Microsoft.EntityFrameworkCore;
using pet_store.DAL;
using pet_store.Services.AdminServices;
using pet_store.Services.AnimalServices;
using pet_store.Services.CatalogServices;
using pet_store.Services.HomeServices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PetStoreContext>(options => options.UseSqlite("Data Source=c:\\temp1\\animalDb.db"));
builder.Services.AddTransient<IHomeContext, HomeContext>();
builder.Services.AddTransient<ICatalogContext, CatalogContext>();
builder.Services.AddTransient<IAnimalContext, AnimalContext>();
builder.Services.AddTransient<IAdminContext, AdminContext>();
//builder.Services.AddTransient<ICreateService, CreateService>();
//builder.Services.AddTransient<IDeleteService, DeleteService>();
//builder.Services.AddTransient<IUpdateService, UpdateService>();
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

app.UseEndpoints(e => e.MapDefaultControllerRoute());
//app.UseEndpoints(endpoints => endpoints.MapControllerRoute("default", "{controller=home}/{Action=index}"));
//app.UseEndpoints(endpoints => endpoints.MapControllerRoute("default", "{controller=Home}/{Action=Index}/{id?}"));

app.Run();
