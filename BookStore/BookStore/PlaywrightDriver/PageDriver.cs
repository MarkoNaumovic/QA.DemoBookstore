namespace BookStore.PageObject;

public class PageDriver
{
    private readonly IPage Page;

    public PageDriver(IPage page)
    {
        Page = page;
    }

    public async Task GoToURL()
    {
        using var playwright = await Playwright.CreateAsync();
        await using var browser = await playwright.Chromium.LaunchAsync();
        await Page.GotoAsync("https://demoqa.com/books");
    }
}
