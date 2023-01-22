namespace BookStoreDemo.PageObject;

public class MyPageBook : PageTest
{
    public BasePage _basePage;
    public IConfiguration _configuration;
    public LoginPage _loginPage;

    [SetUp]
    public void BeforeEachTest()
    {
        _loginPage =new LoginPage(Page);
        _configuration = ConfigHelper.Configure();
        _basePage = new BasePage(Page);
    }


    [TearDown]
    public async Task WebAppPageAfterEachTest()
    {
        await _basePage.TakeScreenshot();
        await _loginPage.Logout();
    }
}

