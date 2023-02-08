namespace BookStoreDemo.PageObject;

public class LoginPage
{
    private readonly IPage _page;
    private static IConfiguration configuration;

    protected LoginPage(IPage page)
    {
        _page = page;
    }

    private ILocator UserName => _page.Locator("#username");
    private ILocator Password => _page.Locator("#password");
    private ILocator ButtonLogin => _page.Locator("button:has-text('Log in')");

    public async Task Login(string username, string pass)
    {
        await _page.GotoAsync(configuration["BaseUrl"], new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle });
        await UserName.FillAsync(username);
        await Password.FillAsync(pass);
        await ButtonLogin.ClickAsync();
        await _page.WaitForURLAsync(new Regex(@"\#/profile$"));
    }
}
