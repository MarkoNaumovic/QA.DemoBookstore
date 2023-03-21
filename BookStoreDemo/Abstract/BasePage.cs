using BookStoreDemo.Menu;

namespace BookStoreDemo.Abstract;

public abstract class BasePage : BaseComponent
{
    public LeftMenuBar LeftMenuBar { get; }

    protected BasePage(IPage page) : base(page)
    {
        LeftMenuBar = new LeftMenuBar(page);
    }
}