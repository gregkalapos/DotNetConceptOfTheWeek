using System;
namespace SampleAppWithRssFeed.Models
{
	public class BlogItem
	{
		public String Title { get; set; }
		public String PreviewText { get; set; }
		public DateTime PublishDate { get; set; }
        public String Path { get; set; }
	}
}