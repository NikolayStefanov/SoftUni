using SUS.HTTP;

namespace SUS.MVC.Framework
{
    public class HttpPostAttribute : BaseHttpAttribute
    {
        public HttpPostAttribute()
        {

        }
        public HttpPostAttribute(string url)
        {
            this.Url = url;
        }
        public override HttpMethod Method => HttpMethod.Post;
    }
}
