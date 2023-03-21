using Base;
using BookStoreDemo.PageObject;
using NUnit.Framework;

namespace BookStoreTestSet;

public class SearchTestSet : BaseTest
{
    protected LoginPage loginPage;
    protected BooksPage bookspage;
    protected ProfilePage profilePage;
    protected BookDetailPage bookDetailPage;

    [SetUp]
    public async Task SetUp()
    {
        loginPage = new LoginPage(Page);
        bookspage = new BooksPage(Page);
        profilePage = new ProfilePage(Page);
        bookDetailPage = new BookDetailPage(Page);

        await loginPage.Login(_configuration["Username"], _configuration["Password"]);
        await PreconditionStep();
    }


    [Test]
    public async Task TC1_SearchBook_ShouldGetSearchResult()
    {
        await bookspage.LeftMenuBar.ClickOnLeftMenuOption("Book Store");
        await bookspage.SearchForBook("Understanding ECMAScript 6");

        await Expect(bookspage.SearchResultRow("Understanding ECMAScript 6")).ToBeVisibleAsync();
        await Expect(bookspage.BookAuthorCell("Nicholas C. Zakas")).ToBeVisibleAsync();
    }

    [Test]
    public async Task TC2_SearchBookAddToCollection_ShouldVerifyBookInforation()
    {
        await bookspage.LeftMenuBar.ClickOnLeftMenuOption("Book Store");
        await bookspage.SearchForBook("Speaking JavaScript");
        await bookspage.ClickOnBookInRow("Speaking JavaScript");
        await bookspage.ClickOnAddToCollection();
        await bookspage.LeftMenuBar.ClickOnLeftMenuOption("Profile");

        await profilePage.ClickOnBookInRow("Speaking JavaScript");

        await Expect(bookDetailPage.IsbnNumberOfBookLabel("9781449365035")).ToBeVisibleAsync();
        await Expect(bookDetailPage.TitleOfBookLabel("Speaking JavaScript")).ToBeVisibleAsync();
        await Expect(bookDetailPage.SubtitleOfBookLabel("An In-Depth Guide for Programmers")).ToBeVisibleAsync();
        await Expect(bookDetailPage.AuthorOfBookLabel("Axel Rauschmayer")).ToBeVisibleAsync();
        await Expect(bookDetailPage.PublisherOfBookLabel("O'Reilly Media")).ToBeVisibleAsync();
        await Expect(bookDetailPage.NumberOfPagesLabel("460")).ToBeVisibleAsync();
        await Expect(bookDetailPage.DescriptionOfBookLabel(
            "Like it or not, JavaScript is everywhere these days-from browser to server to mobile-and now you, " +
            "too, need to learn the language or dive deeper than you have. " +
            "This concise book guides you into and through JavaScript, " +
            "written by a veteran programmer who o")).ToBeVisibleAsync();
        await Expect(bookDetailPage.WebsiteUrlLabel("http://speakingjs.com/")).ToBeVisibleAsync();
    }


    [Test]
    public async Task TC3_SearchBookAddToCollectionAndDeleteAll_ShouldCollectionBeEmpty()
    {
        await bookspage.LeftMenuBar.ClickOnLeftMenuOption("Book Store");
        await bookspage.SearchForBook("Learning JavaScript Design Patterns");
        await bookspage.ClickOnBookInRow("Learning JavaScript Design Patterns");
        await bookspage.ClickOnAddToCollection();
        await bookspage.LeftMenuBar.ClickOnLeftMenuOption("Profile");

        await Expect(bookspage.SearchResultRow("Learning JavaScript Design Patterns")).ToBeVisibleAsync();
    }

    [Test]
    public async Task TC4_SearchBookAndAdd2InToCollection_ShouldBooksBeInCollection()
    {
        await bookspage.LeftMenuBar.ClickOnLeftMenuOption("Book Store");
        await bookspage.SearchForBook("You Don't Know JS");

        await bookspage.ClickOnBookInRow("You Don't Know JS");
        await bookspage.ClickOnAddToCollection();
        await bookspage.ClickGoToBookStore();

        await bookspage.SearchForBook("Speaking JavaScript");
        await bookspage.ClickOnBookInRow("Speaking JavaScript");
        await bookspage.ClickOnAddToCollection();
        await bookspage.ClickGoToBookStore();

        await bookspage.LeftMenuBar.ClickOnLeftMenuOption("Profile");

        await Expect(profilePage.BooksInCollection("You Don't Know JS")).ToBeVisibleAsync();
        await Expect(profilePage.BooksInCollection("Speaking JavaScript")).ToBeVisibleAsync();
    }

    [Test]
    public async Task TC5_AddTwoBooksToCollectionThenRemoveOne_ShouldBeOneBookInCollection()
    {
        await bookspage.LeftMenuBar.ClickOnLeftMenuOption("Book Store");

        await bookspage.ClickOnBookInRow("Designing Evolvable Web APIs with ASP");
        await bookspage.ClickOnAddToCollection();
        await bookspage.ClickGoToBookStore();

        await bookspage.ClickOnBookInRow("Eloquent JavaScript, Second Edition");
        await bookspage.ClickOnAddToCollection();
        await bookspage.ClickGoToBookStore();

        await bookspage.LeftMenuBar.ClickOnLeftMenuOption("Profile");
        await profilePage.ClickOnDeleteBook("Eloquent JavaScript, Second Edition");
        await bookspage.PopUp.ClickOnDeleteBooksButton();

        await Expect(profilePage.BooksInCollection("Designing Evolvable Web APIs with ASP")).ToBeVisibleAsync();
        await Expect(profilePage.BooksInCollection("Eloquent JavaScript, Second Edition")).ToBeHiddenAsync();
    }

    private async Task PreconditionStep()
    {
        var bookProfile = await bookDetailPage.BookInRow.AllInnerTextsAsync();
        if (bookProfile != null && bookProfile.Count > 0 && !string.IsNullOrEmpty(bookProfile[0]))
        {
            await profilePage.ClickDeleteAllBooks();
            await bookspage.Popup.ClickOnDeleteBooksButton();
        }
    }
}