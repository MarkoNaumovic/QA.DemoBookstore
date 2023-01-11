namespace BookStore.PageObject;

public class RegistrationPage
{
    private IPage _page;

    private ILocator InputFirstName => _page.Locator("#firstname");
    private ILocator InputLastName => _page.Locator("#lastname");
    private ILocator InputUserName => _page.Locator("#userName");
    private ILocator InputPassword => _page.Locator("#password");
    private ILocator ReCaptcha => _page.FrameLocator("//iframe[@title ='reCAPTCHA']").Locator("#recaptcha-anchor");
    private ILocator ButtonRegistration => _page.Locator("#register");

    public async Task FirstName(string name) => await InputFirstName.FillAsync(name);


    public async Task LastName(string lastName) => await InputLastName.FillAsync(lastName);


    public async Task UserName(string userName) => await InputUserName.FillAsync(userName);

    public async Task Password(string pass) => await InputPassword.FillAsync(pass);


    public async Task CheckBoxClick() => await ReCaptcha.ClickAsync();


    public async Task RegistrationConfirm() => await ButtonRegistration.ClickAsync();

    public async Task RegistrationPopUp(string message)
    {
        _page.Dialog += (_, dialog) =>
        {
            message = dialog.Message;
        };
    }

    public RegistrationPage(IPage page)
    {
        _page = page;
    }
}

