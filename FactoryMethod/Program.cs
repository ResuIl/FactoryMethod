public interface IButton
{
    void Render();
    void OnClick();
}

public class WindowsButton : IButton
{
    public void OnClick() => Console.WriteLine("Windows button Click");
    public void Render() => Console.WriteLine("Windows button Render");
}

public class WebButton : IButton
{
    public void OnClick() => Console.WriteLine("Web button Click");
    public void Render() => Console.WriteLine("Web render Render");
}

public abstract class Dialog
{
    public void Render()
    {
        IButton Button = CreateButton();
        Button.OnClick();
        Button.Render();
    }

    public abstract IButton CreateButton();
}

public class WindowDialog : Dialog
{
    public override IButton CreateButton() => new WindowsButton();
}

public class HtmlDialog : Dialog
{
    public override IButton CreateButton() => new WebButton();
}

public class Program
{
    public static void Main()
    {
        Dialog wd = new WindowDialog();
        wd.Render();
        wd = new HtmlDialog();
        wd.Render();
    }
}