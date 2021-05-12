using System;
using UnitTestingDemo.Models.Sales;

namespace UnitTestingDemo.Services.Sales
{
	public interface IPriceResolver
	{
		decimal? GetPrice(Customer customer, Product product);
	}
}