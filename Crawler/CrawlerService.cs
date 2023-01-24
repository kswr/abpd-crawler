namespace Crawler;

public class CrawlerService
{
    public CrawlerService(HttpClient client)
    {
        _client = client;
    }

    private readonly HttpClient _client;
    
    public HashSet<Email> Crawl(string[] args)
    {
        var websiteUrl = Url(args);
        var response = _client.GetAsync(websiteUrl).Result;
        var body = response.Content.ReadAsStringAsync().Result;
        return EmailExtractor.Extract(body);
    }

    private static string Url(IReadOnlyList<string> args)
    {
        if (args.Count < 1) throw new ArgumentNullException();
        var uri = args[0];
        if (!Uri.IsWellFormedUriString(uri, UriKind.Absolute)) throw new ArgumentException();
        return uri;
    }
}