using Microsoft.EntityFrameworkCore;
using pet_store.DAL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PetStoreContext>(options => options.UseSqlite("Data Source=c:\\temp1\\firstDb.db"));
builder.Services.AddControllersWithViews();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<PetStoreContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}

app.UseRouting();

app.UseEndpoints(e => e.MapDefaultControllerRoute());
//app.UseEndpoints(endpoints => endpoints.MapControllerRoute("default", "{controller=home}/{Action=index}"));
//app.UseEndpoints(endpoints => endpoints.MapControllerRoute("default", "{}/{}/{}"));

app.Run();
