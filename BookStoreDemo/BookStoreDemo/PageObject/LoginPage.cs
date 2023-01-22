namespace BookStoreDemo.PageObject;

public class LoginPage
{
    private readonly IPage page;
    private readonly IConfiguration _configuration;

    public LoginPage(IPage page)
    {
        this.page = page;
        _configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();
        _ = InitializeContextAsync();
    }

    public async Task LogIn(string username, string password)
    {
        await page.GotoAsync(_configuration["BaseUrl"], new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle });
        await page.FillAsync("#username", username);
        await page.FillAsync("#password", password);
        await page.RunAndWaitForNavigationAsync(async () =>
        {
            await page.ClickAsync("button:has-text('Log in')");
        });

        await page.WaitForNavigationAsync(new() { UrlRegex = new Regex(@"\#/profile$") });
    }

    public async Task Logout() => await page.ClickAsync("#submit");

    private async Task InitializeContextAsync()
    {
        if (page.Context.Browser.Contexts.Count > 0)
            return;

        await page.Context.Browser.NewContextAsync(new()
        {
            AcceptDownloads = true,
            IgnoreHTTPSErrors = true,
        });
    }
}
