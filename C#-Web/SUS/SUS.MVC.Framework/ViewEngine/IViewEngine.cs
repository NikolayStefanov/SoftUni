namespace SUS.MVC.Framework.ViewEngine
{
    public interface IViewEngine
    {
        string GetHtml(string templateCode, object viewModel);
    }
}
