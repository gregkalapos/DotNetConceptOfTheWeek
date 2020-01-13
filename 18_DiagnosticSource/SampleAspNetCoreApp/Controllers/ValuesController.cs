using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace SampleAspNetCoreApp.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class Values : ControllerBase
	{
		[HttpGet]
		public IEnumerable<string> Get()
		{
			var activity = Activity.Current;

			if (activity != null)
			{
				foreach (var baggageItem in activity.Baggage)
				{
					Console.WriteLine($"baggage item: {baggageItem.Key}-{baggageItem.Value}");
				}

				Console.WriteLine($"activity id: {activity.Id}");
				Console.WriteLine($"activity parentId: {activity.ParentId}");
			}

			return new List<string> { "1", "2" };
		}
	}
}
