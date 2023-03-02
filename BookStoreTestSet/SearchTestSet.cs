using BookStoreDemo.PageObject;
using BookStoreDemo.PageObject.Menu;
using NUnit.Framework;

namespace BookStoreTestSet.BaseTest;

public class SearchTestSet : BaseTest
{
    protected LoginPage loginPage;
    protected BooksPage bookspage;
    protected LeftBarMenu LeftBarMenu;
    protected ProfilePage profilePage;

    [SetUp]
    public void OneTimeSetUp()
    {
        loginPage = new LoginPage(Page);
        bookspage = new BooksPage(Page);
        profilePage = new ProfilePage(Page);
        LeftBarMenu = new LeftBarMenu(Page);
    }

    [Test]
    public async Task TC1_SearchBook_ShouldGetSearchResult()
    {
        await loginPage.Login(username: _configuration["Username"], pass: _configuration["Password"]);
        await LeftBarMenu.LeftMenuOption("Book Store");
        await bookspage.SearchForBook("Understanding ECMAScript 6");

        await Expect(bookspage.SearchResult("Understanding ECMAScript 6 Nicholas C. Zakas No Starch Press")).ToBeVisibleAsync();
    }

    [Test]
    public async Task TC2_SearchBookAndAddToCollection_ShouldBookBeInCollection()
    {
        await loginPage.Login(username: _configuration["UserName"], pass: _configuration["Password"]);
        await LeftBarMenu.LeftMenuOption("Book Store");
        await bookspage.SearchForBook("Understanding ECMAScript 6");
        await bookspage.ClickOnBookInRow();
        await bookspage.AddToCollection();
        await LeftBarMenu.LeftMenuOption("Profile");

        await Expect(profilePage.BookInCollection("Understanding ECMAScript 6 Nicholas C. Zakas No Starch Press")).ToBeVisibleAsync();

        await profilePage.DeleteAllBooks();
        await profilePage.DeleteAllBooksPopUpConfirm();

        await Expect(profilePage.BookInCollection("Understanding ECMAScript 6 Nicholas C. Zakas No Starch Press")).ToBeHiddenAsync();
    }

}

