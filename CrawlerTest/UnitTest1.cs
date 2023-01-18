using Crawler;

namespace CrawlerTest;

public class GreeterTests
{

    [Test]
    public void GreeterSaysHello()
    {
        var hello = Greeter.SayHello();
        Assert.That(hello, Is.EqualTo("Hello"));
    }
}