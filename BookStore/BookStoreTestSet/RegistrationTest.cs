namespace BookStore
{
    public class RegistrationTest : PageTest
    {
        private PageDriver _pageDriver;
        private BookPage _bookPage;
        private RegistrationPage _registrationPage;

        [SetUp]
        public void Setup()
        {
            _pageDriver = new PageDriver(Page);
            _bookPage = new BookPage(Page);
            _registrationPage = new RegistrationPage(Page);
        }

        [Test]
        public async Task TC1_RegistrationNewUser_ShouldShowPopupRegistrationUserSuccessfully()
        {
            await _pageDriver.GoToURL();
            await _bookPage.ClickOnLoginButton();
            await _bookPage.ClickOnNewUserButton();
            await _registrationPage.FirstName("Marko");
            await _registrationPage.LastName("Naumovic");
            await _registrationPage.UserName("NulTien");
            await _registrationPage.Password("Masa@1234567");
            await _registrationPage.CheckBoxClick();
            await _registrationPage.RegistrationConfirm();
            string message;
            Page.Dialog += (_, dialog) =>
            {
                message = dialog.Message;
                Assert.That(message, Does.Contain("User Register Successfully."));
                dialog.AcceptAsync();
            };
        }
    }
}