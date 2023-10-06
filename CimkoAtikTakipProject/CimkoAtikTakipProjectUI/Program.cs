using Autofac.Extensions.DependencyInjection;
using Autofac;
using BusinessLayer.DependencyResolvers.Autofac;
using AutoMapper;
using CimkoAtikTakipProjectUI.AutoMapper;

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

var mapperConfig = new MapperConfiguration(cfg =>
{
	cfg.AddProfile<MappingProfile>();
});

// IMapper arabirimini uygulayýn ve AutoMapper yapýlandýrmasýný kullanýn
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


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
    pattern: "{controller=WasteForm}/{action=NewWasteForm}/{id?}");

app.Run();
