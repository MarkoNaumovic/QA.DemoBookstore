using BookStoreDemo.Abstract;

namespace BookStoreDemo.PageObject;

public class BooksPage : BasePage
{
    public BooksPage(IPage page) : base(page)
    {

    }

    private ILocator SearchInput => Page.Locator("#searchBox");
    private ILocator ButtonGoToBookStore => Page.Locator(".text-left #addNewRecordButton");

    private ILocator SelectBook(string book) => Page.GetByRole(AriaRole.Link, new() { Name = book });

    private ILocator ButtonAddToCollection => Page.Locator(".text-right #addNewRecordButton");
    public ILocator SearchResultRow(string text) => Page.GetByRole(AriaRole.Row, new() { Name = text });
    public ILocator AuthorOfTheBook(string author) => Page.GetByRole(AriaRole.Gridcell, new() { Name = author });

    public async Task SearchForBook(string book) => await SearchInput.FillAsync(book);

    public async Task ClickOnBookInRow(string book) => await SelectBook(book).ClickAsync();

    public async Task ClickOnAddToCollection() => await ButtonAddToCollection.ClickAsync();

    public async Task ClickGoToBookStore() => await ButtonGoToBookStore.ClickAsync();

    public async Task PopUpConfirm()
    {
        var popup = await Page.RunAndWaitForPopupAsync(async () =>
        {
            await Page.GetByText("OK").ClickAsync();
        });
        await popup.WaitForLoadStateAsync();
    }

    public async Task ScrollIntoViewIfNeeded()
    {
        var elementHandle = await Page.QuerySelectorAsync("#gotoStore");
        if (elementHandle != null)
        {
            await Page.EvaluateAsync("element => element.scrollIntoView()", elementHandle);
        }
        else
        {
            Console.WriteLine("Element not found");
        }
    }
}

