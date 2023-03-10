namespace BookStoreDemo.Abstract;

public abstract class BasePage : BaseComponent
{
    protected IPage Page;
    protected BasePage(IPage page) : base(page)
    {
        Page = page;
    }

    public ILocator SelectOption(string option) => Page.Locator(".element-list .menu-list span").GetByText(option).First;

    public async Task ClickOnLeftMenuOption(string option) => await SelectOption(option).ClickAsync();
}