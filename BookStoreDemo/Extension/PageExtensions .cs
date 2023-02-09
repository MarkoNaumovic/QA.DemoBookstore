namespace BookStoreDemo.Extension;

public static class Extensions
{
    public static async Task TakeScreenshotIfFailed(this IPage page)
    {
        var testContext = TestContext.CurrentContext;

        if (testContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            var uniqueName = Path.Combine(Path.GetTempPath(), $"{testContext.Test.Name}_{DateTime.Now:yyyy_MM_dd_HH_mm_ssss}.png");
            await page.ScreenshotAsync(new PageScreenshotOptions { Path = uniqueName });
            TestContext.AddTestAttachment(uniqueName, testContext.Test.MethodName);
        }
    }
}

