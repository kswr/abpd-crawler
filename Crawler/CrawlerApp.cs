using System.Reflection.Metadata.Ecma335;

namespace Crawler;

public class CrawlerApp
{
    public static void Main(string[] args)
    {
        var crawlerService = new CrawlerService();
        var emails = crawlerService.Crawl(args);
        foreach (var email in emails)
        {
            Console.WriteLine(email);
        }
    }
}