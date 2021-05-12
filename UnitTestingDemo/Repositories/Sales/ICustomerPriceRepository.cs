using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestingDemo.Models.Sales;

namespace UnitTestingDemo.Repositories.Sales
{
	public interface ICustomerPriceRepository
	{
		decimal? GetCustomerPrice(Customer customer, Product product);
	}
}