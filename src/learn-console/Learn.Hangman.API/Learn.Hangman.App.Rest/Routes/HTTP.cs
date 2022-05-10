using System.Web.Routing;

namespace Learn.Hangman.App.Rest.Routes
{
    public static class HTTP
    {
        public static readonly HttpMethodConstraint GET = new HttpMethodConstraint("GET");
        public static readonly HttpMethodConstraint POST = new HttpMethodConstraint("POST");
        public static readonly HttpMethodConstraint PUT = new HttpMethodConstraint("PUT");
        public static readonly HttpMethodConstraint PATCH = new HttpMethodConstraint("PATCH");
        public static readonly HttpMethodConstraint DELETE = new HttpMethodConstraint("DELETE");
    }
}