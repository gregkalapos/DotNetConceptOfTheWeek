using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleAppWithRssFeed.Data;
using SampleAppWithRssFeed.Models;

namespace SampleAppWithRssFeed.Controllers
{
	public class HomeController : Controller
	{
		private readonly IBlogDataStorage blogDataStorage;

		public HomeController(IBlogDataStorage blogDataStorage)
		{
			this.blogDataStorage = blogDataStorage;
		}

		public IActionResult Index()
		{


			return View();
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
