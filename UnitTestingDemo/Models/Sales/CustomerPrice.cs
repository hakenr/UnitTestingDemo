﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestingDemo.Models.Sales
{
	public class CustomerPrice
	{
		public int CustomerPriceId { get; set; }

		public Product Product { get; set; }

		public Customer Customer { get; set; }

		public decimal Price { get; set; }
	}
}