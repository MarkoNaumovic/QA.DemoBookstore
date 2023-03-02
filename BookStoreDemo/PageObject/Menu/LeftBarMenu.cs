using BookStoreDemo.Abstract;

namespace BookStoreDemo.PageObject.Menu;

public class LeftBarMenu : BasePage
{
    public LeftBarMenu(IPage page) : base(page)
    {
        Page = page;
    }
    public ILocator SelectOption(string option) => Page.Locator(".element-list .menu-list span").GetByText(option).First;

    public async Task LeftMenuOption(string option) => await SelectOption(option).ClickAsync();
}

