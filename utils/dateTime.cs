namespace dotnet_api.Controllers;

using System.Globalization;
public class getDateTime
{

    public static DateTime dateTime()
    {
        DateTime localDate = DateTime.Now;
        return Convert.ToDateTime(localDate.ToString("yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US")));
    }
    public static DateTime date()
    {
        DateTime localDate = DateTime.Now;
        return Convert.ToDateTime(localDate.ToString("yyyy-MM-dd", new CultureInfo("en-US")));
    }
    public static DateTime time()
    {
        DateTime localDate = DateTime.Now;
        return Convert.ToDateTime(localDate.ToString("HH:mm:ss", new CultureInfo("en-US")));
    }
}