using BookStoreDemo.Extension;
using BookStoreDemo.Helper;
using BookStoreDemo.PageObject;
using BookStoreDemo.TestSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace BookStoreTestSet.BaseTest;
public abstract class BaseTest : PageTest
{
    private static readonly IConfiguration _configuration = ConfigHelper.Configuration;
    protected LoginPage loginPage;
    protected SearchPage searchPage;
    protected LeftMenuBarPage leftMenuBarPage;

    [SetUp]
    public void SetUp()
    {
        URLs.BaseUrl = _configuration["BaseUrl"];
        loginPage = new LoginPage(Page);
        searchPage = new SearchPage(Page);
        leftMenuBarPage = new LeftMenuBarPage(Page);
    }

    [TearDown]
    public async Task AfterTest()
    {
        await Page.TakeScreenshotIfFailed();
    }
}
