using BookStoreDemo.Abstract;

namespace BookStoreDemo.PageObject;

public class ProfilePage : BasePage
{
    public ProfilePage(IPage page) : base(page)
    {

    }

    private ILocator DeleteAllBooksButton => Page.Locator(".di #submit");
    private ILocator SelectBookLink(string book) => Page.GetByRole(AriaRole.Link, new() { Name = book });
    private ILocator DeleteBookFromCollectionRecycleBinIcon(string book) => BooksInCollection(book).Locator("#delete-record-undefined");

    public ILocator BookInRow => Page.Locator(".ReactTable span a");
    public ILocator IsbnNumberOfBookLabel(string isbnNumber) => Page.Locator("#ISBN-wrapper").GetByText(isbnNumber);
    public ILocator TitleOfBookLabel(string title) => Page.Locator("#title-wrapper").GetByText(title);
    public ILocator SubtitleOfBookLabel(string subtitle) => Page.Locator("#subtitle-wrapper").GetByText(subtitle);
    public ILocator AuthorOfBookLabel(string author) => Page.Locator("#author-wrapper").GetByText(author);
    public ILocator PublisherOfBookLabel(string publisher) => Page.Locator("#publisher-wrapper").GetByText(publisher);
    public ILocator NumberOfPagesLabel(string numberOfPages) => Page.Locator("#pages-wrapper").GetByText(numberOfPages);
    public ILocator DescriptionOfBookLabel(string description) => Page.Locator(".profile-wrapper #description-wrapper").GetByText(description);
    public ILocator WebsiteUrlLabel(string webUrl) => Page.Locator("#website-wrapper").GetByText(webUrl);
    public ILocator BooksInCollection(string text) => Page.GetByRole(AriaRole.Row, new() { Name = text });
    public async Task ClickDeleteAllBooks() => await DeleteAllBooksButton.ClickAsync();

    public async Task ClickOnDeleteRecycleBinIconAndRemoveBook(string book) => await DeleteBookFromCollectionRecycleBinIcon(book).ClickAsync();
    public async Task ClickOnBookInRow(string book) => await SelectBookLink(book).ClickAsync();
}

