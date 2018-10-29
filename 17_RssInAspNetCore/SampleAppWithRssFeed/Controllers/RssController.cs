using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using SampleAppWithRssFeed.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleAppWithRssFeed.Controllers
{
    [Produces("application/xml")]
    public class RssController : Controller
    {
        private readonly IBlogDataStorage blogData;

        public RssController(IBlogDataStorage blogData)
        {
            this.blogData = blogData;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            XNamespace ns = "http://www.w3.org/2005/Atom";
            var rss = new XElement("rss", new XAttribute("version", "2.0"), new XAttribute(XNamespace.Xmlns + "atom", ns));

            var channel = new XElement("channel",
                new XElement("title", "kalapos.net"),
                new XElement("link", "https://www.kalapos.net"),
                new XElement("description", "About programming and software engineering by a hungarian living in austria"),
                new XElement("language", "en-us"),
                //todo: add blogChannel tags
                new XElement("copyright", $"Copyright 2014-{DateTime.UtcNow.Year} Gergely Kalapos"),
                new XElement("lastBuildDate", blogData.BlogItems.OrderByDescending(n => n.PublishDate).First().PublishDate.ToUniversalTime().ToString("r")),
                new XElement("category", "Software Engineering"),
                new XElement(ns + "link", new XAttribute("href", "https://kalapos.net/Rss"), new XAttribute("rel", "self"), new XAttribute("type", "application/rss+xml")),
                new XElement("image",
                             new XElement("url", "https://kalapos.net/images/GergelyKalapos.small.jpg"),
                             new XElement("title", "kalapos.net"),
                             new XElement("link", "https://www.kalapos.net")
                            ),
                new XElement("ttl", "40")
             );

            foreach (var post in blogData.BlogItems)
            {
                var postInRss = new XElement("item");
                postInRss.Add(new XElement("title", post.Title));
                postInRss.Add(new XElement("description", HtmlEncoder.Default.Encode(post.PreviewText)));
                postInRss.Add(new XElement("link", "https://kalapos.net/Blog/ShowPost/" + post.Path));
                postInRss.Add(new XElement("author", "gergo@kalapos.net (Gergely Kalapos)"));
                postInRss.Add(new XElement("pubDate", post.PublishDate.ToUniversalTime().ToString("r")));
                postInRss.Add(new XElement("guid", post.Path + "#When" + post.PublishDate.ToUniversalTime()
                                           .ToString(CultureInfo.InvariantCulture).Replace(" ", String.Empty), new XAttribute("isPermaLink", "false")));
                channel.Add(postInRss);
            }

            rss.Add(channel);

            return Ok(rss);
        }
    }
}
