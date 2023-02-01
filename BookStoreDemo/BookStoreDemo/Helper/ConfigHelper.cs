namespace BookStoreDemo.Helper;

public abstract  class ConfigHelper
{
    private  IConfiguration configuration;

    public  IConfiguration Configure()
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

