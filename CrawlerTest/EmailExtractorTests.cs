using Crawler;

namespace CrawlerTest;

public class EmailExtractorTests
{

    [Test]
    [TestCaseSource(nameof(ExtractsEmailCorrectlySource))]
    public void ExtractsEmailCorrectly(string text, HashSet<Email> expectedEmails)
    {
        var extracted = EmailExtractor.Extract(text);
        Assert.That(extracted, Is.EqualTo(expectedEmails));
    }

    public static IEnumerable<TestCaseData> ExtractsEmailCorrectlySource()
    {
        yield return new TestCaseData(null, new HashSet<Email>());
        yield return new TestCaseData("", new HashSet<Email>());
        yield return new TestCaseData("email@gmail.com", new HashSet<Email> { Email.Of("email@gmail.com") });
        yield return new TestCaseData("asdf<email@gmail.com", new HashSet<Email> { Email.Of("email@gmail.com") });
        yield return new TestCaseData("asdf email@gmail.com asdf", new HashSet<Email> { Email.Of("email@gmail.com") });
        yield return new TestCaseData("email@gmail.com email@gmail.com", new HashSet<Email>
        {
            Email.Of("email@gmail.com")
        });
        yield return new TestCaseData("<a href=\"mailto:pjatk@pja.edu.pl\"> pjatk@pja.edu.pl<br /></a>skype:", new HashSet<Email>
        {
            Email.Of("pjatk@pja.edu.pl")
        });
    }
}