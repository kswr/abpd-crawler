using System.Text.RegularExpressions;

namespace Crawler;

public abstract class EmailExtractor
{
    public static HashSet<Email> Extract(string text)
    {
        var emails = new HashSet<Email>();
        if (text is null) return emails;
        foreach (var email in text.Split(' ', '<', '>', '!', '#', ';', '-', '*', '"'))
        {
            if (IsValidEmail(email)) emails.Add(Email.Of(email));
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