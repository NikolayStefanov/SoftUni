using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.MVC.Framework.ViewEngine
{
    public interface IView
    {
        string ExecuteTemplate(object viewModel);
    }
}
