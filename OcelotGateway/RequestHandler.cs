namespace OcelotGateway
{
    public class RequestHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //do stuff and optionally call the base handler..
            request.Headers.Add("hel","lo");
            return await base.SendAsync(request, cancellationToken);
        }
    }
}
