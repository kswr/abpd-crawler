namespace Crawler;

public static class CrawlerService
{
    public static List<Email> Crawl(string[] args)
    {
        var websiteUrl = Url(args);
        var client = new HttpClient();
        var response = client.GetAsync(websiteUrl).Result;
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