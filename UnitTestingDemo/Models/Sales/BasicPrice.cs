﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestingDemo.Models.Sales
{
	public class BasicPrice
	{
		public int BasicPriceId { get; set; }

		public Product Product { get; set; }

		public decimal Price { get; set; }
	}
}