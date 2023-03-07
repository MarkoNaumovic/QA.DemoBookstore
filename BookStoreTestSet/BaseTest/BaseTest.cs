using BookStoreDemo.Extension;
using BookStoreDemo.Helper;
using BookStoreDemo.TestSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace BookStoreTestSet.BaseTest;
public abstract class BaseTest : PageTest
{
    public IConfiguration _configuration;


    [SetUp]
    public async Task SetUp()
    {
        
        _configuration = ConfigHelper.Configuration;
        URLs.BaseUrl = _configuration["BaseUrl"];
        await TraceRecorderHelper.StartTestTracingAsync(Page);
    }

    [TearDown]
    public async Task AfterTest()
    {
        await Page.TakeScreenshotIfFailed();
        await TraceRecorderHelper.AttachTraceViewerToTestContextWhenTestFailsAsync(Page);
        await Page.CloseAsync();
    }
}
