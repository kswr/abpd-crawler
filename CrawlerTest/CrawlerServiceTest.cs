using Crawler;

namespace CrawlerTest;

public class CrawlerServiceTest
{
    private readonly HttpClient _httpClient = new();

    [Test]
    public void CrawlPjatk()
    {
        var crawler = new CrawlerService(_httpClient);
        var emails = crawler.Crawl(new[] { "https://pja.edu.pl/" });
        Assert.That(emails, Has.Exactly(1).EqualTo(Email.Of("pjatk@pja.edu.pl")));
    }
}