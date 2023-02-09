using BookStoreDemo.Abstract;
using BookStoreDemo.TestSettings;

namespace BookStoreDemo.PageObject;

public class LoginPage : BasePage
{
    public LoginPage(IPage page) : base(page)
    {
    }

    private ILocator UserName => Page.Locator("#username");
    private ILocator Password => Page.Locator("#password");
    private ILocator ButtonLogin => Page.Locator("button:has-text('Log in')");

    public async Task Login(string username, string pass)
    {
        await Page.GotoAsync(URLs.BaseUrl, new PageGotoOptions { WaitUntil = WaitUntilState.NetworkIdle });
        await UserName.FillAsync(username);
        await Password.FillAsync(pass);
        await ButtonLogin.ClickAsync();
        await Page.WaitForURLAsync(new Regex(@"\#/profile$"));
    }
}
