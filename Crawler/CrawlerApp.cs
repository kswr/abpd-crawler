using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace Crawler;

public class CrawlerApp
{
    public static void Main(string[] args)
    {
        var httpClient = new HttpClient();
        var crawlerService = new CrawlerService(httpClient);
        var emails = crawlerService.Crawl(args);
        if (emails.Count < 1) LogNoEmails();
        else LogEmails(emails);
        httpClient.Dispose();
    }

    private static void LogNoEmails()
    {
        Console.WriteLine("Nie znaleziono adresów email");
    }

    public static void LogEmails(HashSet<Email> emails)
    {
        foreach (var email in emails)
        {
            Console.WriteLine(email);
        }
    }
}