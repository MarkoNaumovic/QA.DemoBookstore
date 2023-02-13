namespace BookStoreDemo.Abstract;

public abstract class BasePage
{
    protected IPage Page;
    protected BasePage(IPage page)
    {
        Page = page;
    }
}

