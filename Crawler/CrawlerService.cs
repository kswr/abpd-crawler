namespace Crawler;

public class CrawlerService
{
    public CrawlerService(HttpClient client)
    {
        _client = client;
    }

    private readonly HttpClient _client;
    
    public CrawlResult Crawl(string[] args)
    {
        var websiteUrl = Url(args);
        HttpResponseMessage? response;
        try
        { 
            response = _client.GetAsync(websiteUrl).Result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return CrawlResult.Failure();
        }
        var body = response.Content.ReadAsStringAsync().Result;
        var emails = EmailExtractor.Extract(body);
        return CrawlResult.Success(emails);
    }

    private static string Url(IReadOnlyList<string> args)
    {
        if (args.Count < 1) throw new ArgumentNullException();
        var uri = args[0];
        if (!Uri.IsWellFormedUriString(uri, UriKind.Absolute)) throw new ArgumentException();
        return uri;
    }
}

public class CrawlResult
{
    public bool Successful { get; }
    public HashSet<Email> Result { get; }

    private CrawlResult(bool successful, HashSet<Email> result)
    {
        Successful = successful;
        Result = result;
    }

    public static CrawlResult Success(HashSet<Email> result)
    {
        return new CrawlResult(true, result);
    }
    
    public static CrawlResult Failure()
    {
        return new CrawlResult(false, new HashSet<Email>());
    }


    public override string ToString()
    {
        return $"Successful: {Successful}, Result: {Result}";
    }

    public override bool Equals(object? obj)
    {
        return obj is CrawlResult cr && Equals(cr);
    }

    private bool Equals(CrawlResult other)
    {
        return Successful == other.Successful && Result.SetEquals(other.Result);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Successful, Result);
    }
}