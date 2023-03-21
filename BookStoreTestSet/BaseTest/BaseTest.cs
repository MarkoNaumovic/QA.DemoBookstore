using BookStoreDemo.Extension;
using BookStoreDemo.Helper;
using BookStoreDemo.TestSettings;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace BookStoreTestSet.Base;
public abstract class BaseTest : PageTest
{
    public IConfiguration _configuration;


    [SetUp]
    public async Task SetUp()
    {
        await TraceRecorderHelper.StartTestTracingAsync(Page);
    }

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _configuration = ConfigHelper.Configuration;
        URLs.BaseUrl = _configuration["BaseUrl"];
    }

    [TearDown]
    public async Task AfterTest()
    {
        await Page.TakeScreenshotIfFailed();
        await TraceRecorderHelper.AttachTraceViewerToTestContextWhenTestFailsAsync(Page);
    }
}
