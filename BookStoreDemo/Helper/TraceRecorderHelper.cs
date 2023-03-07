namespace BookStoreDemo.Helper;

public static class TraceRecorderHelper
{
    public static async Task StartTestTracingAsync(IPage page)
    {
        await page.Context.Tracing.StartAsync(new TracingStartOptions
        {
            Screenshots = true,
            Snapshots = true,
            Sources = true
        });
    }

    public static async Task AttachTraceViewerToTestContextWhenTestFailsAsync(IPage page)
    {
        var testContext = TestContext.CurrentContext;
        var uniqueName = Path.Combine(Path.GetTempPath(), $"{testContext.Test.Name}_{DateTime.Now:yyyy_MM_dd_HH_mm_ssss}.zip");

        await page.Context.Tracing.StopAsync(new TracingStopOptions
        {
            Path = uniqueName
        });

        if (testContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
        {
            TestContext.AddTestAttachment(uniqueName, testContext.Test.MethodName);
        }
    }
}

