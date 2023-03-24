using DR_RSS_Feed;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

XDocument.Load("https://www.dr.dk/nyheder/service/feeds/senestenyt").Root.Element("channel").Elements("item").Select(x => new { Title = x.Element("title").Value, Link = x.Element("link").Value, PubDate = x.Element("pubDate").Value }).ToList().ForEach(x => Console.WriteLine($"{x.Title}\n{x.Link}\n{x.PubDate}\n"));

Console.WriteLine();

XmlSerializer serializer = new(typeof(Rss));
Rss? rss = (Rss?)serializer.Deserialize(XmlReader.Create("https://www.dr.dk/nyheder/service/feeds/senestenyt"));

rss?.Channel.Item.ForEach(x => Console.WriteLine($"{x.Title}\n{x.Link}\n{x.PubDate}\n"));
