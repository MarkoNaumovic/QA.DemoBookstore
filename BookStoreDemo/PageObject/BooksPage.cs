using BookStoreDemo.Abstract;

namespace BookStoreDemo.PageObject;

public class BooksPage : BasePage
{
    public BooksPage(IPage page) : base(page)
    {

    }

    private ILocator InputSearch => Page.Locator("#searchBox");
    private ILocator ClickOnBook => Page.Locator(".mr-2 a");
  
    private ILocator ButtonAddToCollection => Page.GetByRole(AriaRole.Button, new() { Name = "Add To Your Collection" });
    public ILocator SearchResult(string text) => Page.GetByRole(AriaRole.Row, new() { Name = text });

    public async Task SearchForBook(string book) => await InputSearch.FillAsync(book);

    public async Task ClickOnBookInRow() { await ClickOnBook.ClickAsync(); }

    public async Task AddToCollection() => await ButtonAddToCollection.ClickAsync();


}

