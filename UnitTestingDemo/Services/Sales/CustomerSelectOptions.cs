using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using UnitTestingDemo.Repositories.Sales;

namespace UnitTestingDemo.Services.Sales
{
	public class CustomerSelectOptions : ICustomerSelectOptions
	{
		private readonly ICustomerRepository customerRepository;

		public CustomerSelectOptions(ICustomerRepository customerRepository)
		{
			this.customerRepository = customerRepository;
		}

		public IEnumerable<SelectListItem> GetSelectListItems()
		{
			return customerRepository.GetAll().Select(customer => new SelectListItem() { Value = customer.CustomerId.ToString(), Text = customer.Name });
		}
	}
}