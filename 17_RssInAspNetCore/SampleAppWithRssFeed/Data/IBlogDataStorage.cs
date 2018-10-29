using System;
using System.Collections.Generic;
using SampleAppWithRssFeed.Models;

namespace SampleAppWithRssFeed.Data
{
	public interface IBlogDataStorage
	{
		List<BlogItem> BlogItems { get; }
	}
}
