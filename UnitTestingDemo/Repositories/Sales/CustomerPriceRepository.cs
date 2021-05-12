using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestingDemo.Models;
using UnitTestingDemo.Models.Sales;

namespace UnitTestingDemo.Repositories.Sales
{
	public class CustomerPriceRepository : ICustomerPriceRepository
	{
		private readonly ApplicationDbContext applicationDbContext;

		public CustomerPriceRepository(ApplicationDbContext applicationDbContext)
		{
			this.applicationDbContext = applicationDbContext;
		}

		public decimal? GetCustomerPrice(Customer customer, Product product)
		{
			return applicationDbContext.CustomerPrices.SingleOrDefault(p => (p.Customer.CustomerId == customer.CustomerId) && (p.Product.ProductId == product.ProductId))?.Price;
		}
	}
}