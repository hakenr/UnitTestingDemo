using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitTestingDemo.Models;
using UnitTestingDemo.Repositories.Sales;
using UnitTestingDemo.Services.Sales;

namespace UnitTestingDemo
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("demo"));

			// Add application services.
			services.AddTransient<IPriceResolver, PriceResolver>();

			// repositories
			services.AddTransient<IBasicPriceRepository, BasicPriceRepository>();
			services.AddTransient<ICustomerRepository, CustomerRepository>();
			services.AddTransient<ICustomerPriceRepository, CustomerPriceRepository>();
			services.AddTransient<ICustomerProductGroupDiscountRepository, CustomerProductGroupDiscountRepository>();
			services.AddTransient<IProductRepository, ProductRepository>();

			// UI services
			services.AddTransient<ICustomerSelectOptions, CustomerSelectOptions>();
			services.AddTransient<IProductSelectOptions, ProductSelectOptions>();

			// MVC
			services.AddControllersWithViews();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			// Initial data seed
			using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
				context.EnsureSeedData();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});
		}
	}
}
