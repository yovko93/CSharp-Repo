using MyWebServer.Http;

namespace MyWebServer.Results
{
    public class BadRequestResult : ActionResult
    {
        public BadRequestResult(HttpResponse response)
            : base(response)
            => this.StatusCode = HttpStatusCode.BadRequest;

    }
}
