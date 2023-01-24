namespace Crawler;

public class CrawlerService
{
    public List<Email> Crawl(string[] args)
    {
        var websiteUrl = args[0];
        var client = new HttpClient();
        var response = client.GetAsync(websiteUrl).Result;
        var body = response.Content.ReadAsStringAsync().Result;
        return EmailExtractor.Extract(body);
    }
}