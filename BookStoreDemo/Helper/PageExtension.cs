namespace BookStoreDemo.Helper;

public abstract class PageExtension
{
    private readonly IPage _page;

    protected PageExtension(IPage page)
    {
        _page = page;
    }

    public async Task TakeScreenshot()
    {
        var testContext = TestContext.CurrentContext;

        if (testContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            var uniqueName = Path.Combine(Path.GetTempPath(), $"{testContext.Test.Name}_{DateTime.Now:yyyy_MM_dd_HH_mm_ssss}.png");
            await _page.ScreenshotAsync(new PageScreenshotOptions { Path = uniqueName });
            TestContext.AddTestAttachment(uniqueName, testContext.Test.MethodName);
        }
    }
}

