using System.Text.RegularExpressions;

namespace Crawler;

public abstract class EmailExtractor
{
    public static List<Email> Extract(string text)
    {
        if (text is null) return new List<Email>();
        return (from email in text.Split(' ', '<', '>', '!', '#', ';', '-', '*') 
            where IsValidEmail(email) 
            select Email.Of(email)).ToList();
    }

    private static bool IsValidEmail(string email)
    {
        var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        return regex.Match(email).Success;
    }
}

public record Email
{
    private string _email;

    private Email(string email)
    {
        _email = email;
    }

    public static Email Of(string email)
    {
        return new Email(email);
    }
}