using Crawler;

namespace CrawlerTest;

public class CrawlerServiceTest
{
    [Test]
    public void CrawlPjatk()
    {
        var emails = CrawlerService.Crawl(new[] { "https://pja.edu.pl/" });
        Assert.That(emails, Has.Exactly(1).EqualTo(Email.Of("pjatk@pja.edu.pl")));
    }
}