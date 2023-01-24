using System.Text.RegularExpressions;

namespace Crawler;

public abstract class EmailExtractor
{
    public static List<Email> Extract(string text)
    {
        var emails = new List<Email>();
        if (text is not null)
        {
            emails.AddRange(from email in text.Split(' ', '<', '>', '!', '#', ';', '-', '*', '"')
                where IsValidEmail(email)
                select Email.Of(email));
        }
        return emails;
    }

    private static bool IsValidEmail(string email)
    {
        var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        return regex.Match(email).Success;
    }
}

public record Email(string EmailAddress)
{
    public static Email Of(string email)
    {
        return new Email(email);
    }
}