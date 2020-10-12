namespace SUS.MVC.Framework.ViewEngine
{
    public interface IView
    {
        string ExecuteTemplate(object viewModel);
    }
}
