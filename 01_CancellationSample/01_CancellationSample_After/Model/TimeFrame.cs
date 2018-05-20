using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CancellationSample.Model
{
	public enum TimeFrame
	{
		[Display(Name = "1 Day")]
		Day1,
		[Display(Name = "1 Week")]
		Week1,
		[Display(Name = "1 Month")]
		Month1,
		[Display(Name = "2 Months")]
		Month2,
		[Display(Name = "3 Months")]
		Month3,
		[Display(Name = "6 Months")]
		Month6,
		[Display(Name = "1 Year")]
		Year1,
		[Display(Name = "All")]
		All
	}
}
