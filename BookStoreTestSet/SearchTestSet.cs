using NUnit.Framework;

namespace BookStoreTestSet.BaseTest;

public class SearchTestSet : BaseTest
{

    [Test]
    public async Task TC1_SearchBook_ShouldGetSearchResult()
    {
        await loginPage.Login("Marko", "Nultien@23");
        await searchPage.SearchParam("Understanding ECMAScript 6");

        await Expect(searchPage.SearchResult).ToHaveTextAsync("Understanding ECMAScript 6");
    }

    [Test]
    public async Task TC2_SearchBookAndAddToCollection_ShouldBookBeInCollection()
    {
        await loginPage.Login("Marko", "Nultien@23");
        await searchPage.SearchParam("Understanding ECMAScript 6");
        await searchPage.SearchResult.ClickAsync();
        await searchPage.AddCollection();
        await leftMenuBarPage.SelectLeftMenuOption("Profile");

        await Expect(searchPage.SearchResult).ToHaveTextAsync("Understanding ECMAScript 6");
    }
}

