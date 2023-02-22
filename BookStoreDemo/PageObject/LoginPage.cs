using BookStoreDemo.Abstract;
using BookStoreDemo.TestSettings;
using Microsoft.VisualStudio.TestPlatform.Common;

namespace BookStoreDemo.PageObject;

public class LoginPage : BasePage
{
    public LoginPage(IPage page) : base(page)
    {
        
    }

    private ILocator LoginToApp => Page.Locator("#login");
    private ILocator UserName => Page.Locator("#userName");
    private ILocator Password => Page.Locator("#password");
    private ILocator ButtonLogin => Page.Locator(".mt-2 #login");

    public async Task Login(string username, string pass)
    {
        await Page.GotoAsync(GetUrl());
        await LoginToApp.ClickAsync();
        await UserName.FillAsync(username);
        await Password.FillAsync(pass);
        await ButtonLogin.ClickAsync();
    }

    public string GetUrl() => $"{URLs.BaseUrl}/books";
}
