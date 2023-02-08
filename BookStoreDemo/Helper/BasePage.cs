namespace BookStoreDemo.Helper;

public  class BasePage
{
    private ConfigHelper _configHelper;
    PageExtension _extension;

    [SetUp]
    public  void SetUp()
    {
        _configHelper.Configure();
    }

    [TearDown]
    public  async Task AfterTest()
    {
        await _extension.TakeScreenshot();
    }
}

