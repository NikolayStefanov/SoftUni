using SUS.HTTP;
using System;
using System.Collections.Generic;
using System.Text;

namespace SUS.MVC.Framework
{
    public abstract class BaseHttpAttribute : Attribute
    {
        public string Url { get; set; }
        public abstract HttpMethod Method { get; }
    }
}
