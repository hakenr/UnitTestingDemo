using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestingDemo.Models.Sales;

namespace UnitTestingDemo.Repositories.Sales
{
	public interface IProductRepository
	{
		IEnumerable<Product> GetAll();

		Product GetObject(int productId);
	}
}