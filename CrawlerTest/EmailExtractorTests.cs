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
        yield return new TestCaseData("asdf<email@gmail.com", new List<Email> { Email.Of("email@gmail.com") });
        yield return new TestCaseData("asdf email@gmail.com asdf", new List<Email> { Email.Of("email@gmail.com") });
        yield return new TestCaseData("asdf email@gmail.com asdf#email@gmail.com", new List<Email>
        {
            Email.Of("email@gmail.com"),
            Email.Of("email@gmail.com")
        });
        yield return new TestCaseData("<a href=\"mailto:pjatk@pja.edu.pl\"> pjatk@pja.edu.pl<br /></a>skype:", new List<Email>
        {
            Email.Of("pjatk@pja.edu.pl")
        });
    }
}