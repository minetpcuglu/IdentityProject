using IdentityProject.BusinessLayer.AppUser;
using IdentityProject.DataAccessLayer.Abstract;
using IdentityProject.DataAccessLayer.Concrete;
using IdentityProject.DataAccessLayer.DbContext;
using IdentityProject.EntityLayer.Concrete;
using IdentityProject.PresentationLayer.Configuration;
using IdentityProject.PresentationLayer.Models;
using Microsoft.AspNet.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc();
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<DatabaseContext>().AddErrorDescriber<CustomIdentityValidator>();
//builder.Services.AddMyServices();
//builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IAppUserService, AppUserService>();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Register}/{action=Index}/{id?}");

app.Run();
