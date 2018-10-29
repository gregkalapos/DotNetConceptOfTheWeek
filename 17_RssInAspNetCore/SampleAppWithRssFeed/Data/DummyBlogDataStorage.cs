using System;
using System.Collections.Generic;
using SampleAppWithRssFeed.Models;

namespace SampleAppWithRssFeed.Data
{
	public class DummyBlogDataStorage : IBlogDataStorage
	{
		public List<BlogItem> BlogItems =>
		new List<BlogItem>
		{
			new BlogItem
			{
				PreviewText = "This is the first blog item.",
				PublishDate = new DateTime(2018, 3, 4, 14,22,10),
				Title = "1. Blogpost",
                Path = "Post1"
			},
			new BlogItem
			{
				PreviewText = "This is the second blog item.",
				PublishDate = new DateTime(2018, 5, 13, 21,10,53),
				Title = "2. Blogpost",
                Path = "Post2"
            },
			new BlogItem
			{
				PreviewText = "This is the third blog item.",
				PublishDate = new DateTime(2018, 7, 2, 23,43,55),
				Title = "3. Blogpost",
                Path = "Post3"
            },
			new BlogItem
			{
				PreviewText = "This is the 4th blog item.",
				PublishDate = new DateTime(2018, 8, 2, 11,21,03),
				Title = "4. Blogpost",
                Path = "Post4"
            }
		};
	}
}
