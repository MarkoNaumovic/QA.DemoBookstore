using BookStoreDemo.PageObject;
using NUnit.Framework;

namespace BookStoreTestSet;

public class SearchTestSet : BaseTest
{
    protected LoginPage loginPage;
    protected BooksPage bookspage;
    protected ProfilePage profilePage;


    [SetUp]
    public async Task OneTimeSetUp()
    {
        loginPage = new LoginPage(Page);
        bookspage = new BooksPage(Page);
        profilePage = new ProfilePage(Page);

        await loginPage.Login(_configuration["Username"], _configuration["Password"]);
        await PreconditionStep();
    }


    [Test]
    public async Task TC1_SearchBook_ShouldGetSearchResult()
    {
        await bookspage.ClickOnLeftMenuOption("Book Store");
        await bookspage.SearchForBook("Understanding ECMAScript 6");

        await Expect(bookspage.SearchResultRow("Understanding ECMAScript 6")).ToBeVisibleAsync();
        await Expect(bookspage.BookAuthorCell("Nicholas C. Zakas")).ToBeVisibleAsync();
    }

    [Test]
    public async Task TC2_SearchBookAddToCollection_ShouldVerifyBookInforation()
    {
        await bookspage.ClickOnLeftMenuOption("Book Store");
        await bookspage.SearchForBook("Speaking JavaScript");
        await bookspage.ClickOnBookInRow("Speaking JavaScript");
        await bookspage.ClickOnAddToCollection();
        await bookspage.ClickOnLeftMenuOption("Profile");

        await profilePage.ClickOnBookInRow("Speaking JavaScript");

        await Expect(profilePage.IsbnNumberOfBook("9781449365035")).ToBeVisibleAsync();
        await Expect(profilePage.TitleOfBook("Speaking JavaScript")).ToBeVisibleAsync();
        await Expect(profilePage.SubtitleOfBook("An In-Depth Guide for Programmers")).ToBeVisibleAsync();
        await Expect(profilePage.AuthorOfBook("Axel Rauschmayer")).ToBeVisibleAsync();
        await Expect(profilePage.PublisherOfBook("O'Reilly Media")).ToBeVisibleAsync();
        await Expect(profilePage.NumberOfPages("460")).ToBeVisibleAsync();
        await Expect(profilePage.DescriptionOfBook(
            "Like it or not, JavaScript is everywhere these days-from browser to" +
            " server to mobile-and now you, too, need to learn the language or dive deeper " +
            "than you have. This concise book guides you into and through JavaScript, written by " +
            "a veteran programmer who o")).ToBeVisibleAsync();
        await Expect(profilePage.WebsiteUrl("http://speakingjs.com/")).ToBeVisibleAsync();
    }


    [Test]
    public async Task TC3_SearchBookAddToCollectionAndDeleteAll_ShouldCollectionBeEmpty()
    {

        await bookspage.ClickOnLeftMenuOption("Book Store");
        await bookspage.SearchForBook("Learning JavaScript Design Patterns");
        await bookspage.ClickOnBookInRow("Learning JavaScript Design Patterns");
        await bookspage.ClickOnAddToCollection();
        await bookspage.ClickOnLeftMenuOption("Profile");

        await Expect(bookspage.SearchResultRow("Learning JavaScript Design Patterns")).ToBeVisibleAsync();
    }

    [Test]
    public async Task TC4_SearchBookAndAdd2InToCollection_ShouldBooksBeInCollection()
    {

        await bookspage.ClickOnLeftMenuOption("Book Store");
        await bookspage.SearchForBook("You Don't Know JS");

        await bookspage.ClickOnBookInRow("You Don't Know JS");
        await bookspage.ClickOnAddToCollection();
        await bookspage.ClickGoToBookStore();

        await bookspage.SearchForBook("Speaking JavaScript");
        await bookspage.ClickOnBookInRow("Speaking JavaScript");
        await bookspage.ClickOnAddToCollection();
        await bookspage.ClickGoToBookStore();

        await bookspage.ClickOnLeftMenuOption("Profile");

        await Expect(profilePage.BooksInCollection("You Don't Know JS")).ToBeVisibleAsync();
        await Expect(profilePage.BooksInCollection("Speaking JavaScript")).ToBeVisibleAsync();
    }

    [Test]
    public async Task TC5_AddTwoBooksToCollectionThenRemoveOne_ShouldBeOneBookInCollection()
    {

        await bookspage.ClickOnLeftMenuOption("Book Store");

        await bookspage.ClickOnBookInRow("Designing Evolvable Web APIs with ASP");
        await bookspage.ClickOnAddToCollection();
        await bookspage.ClickGoToBookStore();

        await bookspage.ClickOnBookInRow("Eloquent JavaScript, Second Edition");
        await bookspage.ClickOnAddToCollection();
        await bookspage.ClickGoToBookStore();

        await bookspage.ClickOnLeftMenuOption("Profile");
        await profilePage.ClickOnDeleteIconAndRemoveBook("Eloquent JavaScript, Second Edition");
        await profilePage.ClickDeleteAllBooksPopUpConfirm();

        await Expect(profilePage.BooksInCollection("Designing Evolvable Web APIs with ASP")).ToBeVisibleAsync();
        await Expect(profilePage.BooksInCollection("Eloquent JavaScript, Second Edition")).ToBeHiddenAsync();
    }

    private async Task PreconditionStep()
    {
        var bookProfile = await profilePage.BookInRow.TextContentAsync();
        if (bookProfile.Equals(bookProfile))
        {
            await profilePage.ClickDeleteAllBooks();
            await profilePage.ClickDeleteAllBooksPopUpConfirm();
        }
    }
}

