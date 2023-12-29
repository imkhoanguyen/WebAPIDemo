namespace WebApp.Data
{
    public class WebApiExecuter : IWebApiExecuter
    {
        private readonly IHttpClientFactory httpClientFactory;
        private const string apiName = "ShirtsApi";

        public WebApiExecuter(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<T?> InvokeGet<T>(string relativeUrl)
        {
            var httpClient = httpClientFactory.CreateClient(apiName);
            return await httpClient.GetFromJsonAsync<T>(relativeUrl);
        }
    }
}
