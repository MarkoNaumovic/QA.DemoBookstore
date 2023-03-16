using BookStoreDemo.Menu;

namespace BookStoreDemo.Abstract;

public abstract class BasePage : BaseComponent
{
    protected IPage Page;

    public LeftMenuBar LeftMenuBar { get; }

    protected BasePage(IPage page) : base(page)
    {
        Page = page;
        LeftMenuBar = new LeftMenuBar(page);
    }
}