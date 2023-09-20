using Autofac.Extensions.DependencyInjection;
using Autofac;
using BusinessLayer.DependencyResolvers.Autofac;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
	.ConfigureContainer<Autofac.ContainerBuilder>(b =>
	{

		b.RegisterModule(new AutofacBusinessModule());

	});
Bootstrapper.InitializeContainer(builder.Services);


builder.Services.AddMvc();
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services
	.AddControllersWithViews().AddRazorRuntimeCompilation()
	.AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);


builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
