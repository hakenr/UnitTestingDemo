using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestingDemo.Models.Sales;

namespace UnitTestingDemo.Repositories.Sales
{
	public interface ICustomerRepository
	{
		IEnumerable<Customer> GetAll();

		Customer GetObject(int customerId);
	}
}