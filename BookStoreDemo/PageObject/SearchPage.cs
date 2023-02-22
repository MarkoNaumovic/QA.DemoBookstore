using BookStoreDemo.Abstract;

namespace BookStoreDemo.PageObject;

public class SearchPage : BasePage
{
    public SearchPage(IPage page) : base(page)
    {

    }

    public ILocator InputSearch => Page.Locator("#searchBox");
    public ILocator SearchResult => Page.Locator(".mr-2 a");
    public ILocator ButtonAddToCollection => Page.GetByRole(AriaRole.Button, new() { Name = "Add To Your Collection" });

    public async Task SearchParam(string book) => await InputSearch.FillAsync(book);
    public async Task AddCollection() => await ButtonAddToCollection.ClickAsync();

}

