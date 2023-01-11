namespace BookStore.PageObject;

public class BookPage
{
    private readonly IPage _page;

    private ILocator ButtonLogin => _page.Locator("#login");
    private ILocator ButtonNewUser => _page.Locator("#newUser");

    public async Task ClickOnLoginButton()
    {
        await ButtonLogin.ClickAsync();
    }

    public async Task ClickOnNewUserButton()
    {
        await ButtonNewUser.ClickAsync();
    }

    public BookPage(IPage page)
    {
        _page = page;
    }
}

