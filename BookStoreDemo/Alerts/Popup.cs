using BookStoreDemo.Abstract;

namespace BookStoreDemo.Alerts;

public class PopUp : BaseComponent
{
    public PopUp(IPage page) : base(page)
    {

    }

    private ILocator PopupAlert => Page.Locator(".modal-content");
    private ILocator DeleteBooksButton => PopupAlert.Locator("#closeSmallModal-ok");

    public async Task ClickOnDeleteBooksButton() => await DeleteBooksButton.ClickAsync();
}

