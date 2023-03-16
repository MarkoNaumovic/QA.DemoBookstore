using BookStoreDemo.Abstract;

namespace BookStoreDemo.Menu;

public class LeftMenuBar : BaseComponent
{
    public LeftMenuBar(IPage page) : base(page)
    {

    }

    public ILocator SelectOption(string option) => Page.Locator(".element-list .menu-list span").GetByText(option).First;

    public async Task ClickOnLeftMenuOption(string option) => await SelectOption(option).ClickAsync();
}

