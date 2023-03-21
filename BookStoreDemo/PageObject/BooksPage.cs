using BookStoreDemo.Abstract;
using BookStoreDemo.Alerts;

namespace BookStoreDemo.PageObject;

public class BooksPage : BasePage
{
    public PopUp PopUp;
    public BooksPage(IPage page) : base(page)
    {
        PopUp = new PopUp(page);
    }

    public ILocator SearchResultRow(string text) => Page.GetByRole(AriaRole.Row, new() { Name = text });
    public ILocator BookAuthorCell(string author) => Page.GetByRole(AriaRole.Gridcell, new() { Name = author });
    private ILocator SelectBookLink(string book) => Page.GetByRole(AriaRole.Link, new() { Name = book });
    private ILocator SearchInput => Page.Locator("#searchBox");
    private ILocator GoToBookStoreButton => Page.Locator(".text-left #addNewRecordButton");
    private ILocator AddToCollectionButton => Page.Locator(".text-right #addNewRecordButton");

    public async Task SearchForBook(string book) => await SearchInput.FillAsync(book);
    public async Task ClickOnBookInRow(string book) => await SelectBookLink(book).ClickAsync();
    public async Task ClickOnAddToCollection() => await AddToCollectionButton.ClickAsync();
    public async Task ClickGoToBookStore() => await GoToBookStoreButton.ClickAsync();

   
    
}

