using BookStoreDemo.Extension;
using BookStoreDemo.Helper;
using BookStoreDemo.TestSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace BookStoreTestSet.BaseTest;
public abstract class BaseTest : PageTest
{
    private static IConfiguration _configuration = ConfigHelper.Configuration;

    [OneTimeSetUp]
    public void SetUp()
    {
        URLs.BaseUrl = _configuration["BaseUrl"];
    }

    [TearDown]
    public async Task AfterTest()
    {
        await Page.TakeScreenshotIfFailed();
    }
}
