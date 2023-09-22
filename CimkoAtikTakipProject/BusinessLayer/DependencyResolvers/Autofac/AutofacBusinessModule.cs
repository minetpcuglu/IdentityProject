using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Castle.DynamicProxy;
using CoreLayer.DataAccess.Abstract;
using CoreLayer.DataAccess.EntityFramework;
using CoreLayer.Utilities;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntiityFramework;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.DependencyResolvers.Autofac
{
	public class AutofacBusinessModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<DatabaseContext>().AsSelf().InstancePerLifetimeScope();
			builder.RegisterType<DbContextOptions<DatabaseContext>>().AsSelf().InstancePerLifetimeScope();

			builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

			
			builder.RegisterType<CityRepository>().As<ICityRepository>().InstancePerLifetimeScope().SingleInstance();
			builder.RegisterType<CityService>().As<ICityService>().InstancePerLifetimeScope().SingleInstance();

			builder.RegisterType<FactoryRepository>().As<IFactoryRepository>().InstancePerLifetimeScope().SingleInstance();
			builder.RegisterType<FactoryService>().As<IFactoryService>().InstancePerLifetimeScope().SingleInstance();

			builder.RegisterType<DistrictRepository>().As<IDistrictRepository>().InstancePerLifetimeScope().SingleInstance();
			builder.RegisterType<DistrictService>().As<IDistrictService>().InstancePerLifetimeScope().SingleInstance();

			builder.RegisterType<WasteFormRepository>().As<IWasteFormRepository>().InstancePerLifetimeScope().SingleInstance();
			builder.RegisterType<WasteFormService>().As<IWasteFormService>().InstancePerLifetimeScope().SingleInstance();

			builder.RegisterType<WasteFormImageRepository>().As<IWasteFormImageRepository>().InstancePerLifetimeScope().SingleInstance();
			builder.RegisterType<WasteFormImageService>().As<IWasteFormImageService>().InstancePerLifetimeScope().SingleInstance();

			builder.RegisterType<WasteCodeRepository>().As<IWasteCodeRepository>().InstancePerLifetimeScope().SingleInstance();
			builder.RegisterType<WasteCodeService>().As<IWasteCodeService>().InstancePerLifetimeScope().SingleInstance();


			builder.RegisterType<StockingMethodRepository>().As<IStockingMethodRepository>().InstancePerLifetimeScope().SingleInstance();
			builder.RegisterType<StockingMethodService>().As<IStockingMethodService>().InstancePerLifetimeScope().SingleInstance();

			var assembly = System.Reflection.Assembly.GetExecutingAssembly();
			builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(
				new ProxyGenerationOptions()
				{
					Selector = new AspectInterceptorSelector()
				}).InstancePerLifetimeScope();
		}
	}
}
