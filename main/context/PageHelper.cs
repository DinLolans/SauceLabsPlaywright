namespace SauceLabsP.Context;

public static class PageHelper
{
    private static readonly Random Random = new();

    public static string GetRandomString(int length = 5)
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[Random.Next(s.Length)]).ToArray());
    }

    public static string GetRandomInt(int length = 5) => new string(Enumerable.Repeat(Random.Next(0, 9).ToString(), length)
            .Select(s => s[Random.Next(s.Length)]).ToArray());
}
