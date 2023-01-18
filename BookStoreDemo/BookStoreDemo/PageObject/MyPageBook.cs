using BookStoreDemo.Helper;
using BookStoreDemo.PlaywrightDriver;
using Microsoft.Playwright.NUnit;
namespace BookStoreDemo.PageObject;

public class MyPageBook: PageTest
{
    public Until _utilPage;
    public PwDriver _wpDriver;

    [SetUp]
    public void BeforeEachTest()
    {
        _wpDriver = new PwDriver(Page);
        _utilPage = new Until(Page);
    }


    [TearDown]
    public async Task WebAppPageAfterEachTest()
    {
        await _utilPage.ScreenshotWhenTestsFails();
        await Page.CloseAsync();
    }
}

