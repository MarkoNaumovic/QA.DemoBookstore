namespace BookStoreDemo.Helper;

public static class ConfigHelper
{
    private static IConfiguration configuration;

    public static IConfiguration Configure()
    {
        if (configuration is not null)
            return configuration;

        configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
        return configuration;
    }
}

