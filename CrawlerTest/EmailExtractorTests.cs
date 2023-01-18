using Crawler;

namespace CrawlerTest;

public class EmailExtractorTests
{

    [Test]
    [TestCaseSource(nameof(ExtractsEmailCorrectlySource))]
    public void ExtractsEmailCorrectly(string text, List<Email> expectedEmails)
    {
        var extracted = EmailExtractor.Extract(text);
        Assert.That(extracted, Is.EqualTo(expectedEmails));
    }

    public static IEnumerable<TestCaseData> ExtractsEmailCorrectlySource()
    {
        yield return new TestCaseData(null, new List<Email>());
        yield return new TestCaseData("", new List<Email>());
        yield return new TestCaseData("email@gmail.com", new List<Email> { Email.Of("email@gmail.com") });
    }
}