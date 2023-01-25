using Crawler;

namespace CrawlerTest;

public class CrawlerServiceTest
{
    private readonly HttpClient _httpClient = new();

    [Test]
    public void CrawlPjatk()
    {
        var crawler = new CrawlerService(_httpClient);
        var result = crawler.Crawl(new[] { "https://pja.edu.pl/" });
        Assert.That(result, Is.EqualTo(CrawlResult.Success(new HashSet<Email>{ Email.Of("pjatk@pja.edu.pl")})));
    }
}