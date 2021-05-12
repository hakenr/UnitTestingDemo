using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestingDemo.Models.Sales;

namespace UnitTestingDemo.Repositories.Sales
{
	public interface IBasicPriceRepository
	{
		decimal? GetBasicPriceForProduct(Product product);
	}
}