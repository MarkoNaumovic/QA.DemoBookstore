﻿using BookStoreDemo.Abstract;
using BookStoreDemo.TestSettings;

namespace BookStoreDemo.PageObject;

public class LoginPage : BasePage
{
    public LoginPage(IPage page) : base(page)
    {

    }

    private ILocator UsernameInput => Page.Locator("#userName");
    private ILocator PasswordInput => Page.Locator("#password");
    private ILocator ButtonLogin => Page.Locator("#login");

    public async Task Login(string username, string pass)
    {
        await Page.GotoAsync(GetUrl(), new PageGotoOptions() { WaitUntil = WaitUntilState.DOMContentLoaded });
        await UsernameInput.FillAsync(username);
        await PasswordInput.FillAsync(pass);
        await ButtonLogin.ClickAsync();
    }

    public string GetUrl() => $"{URLs.BaseUrl}/login";
}
