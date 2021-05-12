using Microsoft.AspNetCore.Mvc;
using UnitTestingDemo.Repositories.Sales;
using UnitTestingDemo.Services.Sales;
using UnitTestingDemo.ViewModels.Pricing;

namespace UnitTestingDemo.Controllers
{
	public class PricingController : Controller
	{
		private readonly IPriceResolver priceResolver;
		private readonly ICustomerRepository customerRepository;
		private readonly IProductRepository productRepository;

		public PricingController(IPriceResolver priceResolver, ICustomerRepository customerRepository, IProductRepository productRepository)
		{
			this.priceResolver = priceResolver;
			this.customerRepository = customerRepository;
			this.productRepository = productRepository;
		}

		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Index(GetPriceViewModel getPriceViewModel)
		{
			if (ModelState.IsValid)
			{
				var product = productRepository.GetObject(getPriceViewModel.ProductId);
				var customer = customerRepository.GetObject(getPriceViewModel.CustomerId);

				getPriceViewModel.Price = priceResolver.GetPrice(customer, product);

				return View(getPriceViewModel);
			}
			return View();
		}
		
	}
}