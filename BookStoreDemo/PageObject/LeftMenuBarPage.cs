using BookStoreDemo.Abstract;

namespace BookStoreDemo.PageObject;

    public class LeftMenuBarPage:BasePage
    {
        public LeftMenuBarPage(IPage page) : base(page)
        {

        }

        public ILocator SelectOption(string option) => Page.Locator(".element-list .menu-list span").GetByText(option);

        public async Task SelectLeftMenuOption(string option) => await SelectOption(option).ClickAsync();

    }

