using BookStoreDemo.Abstract;

namespace BookStoreDemo.PageObject;

public class PopupPage:BasePage
{
    public PopupPage(IPage page) : base(page)
    {

    }

    private ILocator PopupAlert => Page.Locator(".modal-content");
    private ILocator ConfirmDeleteBooks => PopupAlert.Locator("#closeSmallModal-ok");

    public async Task ClickDeleteAllBooksPopUpConfirm() => await ConfirmDeleteBooks.ClickAsync();
}

