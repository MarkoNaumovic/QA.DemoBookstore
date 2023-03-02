using BookStoreDemo.Abstract;

namespace BookStoreDemo.PageObject;

public class ProfilePage : BasePage
{
    public ProfilePage(IPage page) : base(page)
    {

    }

    private ILocator DeleteBooks => Page.GetByRole(AriaRole.Button, new() { Name = "Delete All Books" });
    private ILocator PopupConfirmDeleteBooks => Page.Locator(".modal-content #closeSmallModal-ok");

    public ILocator BookInCollection(string text) => Page.GetByRole(AriaRole.Row, new() { Name = text });

    public async Task DeleteAllBooks() => await DeleteBooks.ClickAsync();

    public async Task DeleteAllBooksPopUpConfirm() { await PopupConfirmDeleteBooks.ClickAsync(); }
}

