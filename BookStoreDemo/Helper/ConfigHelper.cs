namespace BookStoreDemo.Helper;

public static  class ConfigHelper
{
    public static readonly IConfiguration Configuration = new ConfigurationBuilder()
        .AddEnvironmentVariables()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .Build();
}

