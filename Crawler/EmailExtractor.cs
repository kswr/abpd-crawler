namespace Crawler;

public class EmailExtractor
{
    public static List<Email> Extract(string text)
    {
        return new List<Email>();
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