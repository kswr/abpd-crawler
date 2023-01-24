using System.Reflection.Metadata.Ecma335;

namespace Crawler;

public class CrawlerApp
{
    public static void Main(string[] args)
    {
        var httpClient = new HttpClient();
        var crawlerService = new CrawlerService(httpClient);
        var emails = crawlerService.Crawl(args);
        foreach (var email in emails)
        {
            Console.WriteLine(email);
        }
        httpClient.Dispose();
    }
}