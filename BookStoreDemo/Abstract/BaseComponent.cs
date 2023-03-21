namespace BookStoreDemo.Abstract;

public class BaseComponent
{
    protected IPage Page;

    protected BaseComponent(IPage page)
    {
        Page = page;
    }
}

