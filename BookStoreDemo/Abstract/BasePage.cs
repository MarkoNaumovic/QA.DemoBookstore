using Microsoft.Playwright.NUnit;

namespace BookStoreDemo.Abstract;

public abstract class BasePage
{
    protected IPage Page { get; }
    protected BasePage(IPage page)
    {
        Page = page;
    }
}

