using BookStoreDemo.Abstract;

namespace BookStoreDemo.PageObject;

public class ProfilePage : BasePage
{
    public ProfilePage(IPage page) : base(page)
    {

    }

    private ILocator DeleteAllBooksButton => Page.Locator(".di #submit");
    private ILocator SelectBookLink(string book) => Page.GetByRole(AriaRole.Link, new() { Name = book });
    private ILocator DeleteSingleBookIcon(string book) => BooksInCollection(book).Locator("#delete-record-undefined");

   
    public ILocator BooksInCollection(string text) => Page.GetByRole(AriaRole.Row, new() { Name = text });
    public async Task ClickDeleteAllBooks() => await DeleteAllBooksButton.ClickAsync();

    public async Task ClickOnDeleteBook(string book) => await DeleteSingleBookIcon(book).ClickAsync();
    public async Task ClickOnBookInRow(string book) => await SelectBookLink(book).ClickAsync();
}

