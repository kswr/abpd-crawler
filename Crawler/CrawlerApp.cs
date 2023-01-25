namespace Crawler;

public class CrawlerApp
{
    public static void Main(string[] args)
    {
        var httpClient = new HttpClient();
        var crawlerService = new CrawlerService(httpClient);
        var result = crawlerService.Crawl(args);
        HandleResult(result);
        httpClient.Dispose();
    }

    private static void HandleResult(CrawlResult result)
    {
        if (!result.Successful)
        {
            LogFailure();
            return;
        }

        if (result.Result.Count < 1)
        {
            LogNoEmails();
            return;
        }
        
        LogEmails(result.Result);
    }

    private static void LogFailure()
    {
        Console.WriteLine("Błąd w czasie pobierania strony");
    }

    private static void LogNoEmails()
    {
        Console.WriteLine("Nie znaleziono adresów email");
    }

    private static void LogEmails(HashSet<Email> emails)
    {
        foreach (var email in emails)
        {
            Console.WriteLine(email);
        }
    }
}