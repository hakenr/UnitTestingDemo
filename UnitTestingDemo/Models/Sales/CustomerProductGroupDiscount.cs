using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestingDemo.Models.Sales;

namespace UnitTestingDemo.Models.Sales
{
	public class CustomerProductGroupDiscount
	{
		public int CustomerProductGroupDiscountId { get; set; }

		public ProductGroup	ProductGroup { get; set; }

		public Customer Customer { get; set; }

		public decimal Discount { get; set; }
	}
}