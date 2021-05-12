using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UnitTestingDemo.Services.Sales
{
	public interface ICustomerSelectOptions
	{
		IEnumerable<SelectListItem> GetSelectListItems();
	}
}