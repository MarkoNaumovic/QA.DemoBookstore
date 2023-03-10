using BookStoreDemo.Abstract;

namespace BookStoreDemo.PageObject;

public class ProfilePage : BasePage
{
    public ProfilePage(IPage page) : base(page)
    {

    }

    private ILocator PopupAlert => Page.Locator(".modal-content");
    private ILocator ConfirmDeleteBooks => PopupAlert.Locator("#closeSmallModal-ok");
    private ILocator ButtonDeleteAllBooks => Page.Locator(".di #submit");
    public ILocator BookInRow => Page.Locator(".rt-tbody .rt-tr-group .rt-tr").First;

    private ILocator SelectBookLink(string book) => Page.GetByRole(AriaRole.Link, new() { Name = book });
    public ILocator IsbnNumberOfBook(string isbnNumber) => Page.Locator("#ISBN-wrapper").GetByText(isbnNumber);
    public ILocator TitleOfBook(string title) => Page.Locator("#title-wrapper").GetByText(title);
    public ILocator SubtitleOfBook(string subtitle) => Page.Locator("#subtitle-wrapper").GetByText(subtitle);
    public ILocator AuthorOfBook(string author) => Page.Locator("#author-wrapper").GetByText(author);
    public ILocator PublisherOfBook(string publisher) => Page.Locator("#publisher-wrapper").GetByText(publisher);
    public ILocator NumberOfPages(string numberOfPages) => Page.Locator("#pages-wrapper").GetByText(numberOfPages);
    public ILocator DescriptionOfBook(string description) => Page.Locator("#description-wrapper").GetByText(description);
    public ILocator WebsiteUrl(string webUrl) => Page.Locator("#website-wrapper").GetByText(webUrl);
    public ILocator BooksInCollection(string text) => Page.GetByRole(AriaRole.Row, new() { Name = text });
    private ILocator IconDeleteBookFromCollection(string book) => BooksInCollection(book).Locator("#delete-record-undefined");


    public async Task ClickDeleteAllBooks() => await ButtonDeleteAllBooks.ClickAsync();
    public async Task ClickDeleteAllBooksPopUpConfirm() => await ConfirmDeleteBooks.ClickAsync();
    public async Task ClickOnDeleteIconAndRemoveBook(string book) => await IconDeleteBookFromCollection(book).ClickAsync();
    public async Task ClickOnBookInRow(string book) => await SelectBookLink(book).ClickAsync();

}

