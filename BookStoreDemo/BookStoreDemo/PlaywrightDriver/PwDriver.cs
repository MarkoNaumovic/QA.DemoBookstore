namespace BookStoreDemo.PlaywrightDriver;

public class PwDriver
{
    private readonly IPage Page;

    public PwDriver(IPage page)
    {
        Page = page;
    }

    public async Task GoToURL()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync();
        await Page.GotoAsync("https://demoqa.com/books", new PageGotoOptions { WaitUntil = WaitUntilState.Load });
        await Page.SetViewportSizeAsync(1600, 900);
    }
}
